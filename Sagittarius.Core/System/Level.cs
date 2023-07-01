﻿using OpenTK.Mathematics;
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

        this.Map = Map;
        this.Size = Size;
        this.SpawnPoint = SpawnPoint;

        Void = new char[] { ' ' };
        Transparent = new char[] { '3', '5' };
        Collision = new char[] { '0', '1', '2', '3', '4' };
        Half = new char[] { '3', '4', '5' };
    }

    public void AddEntity(BaseEntity Entitie) {
        Entities.Add(Entitie);
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
