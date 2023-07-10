using OpenTK.Mathematics;
using System.Collections.Generic;


namespace Sagittarius.Core
{
    public interface ReyContainer{

        IEnumerable<Hit> GetFloreHit();
        IEnumerable<Hit> GetWallHit();

        Hit GetLastHit(Type type);
        Hit GetFirstHit(Type type);
    }
}
