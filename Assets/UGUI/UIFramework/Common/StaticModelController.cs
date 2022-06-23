using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticModelController
{

    static ControllerBase staticBC;


    public static void SetStaticController(ControllerBase bc)
    {
        if (staticBC != null)
            staticBC.DoDestroy();
        staticBC = bc;
    }

    public static void CheckHideTop(ControllerBase bc)
    {

        if (bc == staticBC)
            return;
        NoStaticTop st = (NoStaticTop)Attribute.GetCustomAttribute(bc.GetType(), typeof(NoStaticTop));

        if (st == null)
        {
            ShowStaticMoudle();
        }
        else
        {
            HideStaticMoudle();
        }
    }


    public static void UpdateInfo()
    {
        if (staticBC != null && staticBC.viewBase != null)
        {
        
        }
    }



    public static void ShowStaticMoudle()
    {
        if (staticBC != null)
        {
            staticBC.Show();
        }
    }

    public static void HideStaticMoudle()
    {
        if (staticBC != null)
        {
            staticBC.Hide();
        }
    }

}
