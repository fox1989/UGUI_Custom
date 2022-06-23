using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller<T> : ControllerBase where T : ViewBase
{
    private T view;

    public T View
    {
        get
        {
            if (view == null)
                view = viewBase as T;
            return view;
        }
    }

    public string PrefabPath
    {
        get
        {
            string name = GetType().Name.Replace("Controller", "");
            return "UIPrefab/" + name + "/Prefab_" + name;
        }
    }


    /// <summary>
    /// 初始化
    /// </summary>
    public override void Init()
    {

        if (type == MoudleType.moulde)
            StaticModelController.CheckHideTop(this);


        GameObject viewGo = GameObject.Instantiate(GameTools.Load(PrefabPath), UIManager.Ins.transform);
        if (viewGo == null)
        {
            Log.E("Path is Null  path:" + PrefabPath);
            return;
        }

        viewGo.name = GetType().Name + "(" + type + ")";
        viewGo.transform.localPosition = Vector3.zero;
        viewBase = viewGo.GetComponent<ViewBase>();
        viewBase.controllerBase = this;
        Show();

    }

    public override void Show()
    {
        View.gameObject.SetActive(true);
    }


    public override void Hide()
    {
        View.gameObject.SetActive(false);
    }



    public override void Back()
    {
        OnBack();
        DoDestroy();
    }



    public virtual void OnBack()
    {

    }


    public override void DoDestroy()
    {
        GameObject.Destroy(View.gameObject);
    }

}
