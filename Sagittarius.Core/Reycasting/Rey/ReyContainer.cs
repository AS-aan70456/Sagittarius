﻿using OpenTK.Mathematics;
using System.Collections.Generic;


namespace Sagittarius.Core.Reycasting
{
    public interface ReyContainer{

        IEnumerable<Hit> GetFloreHit();
        IEnumerable<Hit> GetWallHit();

        Hit GetLastHit(Hit type);
        Hit GetFirstHit(Hit type);
    }
}
