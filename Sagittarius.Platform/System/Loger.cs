
namespace Sagittarius.Platform;

public enum LogMessageType
{
    Message,
    Error,
    Fatal,
    Warning,
    Good
}

static class Loger
{

    private static ConsoleColor[] ListColorType = {
        ConsoleColor.White,
        ConsoleColor.Red,
        ConsoleColor.DarkRed,
        ConsoleColor.Yellow,
        ConsoleColor.Green
    };

    public static void WriteLine(int strInt) => Loger.WriteLine(strInt.ToString());
    public static void WriteLine(float strInt) => Loger.WriteLine(strInt.ToString());
    public static void WriteLine(string str) => Loger.WriteLine(str.ToString(), "Platform.log", LogMessageType.Message);
    public static void WriteLine(string str, string path) => Loger.WriteLine(str.ToString(), path, LogMessageType.Message);
    public static void WriteLine(string str, LogMessageType type) => Loger.WriteLine(str.ToString(), "Platform.log", type);

    public static void WriteLine(string str, string path, LogMessageType type){
        LogConsole(str, ListColorType[(int)type]);
        FileSystem.WriteFile($"[{DateTime.Now}] {str}", "Platform.log", FileMode.Append);
    }

    private static void LogConsole(string str, ConsoleColor color){
        str = $"[{DateTime.Now}] {str}";

        Console.ForegroundColor = color;
        Console.WriteLine(str);
        Console.ForegroundColor = ConsoleColor.White;
    }

}
