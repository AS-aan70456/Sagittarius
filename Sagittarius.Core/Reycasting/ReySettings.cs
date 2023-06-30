using OpenTK.Mathematics;
using Sagittarius.Core.Reycasting;
using System;


namespace Sagittarius.Core{
    class ReySettings{
        public IStrategyReyCanculate strategy { get; private set; }
        public Vector3 Position { get; set; }
        public float angle { get; set; }
        public float originAngle { get; set; }
        public float entityAngle { get; set; }
        public float depth { get; set; }

        public ReySettings(){}

        public ReySettings(ReySettings settings) {
            Position = settings.Position;
            angle = settings.angle;
            entityAngle = settings.entityAngle;
            originAngle = settings.originAngle;
            depth = settings.depth;
        }

        public ReySettings SetStrategy(IStrategyReyCanculate strategy)
        {
            this.strategy = strategy;
            if (strategy.GetType() == new LeftRey().GetType())
                angle = -(angle + 90);
            else if (strategy.GetType() == new RightRey().GetType())
                angle = -(angle - 90);
            else if (strategy.GetType() == new DownRey().GetType())
                angle -= 180;
            return this;
        }
    }
}
