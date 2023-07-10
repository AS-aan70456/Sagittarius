namespace Sagittarius.Platform.System.Resurces;

class Info<T>
{

    public string name { get; }
    public T instance { get; }

    public Info(string name, T instance) { this.name = name; this.instance = instance; }
}
