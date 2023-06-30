using OpenTK.Mathematics;
using Sagittarius.Core.Reycasting;
using System;

namespace Sagittarius.Core;

class LeftRey : IStrategyReyCanculate{

    public Vector2 StartReyPos(Vector2 Position, float angle)
    {

        Vector2 deltePosition = new Vector2()
        {
            X = (Position.X - (int)Position.X),
            Y = (Position.Y - (int)Position.Y)
        };

        Position.X += -deltePosition.X;
        Position.Y += ((-deltePosition.X) / MathF.Tan((angle * MathF.PI) / 180));

        Position -= new Vector2(0.00001f, 0.00001f);

        return Position;
    }

    public Vector2 NextReyPos(float angle)
    {
        return new Vector2(
            -1f,
            -(1f / MathF.Tan((angle * MathF.PI) / 180))
        );
    }

    public float GetOfset(Vector2 pos)
    {
        return (float)(pos.Y - (int)pos.Y);
    }

    public Vector2 GetSide()
    {
        return new Vector2(-1, 0);
    }
}
