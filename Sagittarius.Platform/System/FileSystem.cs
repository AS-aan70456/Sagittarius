using Newtonsoft.Json;
using System.IO.Compression;
using System.Reflection;

#pragma warning disable CS8600 
#pragma warning disable CS8603 

namespace Sagittarius.Platform;

public static class FileSystem{

    public static string GetPath(string path) =>
         AppDomain.CurrentDomain.BaseDirectory + path;

    public static bool Exits(string path) =>
         File.Exists(AppDomain.CurrentDomain.BaseDirectory + path);

    public static void WriteFile(string str, string path, FileMode fileMode){
        using (FileStream fileStream = new FileStream(GetPath(path), fileMode))
        using (StreamWriter file = new StreamWriter(fileStream))
            file.WriteLine(str);
    }

    public static void WriteObject<T>(T Object, string path){
        string json = JsonConvert.SerializeObject(Object);
        WriteFile(json, path, FileMode.OpenOrCreate);
    }

    public static T ReadObject<T>(string path){
        string json = File.ReadAllText(path);
        T objectJson = JsonConvert.DeserializeObject<T>(json);

        return objectJson;
    }


}

