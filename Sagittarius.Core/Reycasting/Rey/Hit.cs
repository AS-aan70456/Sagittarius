using SFML.System;

namespace Sagittarius.Core.Reycasting
{
    public interface Hit {

        public Vector2f ReyPoint { get; set; }
        public float ReyDistance { get; set; }
        public char Wall { get; set; }

    }
}