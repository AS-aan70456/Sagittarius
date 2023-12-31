﻿using OpenTK.Mathematics;
using Sagittarius.Core.Reycasting;
using System;

namespace Sagittarius.Core;

class TopRey : IStrategyReyCanculate
{

    public Vector2 StartReyPos(Vector2 Position, float angle)
    {
        Vector2 deltePosition = new Vector2()
        {
            X = (Position.X - (int)Position.X),
            Y = (Position.Y - (int)Position.Y),
        };

        Position.X += ((-deltePosition.Y) / MathF.Tan((angle * MathF.PI) / 180));
        Position.Y += -deltePosition.Y;

        Position -= new Vector2(0.00001f, 0.00001f);

        return Position;
    }

    public Vector2 NextReyPos(float angle)
    {
        return new Vector2(
            -(1f / MathF.Tan((angle * MathF.PI) / 180)),
            -1f
        );
    }

    public float GetOfset(Vector2 pos)
    {
        return (float)(pos.X - (int)pos.X);
    }

    public Vector2 GetSide()
    {
        return new Vector2(0, -1);
    }
}
