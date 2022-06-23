using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class GameTools
{

    public static GameObject Load(string path)
    {
        return (GameObject)Resources.Load(path);
    }


}

