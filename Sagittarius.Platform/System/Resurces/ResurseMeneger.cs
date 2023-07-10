using Sagittarius.Graphics;
using Sagittarius.Platform.System.Resurces;

namespace Sagittarius.Platform;

public static class ResurseMeneger{

    private static List<Info<ColorsBuffer>> colorBuffer;
    private static List<Info<Texture>> textures;
    private static List<Info<Wall>> walls;

    public static void Init() {
        colorBuffer = new List<Info<ColorsBuffer>>();
        textures = new List<Info<Texture>>();
        walls = new List<Info<Wall>>();
    }

    public static ColorsBuffer LoadColorBuffer(string path){
        foreach (var el in colorBuffer)
            if (el.name == path)
            {
                Loger.WriteLine($"Path({path}) is occupations", LogMessageType.Warning);
                return (ColorsBuffer)el.instance;
            }

        if (FileSystem.Exits(path)) Loger.WriteLine($"File not found: {path}", LogMessageType.Fatal);

        ColorsBuffer result = new ColorsBuffer(path);

        colorBuffer.Add(new Info<ColorsBuffer>(path, result));

        return result;
    }


    public static Wall LoadWall(string path){
        foreach (var el in walls)
            if (el.name == path)
            {
                Loger.WriteLine($"Name({path}) is occupations", LogMessageType.Warning);
                return (Wall)el.instance;
            }

        if (FileSystem.Exits(path)) 
            Loger.WriteLine($"File not found: {path}", LogMessageType.Fatal);

        RepWall rep = FileSystem.ReadObject<RepWall>(path);
        Wall result = rep.GetWall();

        walls.Add(new Info<Wall>(path, result));

        Loger.WriteLine($"File '{result.Name}' is load: ", LogMessageType.Good);

        return result;
    }

    public static Wall GetWall(string name){
        foreach (var el in walls)
            if (el.instance.Name == name)
                return (Wall)el.instance;
        Loger.WriteLine($"Info is not found: {name}", LogMessageType.Fatal);
        return null;
    }

    public static Wall GetWall(int id){
        foreach (var el in walls)
            if (el.instance.Id == id)
                return (Wall)el.instance;
        Loger.WriteLine($"Info is not found: {id}", LogMessageType.Fatal);
        return null;
    }

}
