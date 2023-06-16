﻿using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEngine.ReyCast{
    public struct HitFlore : Hit {
        public Vector2f ReyPoint { get; set; }
        public float ReyDistance { get; set; }
        public char Wall { get; set; }
    }
}
