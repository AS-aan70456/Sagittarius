using OpenTK.Mathematics;


namespace Sagittarius.Core{
    public struct HitWall : Hit{

        public HitWall(Vector2 Point) {
            ReyPoint = Point;
            ReyDistance = 0;
            offset = 0;
            Wall = null;
        }

        public Vector2 ReyPoint { get; set; }
        public float ReyDistance { get; set; }
        public Wall Wall { get; set; }

        public float offset { get; set; }
    }
}
