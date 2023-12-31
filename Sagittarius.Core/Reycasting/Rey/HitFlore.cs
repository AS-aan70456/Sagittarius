﻿using OpenTK.Mathematics;


namespace Sagittarius.Core
{
    public class HitFlore : Hit {

        public HitFlore() { }

        public HitFlore(Vector2 Point) {
            ReyPoint = Point;
            ReyDistance = 0;
            
            Wall = null;
            Transplent = true;
        }
        

        public Vector2 ReyPoint { get; set; }
        public float ReyDistance { get; set; }
        public Wall Wall { get; set; }

        public bool Transplent { get; set; }
    }
}
