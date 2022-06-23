using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MoudleType
{
    moulde,
    window
}

public abstract class ControllerBase
{

    public ViewBase viewBase;

    public MoudleType type;

    public ControllerBase()
    {
        this.type = MoudleType.moulde;
    }

    public ControllerBase(MoudleType type)
    {
        this.type = type;
    }


    public virtual void Init()
    { }


    public virtual void Hide()
    { }

    public virtual void Show()
    { }

    public virtual void Back()
    {
    }

    public virtual void DoDestroy()
    {
    }
}

