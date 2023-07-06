using Sagittarius.Platform;
using System.Reflection;

#pragma  warning disable ;

class dllClass{

    private object classInstance;
    private Type type;

    public dllClass(Type type, object classInstance){
        this.classInstance = classInstance;
        this.type = type;
    }

    public object Method(string function) => Method(function, null);

    public object Method(string function, params object[] argsClass){
        object ret = null;
        MethodInfo mi = null;
        bool InvokeCorrect = false;

        try{
            if (classInstance != null){
                mi = classInstance.GetType().GetMethod(function);
                if (mi == null)
                    mi = classInstance.GetType().BaseType.GetMethod(function);
                if (mi == null)
                    mi = classInstance.GetType().BaseType.BaseType.GetMethod(function);
                if (mi != null){
                    ret = mi.Invoke(classInstance, argsClass);
                    InvokeCorrect = true;
                }
            }
        }
        catch{
            ret = null;
        }

        if (!InvokeCorrect)
            Loger.WriteLine(String.Format("{0}.{1} error in Plugin {2}", (classInstance != null) ? classInstance.GetType().Name : "null", function, (mi == null) ? "or function not find" : ""));
        
        return ret;
    }

    
    public override string ToString() =>
        type.ToString();

    public Type GetInstanceType(){
        if (classInstance == null) return null;
        return classInstance.GetType();
    }
}

