using OpenTK.Mathematics;
using System;

namespace Sagittarius.Core{
    public class EntitySettings{

        public Vector3 Position { get; set; }
        public Vector2 Size { get; set; }
        public Vector2 Angle { get; set; }

        public int Hp { get; set; }
        public int MAX_HP { get; set; }

        public bool IsColision { get; set; }
        public bool IsLife { get; set; }

        public Level Level { get; set; }

    }
}
