using OpenTK.Mathematics;
using Sagittarius.Core.Reycasting;
using Sagittarius.Core.System;

namespace Sagittarius.Core.Entitys{
    public class Camera : BaseEntity{

        public ReyContainer[] reyContainer { get; private set; }

        private ReyCastService ReyCastService;

        public Camera(EntitySettings settings, Level level) : base(settings) {
            ReyCastService = new ReyCastService(level, true);
            reyContainer = new ReyContainer[0];
        }

        public void Look() {
            reyContainer = ReyCastService.ReyCastWall(this, 45, 16, 256);
        }

        public void Attach(ref Vector3 Position) => base.Position = Position;

    }
}
