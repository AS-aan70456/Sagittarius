using OpenTK.Mathematics;

namespace Sagittarius.Core.Dungeons;
class Chank{

    public Vector2i Position { get; private set; }

    private Room room;

    public Room Room { 
        get {
            if (room != null)
                return room;
            else
                return new Room();
        }
        set { room = value; }
    }

    public Chank(Vector2i Position) {
        this.Position = Position;
    }

}
