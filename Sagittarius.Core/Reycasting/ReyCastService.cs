using System;
using OpenTK.Mathematics;
using Sagittarius.Core.Entitys;
using Sagittarius.Core.System;

namespace Sagittarius.Core.Reycasting{

    // service for calculating the length distance between the player and the walls
    public class ReyCastService {


        private TopRey topReyStrategic;
        private DownRey downReyStrategic;
        private LeftRey leftReyStrategic;
        private RightRey rightReyStrategic;


        private Level level;
        private bool isTransparantTextures;

        public ReyCastService(Level level, bool isTransparantTextures) {
            this.level = level;
            this.isTransparantTextures = isTransparantTextures;

            topReyStrategic = new TopRey();
            downReyStrategic = new DownRey();
            leftReyStrategic = new LeftRey();
            rightReyStrategic = new RightRey();
        }


        //the service interface executes the firing of beams according to the given instructions
        public ReyContainer[] ReyCastWall(BaseEntity entity, float fov, float depth, uint CountRey) {
            Rey[] result = new Rey[CountRey];

            for (int i = 0; i < CountRey; i++) {
                float ReyAngle = (entity.Angle.X + fov / 2 - i * fov / CountRey);


                Vector2 PosEntity2d = entity.Position.Xy + (entity.Size / 2);
                ReySettings reySettings = new ReySettings(){
                    Position = new Vector3(PosEntity2d.X, PosEntity2d.Y, entity.Position.Z),
                    angle = ReyAngle,
                    originAngle = ReyAngle,
                    entityAngle = entity.Angle.X,
                    depth = depth
                };

                result[i] = ReyPush(reySettings);
            }

            return result;
        }

        //internal function for emitting rays
        private Rey ReyPush(ReySettings settings) {

            Rey ReyVertical = new Rey();
            Rey ReyHorizontal = new Rey();

            if (MathF.Sin((settings.angle * MathF.PI) / 180) > 0) {
                if (MathF.Cos((settings.angle * MathF.PI) / 180) > 0) {
                    ReyVertical = ReyPushStrategy(new ReySettings(settings).SetStrategy(leftReyStrategic));
                    ReyHorizontal = ReyPushStrategy(new ReySettings(settings).SetStrategy(topReyStrategic));
                }
                else {
                    ReyVertical = ReyPushStrategy(new ReySettings(settings).SetStrategy(topReyStrategic));
                    ReyHorizontal = ReyPushStrategy(new ReySettings(settings).SetStrategy(rightReyStrategic));
                }
            }
            else {
                if (MathF.Cos((settings.angle * MathF.PI) / 180) < 0) {
                    ReyVertical = ReyPushStrategy(new ReySettings(settings).SetStrategy(rightReyStrategic));
                    ReyHorizontal = ReyPushStrategy(new ReySettings(settings).SetStrategy(downReyStrategic));
                }
                else {
                    ReyVertical = ReyPushStrategy(new ReySettings(settings).SetStrategy(downReyStrategic));
                    ReyHorizontal = ReyPushStrategy(new ReySettings(settings).SetStrategy(leftReyStrategic));
                }
            }

            //ReyVertical = GetDistance(settings.Position, ReyVertical, ((settings.angle - settings.entityAngle) * MathF.PI) / 180);
            //ReyHorizontal = GetDistance(settings.Position, ReyHorizontal, ((settings.angle - settings.entityAngle) * MathF.PI) / 180);


            //length check between vertical and horizontal reys
            return Rey.HitDistribution(ReyHorizontal, ReyVertical, settings);
        }

        //function iterates beam radiation
        private Rey ReyPushStrategy(ReySettings settings) {
            Rey result = new Rey();

            Vector2 reyPos = settings.strategy.StartReyPos(settings.Position.Xy, settings.angle);
            char reyWall = ' ';

            for (int i = 0; i < settings.depth; i++) {

                if (reyPos.X < 0 || reyPos.Y < 0 || reyPos.Y > level.Size.Y - 1|| reyPos.X > level.Size.X - 1) {
                    result.Hit(new HitWall() {
                        ReyDistance = GetDistance(reyPos, settings.Position.Xy),
                        ReyPoint = reyPos,
                        Wall = '0'
                    });
                    return result;
                }

                reyWall = level.Map[(int)reyPos.Y, (int)reyPos.X]; 
                

                if (!Level.IsVoid(reyWall)) {

                    HitWall hit = new HitWall(reyPos);

                    if (Level.Ishalf(reyWall))
                        hit.ReyPoint += settings.strategy.NextReyPos(settings.angle) / 2;
                    
                    hit.ReyDistance = GetDistance(hit.ReyPoint, settings.Position.Xy);
                    hit.offset = settings.strategy.GetOfset(hit.ReyPoint);
                    hit.Wall = reyWall;

                    result.Hit(hit);

                    if (!Level.IsTransparent(reyWall) || !isTransparantTextures)
                        return result;

                }

                result.Hit(new HitFlore(){
                    ReyDistance = GetDistance(
                        new Vector3(reyPos.X, reyPos.Y, 0), 
                        settings.Position
                    ),
                    ReyPoint = reyPos,
                    Wall = reyWall,
                });

                reyPos += settings.strategy.NextReyPos(settings.angle);

            }

            result.Hit(new HitWall(){
                ReyDistance = GetDistance(
                    new Vector3(reyPos.X, reyPos.Y, 0),
                    settings.Position
                ),
                ReyPoint = reyPos,
                Wall = '0'
            });

            return result;
        }

        //length check between vertical and horizontal beam reys

        private float GetDistance(Vector2 PosA, Vector2 PosB) {
            return MathF.Abs(MathF.Sqrt(MathF.Pow(PosA.X - PosB.X, 2) + MathF.Pow(PosA.Y - PosB.Y, 2)));
        }

        private float GetDistance(Vector3 PosA, Vector3 PosB){
            return MathF.Abs(MathF.Sqrt(MathF.Pow(PosA.X - PosB.X, 2) + MathF.Pow(PosA.Y - PosB.Y, 2) + MathF.Pow(PosA.Z - PosB.Z, 2)));
        }

    }

    

    

}