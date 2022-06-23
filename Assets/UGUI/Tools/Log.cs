using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Log
{

    public static void I(string info)
    {
        print("i:" + info);
    }

    public static void T(string info)
    {
        print("t:" + DateTime.Now.ToString() + " :" + info);
    }

    public static void E(string info)
    {
        UnityEngine.Debug.LogError("e:" + info);
    }


    static void print(string info)
    {
        UnityEngine.Debug.Log(info);
    }

}

