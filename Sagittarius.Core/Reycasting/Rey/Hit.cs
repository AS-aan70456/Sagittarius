using OpenTK.Mathematics;

namespace Sagittarius.Core
{
    public interface Hit {

        public Vector2 ReyPoint { get; set; }
        public float ReyDistance { get; set; }
        public Wall Wall { get; set; }

    }
}