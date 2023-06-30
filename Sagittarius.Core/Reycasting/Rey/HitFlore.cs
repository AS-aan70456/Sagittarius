using OpenTK.Mathematics;


namespace Sagittarius.Core
{
    public struct HitFlore : Hit {
        public Vector2 ReyPoint { get; set; }
        public float ReyDistance { get; set; }
        public char Wall { get; set; }
    }
}
