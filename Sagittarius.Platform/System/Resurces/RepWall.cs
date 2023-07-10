namespace Sagittarius.Platform;

class RepWall{

    public string pathTextureH { get; set; }
    public string pathTextureV { get; set; }

    public string Name { get; set; }
    public int Id { get; set; }
    public bool isVoid { get; set; }
    public Core.Half Half { get; set; }
    public bool isTransparent { get; set; }
    public bool isCollision { get; set; }

    public Wall GetWall() {
        return new Wall() {
            textureHprizontal = ResurseMeneger.LoadColorBuffer(FileSystem.GetPath(pathTextureH)),
            textureVertical = ResurseMeneger.LoadColorBuffer(FileSystem.GetPath(pathTextureV)),

            Name = Name,
            Id = Id,
            isVoid = isVoid,
            Half = Half,
            isTransparent = isTransparent,
            isCollision = isCollision,
        };
    }
}
