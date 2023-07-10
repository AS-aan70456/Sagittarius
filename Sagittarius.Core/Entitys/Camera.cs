using OpenTK.Mathematics;
using Sagittarius.Core.Reycasting;
using Sagittarius.Graphics;

namespace Sagittarius.Core{
    public class Camera : BaseEntity{
        
        public ReyContainer[] reyContainer { get; private set; }
        private ReyCastService ReyCastService;

        public Vector2 Center { get { return Position.Xy + (Size / 2); } }

        public uint countRey;
        public uint depth;
        public uint fov;

        public Camera(EntitySettings settings, Level level) : base(settings) {
            ReyCastService = new ReyCastService(level, true);
            reyContainer = new ReyContainer[0];

        }

        public void Attach(ref Vector3 Position) => base.position = Position;

        public override void Update(double args){
            reyContainer = ReyCastService.ReyCastWall(this, fov, depth, countRey);
        }

    }
}
