using OpenTK.Mathematics;
using Sagittarius.Core.Reycasting;

namespace Sagittarius.Core{
    public class Camera : BaseEntity{

        public ReyContainer[] reyContainer { get; private set; }
        private ReyCastService ReyCastService;

        public uint countRey;
        public uint depth;
        public uint fov;

        public Camera(EntitySettings settings, Level level) : base(settings) {
            ReyCastService = new ReyCastService(level, true);
            reyContainer = new ReyContainer[0];
        }

        public void Look() {
            reyContainer = ReyCastService.ReyCastWall(this, fov, depth, countRey);
        }

        public void Attach(ref Vector3 Position) => base.Position = Position;

    }
}
