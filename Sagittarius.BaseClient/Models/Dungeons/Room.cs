namespace Sagittarius.BaseClient.Model;

#pragma warning disable CS8618 

class Room
{

    public Vector2i Position { get; set; }
    public Vector2i Size { get; private set; }
    public Vector2i Center { get { return(Position + (Size / 2)); } }

    public Wall[,] Structure { get; private set; }

    public Room(){
        Position = new Vector2i();
        Size = new Vector2i();
    }

    public static Room GenerateRoom(Vector2i Size, Vector2i chankPos, int chankSize) {
        Room room = new Room();

        room.Structure = new Wall[Size.X, Size.Y];
        room.Size = Size;
        room.Position = new Vector2i(chankPos.X + ((chankSize - Size.X) / 2), chankPos.Y + ((chankSize - Size.Y) / 2));



        for (int i = 0; i < Size.Y; i++){
            for (int j = 0; j < Size.X; j++){
                if (i == 0 || j == 0 || i == Size.Y - 1 || j == Size.X - 1){
                    room.Structure[j, i] = ResurseMeneger.GetWall("Wall"); 

                }
                else{
                    room.Structure[j, i] = ResurseMeneger.GetWall("Void");
                }
            }
        }

        return room;
    }

    public bool CheckColisionRoom(List<Room> rooms) {
        foreach (var room in rooms) if (TooCloseTo(room))
                return true;
        return false;
    }

    private bool TooCloseTo(Room room){
        return ((Position.X > room.Position.X && Position.X < room.Position.X + room.Size.Y) || (room.Position.X > room.Position.X && Position.X < Position.X + Size.Y)) &&
            ((Position.Y > room.Position.Y && Position.Y < room.Position.Y + room.Size.X) || (room.Position.Y > room.Position.Y && Position.Y < Position.Y + Size.X));
            
    }
}
