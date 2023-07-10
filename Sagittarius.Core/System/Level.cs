using OpenTK.Mathematics;
using Sagittarius.Graphics;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Sagittarius.Core;

#pragma warning disable CS8618

public class Level : IComponent, IRenderComponent{

    public List<IRenderItem> renderItems { get; set; }

    private List<BaseEntity> Entities;

    public Vector2i SpawnPoint { get; private set; }

    public Vector2i Size { get; private set; }
    public Wall[,] Map { get; set; }
    


    public Wall this[int i, int j] { get { return Map[i, j]; } }

    public Level(Wall[,] Map, Vector2i Size, Vector2i SpawnPoint){
        Entities = new List<BaseEntity>();

        this.Map = Map;
        this.Size = Size;
        this.SpawnPoint = SpawnPoint;

    }

    public void Start(){
        
    }

    public void AddEntity(BaseEntity Entitie) {
        Entities.Add(Entitie);
        Entitie.isMoved += ColisionEntity;
        Entitie.isDeleted += Unsubscribe;
    }

    public void Update(double args){

    }

    private void ColisionEntity(ref Vector3 Position, Vector2 prePosition, Vector2 Size) {

        float offsetX = 0;
        float offsetY = 0;

        Vector2 Center = prePosition + Size;

        for (int i = (int)(prePosition.Y) ; i < (prePosition.Y + Size.Y) ; i++){
            for (int j = (int)(Position.X); j < (Position.X + Size.X); j++){
                if (this[i, j].isCollision){
                    float dx1 = MathF.Abs(j - Center.X);
                    float dx2 = MathF.Abs((j + 1) - Center.X);

                    if (dx2 < dx1)
                        offsetX = Math.Abs((MathF.Ceiling(Position.X) - Position.X));
                    else 
                        offsetX = ((MathF.Ceiling(Position.X) - Position.X) - Size.X);                    
                }
            }
        }

        Position += new Vector3(offsetX, 0, 0);

        for (int i = (int)(Position.Y); i < (Position.Y + Size.Y); i++){
            for (int j = (int)(Position.X); j < (Position.X + Size.X); j++){
                if (this[i, j].isCollision){
                    float dy1 = MathF.Abs(i - Center.Y);
                    float dy2 = MathF.Abs((i + 1) - Center.Y);

                    if (dy2 < dy1)
                        offsetY = Math.Abs((MathF.Ceiling(Position.Y) - Position.Y));
                    else
                        offsetY = ((MathF.Ceiling(Position.Y) - Position.Y) - Size.Y);
                }
            }
        }

        Position += new Vector3(0, offsetY, 0);
        
    }

    private void Unsubscribe(BaseEntity Entitie) {
        Entitie.isMoved -= ColisionEntity;
        Entitie.isDeleted -= Unsubscribe;
    }


    public void End(){}

    public void Render(){}
}
