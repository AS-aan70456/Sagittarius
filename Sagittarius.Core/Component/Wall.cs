using Sagittarius.Graphics;

namespace Sagittarius.Core;

public enum Half {Fill, VerticalHalf, HorizontalHalf };

public class Wall{
    //private set;
    public ColorsBuffer textureHprizontal { get; set; }
    public ColorsBuffer textureVertical { get; set; }

    public string Name { get; set; }
    public int Id { get; set; }
    public bool isVoid { get; set; }
    public Half Half { get; set; }
    public bool isTransparent { get; set; }
    public bool isCollision { get; set; }

}
