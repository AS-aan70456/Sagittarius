using System;
using OpenTK.Mathematics;

namespace Sagittarius.Core{
    public class BaseEntity{

        public Vector3 movePosition { get; set; }

        public Vector3 Position { get; protected set; }
        public Vector2 Size { get; protected set; }
        public Vector2 Angle { get; protected set; }

        public int Hp { get; protected set; }
        public int MAX_HP { get; }

        public bool IsColision { get; private set; }
        public bool IsLife { get; private set; }

        public BaseEntity() {}

        public BaseEntity(EntitySettings settings) {
            Position = settings.Position;
            movePosition = settings.Position;
            Size = settings.Size;
            Angle = settings.Angle;

            Hp = settings.Hp;
            MAX_HP = settings.MAX_HP;

            IsColision = settings.IsColision;
            IsLife = settings.IsLife;
        }


        public void Move(float VelosityX, float VelosityY, double time) =>
            Move(new Vector2(VelosityX, VelosityY), time);

        public void Move(Vector2 velocity, double time){
            velocity *= (float)time;
            //velocity = velocity * Router.Init().graphicsControllers.time;
            float X = 0;
            float Y = 0;

            float X1 = 0;
            float Y1 = 0;

            X = ((float)((MathF.Cos((((Angle.X) * MathF.PI) / 180)) * velocity.X)));
            X1 = ((float)((MathF.Cos((((90 + Angle.X) * MathF.PI) / 180)) * velocity.Y)));

            Y = ((float)((MathF.Sin((((Angle.X) * MathF.PI) / 180)) * velocity.X)));
            Y1 = ((float)((MathF.Sin((((90 - Angle.X) * MathF.PI) / 180)) * velocity.Y)));

            Position = movePosition;

            movePosition -= new Vector3(0, Y, 0);
            movePosition -= new Vector3(0, Y1, 0);

            movePosition -= new Vector3(X, 0, 0);
            movePosition -= new Vector3(X1, 0, 0);
        }

        public bool TakeDamage(int Damage) {
            Hp -= Damage;

            if (Hp < 0) IsLife = false;

            return IsLife;
        }

        public void RotateX(float angle, double time) => this.Angle += new Vector2((float)(angle * time), 0);

        public void RotateY(float angle, double time) => this.Angle += new Vector2(0, (float)(angle * time));
        

    }
}
