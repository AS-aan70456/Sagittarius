using OpenTK.Mathematics;
using System;
using System.Collections.Generic;

namespace Sagittarius.Core;

#pragma warning disable CS8618

public class Level{

    private List<BaseEntity> Entities;

    public Vector2i SpawnPoint { get; private set; }

    public Vector2i Size { get; private set; }
    public char[,] Map { get; set; }

    private static char[] Void;
    private static char[] Half;
    private static char[] Transparent;
    private static char[] Collision;

    public char this[int i, int j] { get { return Map[i, j]; } }

    public Level(char[,] Map, Vector2i Size, Vector2i SpawnPoint){
        Entities = new List<BaseEntity>();

        this.Map = Map;
        this.Size = Size;
        this.SpawnPoint = SpawnPoint;

        Void = new char[] { ' ' };
        Transparent = new char[] { '3', '5' };
        Collision = new char[] { '0', '1', '2' };
        Half = new char[] { '3', '4', '5' };
    }

    public void AddEntity(BaseEntity Entitie) {
        Entities.Add(Entitie);
    }

    public void UpdataLevel(double args) {

        foreach (var el in Entities)
            ColisionEntity(el);



    }

    private void ColisionEntity(BaseEntity Entities) {

        float offsetX = 0;
        float offsetY = 0;

        Vector2 Center = Entities.movePosition.Xy + Entities.Size;

        for (int i = (int)(Entities.Position.Y) ; i < (Entities.Position.Y + Entities.Size.Y) ; i++){
            for (int j = (int)(Entities.movePosition.X); j < (Entities.movePosition.X + Entities.Size.X); j++){
                if (Level.IsCollision(this[i, j])){
                    float dx1 = MathF.Abs(j - Center.X);
                    float dx2 = MathF.Abs((j + 1) - Center.X);

                    if (dx2 < dx1)
                        offsetX = Math.Abs((MathF.Ceiling(Entities.movePosition.X) - Entities.movePosition.X));
                    else 
                        offsetX = ((MathF.Ceiling(Entities.movePosition.X) - Entities.movePosition.X) - Entities.Size.X);                    
                }
            }
        }

        Entities.movePosition += new Vector3(offsetX, 0, 0);

        for (int i = (int)(Entities.movePosition.Y); i < (Entities.movePosition.Y + Entities.Size.Y); i++){
            for (int j = (int)(Entities.movePosition.X); j < (Entities.movePosition.X + Entities.Size.X); j++){
                if (Level.IsCollision(this[i, j])){
                    float dy1 = MathF.Abs(i - Center.Y);
                    float dy2 = MathF.Abs((i + 1) - Center.Y);

                    if (dy2 < dy1)
                        offsetY = Math.Abs((MathF.Ceiling(Entities.movePosition.Y) - Entities.movePosition.Y));
                    else
                        offsetY = ((MathF.Ceiling(Entities.movePosition.Y) - Entities.movePosition.Y) - Entities.Size.Y);
                }
            }
        }
        
        Entities.movePosition += new Vector3(0, offsetY, 0);
        
    }

    public static bool IsVoid(char Cell){
        for (int i = 0; i < Void.Length; i++) if (Cell == Void[i]) return true; return false;
    }

    public static bool IsTransparent(char Cell){
        for (int i = 0; i < Transparent.Length; i++) if (Cell == Transparent[i]) return true; return false;
    }

    public static bool IsCollision(char Cell){
        for (int i = 0; i < Collision.Length; i++) if (Cell == Collision[i]) return true; return false;
    }

    public static bool Ishalf(char Cell){
        for (int i = 0; i < Half.Length; i++) if (Cell == Half[i]) return true; return false;
    }
}
