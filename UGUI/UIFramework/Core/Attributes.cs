using System;

public class ControllerType : Attribute
{
    public enum Type
    {
        Modul,
        Window
    }


    public Type type;
    public ControllerType(Type type)
    {
        this.type = type; ;
    }
}

public class NoStaticTop : Attribute
{ }