using Sagittarius.Platform;
using System.Reflection;

#pragma warning disable CS8601

class dll
{

    object findDllClass = null;
    Type findClassType = null;
    Type[] ListTypes = null;

    public dll(string path) {
        if (File.Exists(path)){
            Assembly Ass = Assembly.LoadFile(path);
            ListTypes = Ass.GetTypes();
            Loger.WriteLine("Include dll", LogMessageType.Good);
        }
        else {
            Loger.WriteLine("Failed to include dll. error", LogMessageType.Fatal);
        }
    }
    public dllClass DllClass(string FindClass) => DllClass(FindClass, null);

    public dllClass DllClass(string FindClass, params object[] argsClass) {
        findDllClass = null;
        if (ListTypes == null) return null;

        foreach (Type type in ListTypes){
            if (type.FullName.Equals(FindClass)) {
                 findClassType = type;

                if (argsClass != null)
                    findDllClass = Activator.CreateInstance(findClassType, argsClass);
                else
                    findDllClass = Activator.CreateInstance(findClassType);
                
            }
        }

        if (findDllClass == null)
            Loger.WriteLine("Plugin" + FindClass + " not find");

        return new dllClass(findClassType, findDllClass);
    }
    

}
