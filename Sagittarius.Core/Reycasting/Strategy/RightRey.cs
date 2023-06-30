using OpenTK.Mathematics;
using System;

namespace Sagittarius.Core.Reycasting
{
    class RightRey : IStrategyReyCanculate
    {

        public Vector2 StartReyPos(Vector2 Position, float angle)
        {
            Vector2 deltePosition = new Vector2()
            {
                X = 1 - (Position.X - (int)Position.X),
                Y = 1 - (Position.Y - (int)Position.Y),
            };

            Position.X -= (-deltePosition.X);
            Position.Y -= (((-deltePosition.X)) / MathF.Tan((angle * MathF.PI) / 180));

            return Position;
        }

        public Vector2 NextReyPos(float angle)
        {
            return new Vector2(
                1f,
                (1f / MathF.Tan((angle * MathF.PI) / 180))
            );
        }

        public float GetOfset(Vector2 pos)
        {
            return (float)(pos.Y - (int)pos.Y);
        }

        public Vector2 GetSide() {
            return new Vector2(1, 0);
        }
    }
}
