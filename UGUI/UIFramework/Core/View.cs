using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View<T> : ViewBase where T : ControllerBase
{
    private T controller;

    public T Controller
    {
        get
        {
            if (controller == null)
                controller = controllerBase as T;
            return controller;
        }
    }

    public void Back()
    {
        UIManager.Ins.Back();
    }

}
