using OpenTK.Mathematics;

namespace Sagittarius.Core.Reycasting{
    interface IStrategyReyCanculate{

        Vector2 StartReyPos(Vector2 Position, float angle);
        Vector2 NextReyPos(float angle);
        float GetOfset(Vector2 pos);
        Vector2 GetSide();
    }
}
