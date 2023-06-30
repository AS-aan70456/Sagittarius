using OpenTK.Mathematics;


namespace Sagittarius.Core.Reycasting{
    public struct HitWall : Hit{

        public HitWall(Vector2 Point) {
            ReyPoint = Point;
            ReyDistance = 0;
            offset = 0;
            Wall = '0';
        }

        public Vector2 ReyPoint { get; set; }
        public float ReyDistance { get; set; }
        public char Wall { get; set; }

        public float offset { get; set; }
    }
}
