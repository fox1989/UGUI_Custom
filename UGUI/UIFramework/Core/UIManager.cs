using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public static UIManager Ins;

    [NonSerialized]
    public string startScene = "";


    List<ControllerBase> uiList = new List<ControllerBase>();

    private void Awake()
    {
        if (Ins == null)
            Ins = this;
        DontDestroyOnLoad(gameObject);
    }


    private void Start()
    {
        if (startScene == "")
            startScene = SceneManager.GetActiveScene().name;
        InitList();
    }



    private void InitList()
    {
        CreateFirst(new Test1Controller());
    }




    ControllerBase CreateFirst(ControllerBase controller)
    {

        if (uiList != null)
        {
            foreach (var item in uiList)
            {
                item.DoDestroy();
            }
            uiList.Clear();
        }
        else
            uiList = new List<ControllerBase>();

        controller.Init();
        uiList.Add(controller);
        return controller;
    }


    /// <summary>
    /// 创建一个UI 模块
    /// </summary>
    /// <param name="controller"></param>
    public ControllerBase Next(ControllerBase controller)
    {

        controller.Init();

        if (Curr != null)
        {
            if (Curr.type == MoudleType.window && controller.type == MoudleType.moulde)
            {

                for (int i = uiList.Count - 1; i >= 0; i--)
                {
                    if (uiList[i].viewBase.gameObject.activeInHierarchy)
                        uiList[i].Hide();

                    if (uiList[i].type == MoudleType.moulde)
                        break;
                }
            }
            else if (Curr.type == controller.type)
                uiList[uiList.Count - 1].Hide();

        }
        uiList.Add(controller);
        return controller;
    }




    /// <summary>
    /// 当前模块
    /// </summary>
    public ControllerBase Curr
    {
        get
        {
            if (uiList.Count > 0)
                return uiList[uiList.Count - 1];
            return null;
        }
    }



    /// <summary>
    /// 返回上一个UI
    /// </summary>
    public void Back()
    {
        if (uiList.Count > 1)
        {
            ControllerBase controller = uiList[uiList.Count - 1];
            uiList.RemoveAt(uiList.Count - 1);
            controller.Back();
            if (Curr != null)
            {
                Curr.Show();

                if (Curr.type == MoudleType.window)
                {
                    for (int i = uiList.Count - 1; i >= 0; i--)
                    {
                        if (uiList[i].type == MoudleType.moulde)
                        {
                            uiList[i].Show();
                            break;
                        }
                    }
                }
            }
        }
        else
        {
            Debug.LogError("没有更多的UI了");

        }
    }

    /// <summary>
    /// 延迟执行
    /// </summary>
    /// <param name="time"></param>
    /// <param name="action"></param>
    /// <param name="mono"></param>
    public void Delay(float time, Action action, MonoBehaviour mono = null)
    {
        if (mono != null)
            mono.StartCoroutine(DelayExecuate(time, action));
        else
            StartCoroutine(DelayExecuate(time, action));
    }

    IEnumerator DelayExecuate(float t, Action action)
    {
        yield return new WaitForSeconds(t);
        if (action != null)
            action();
    }

    /// <summary>
    /// 是否在NGUI上
    /// </summary>
    /// <returns></returns>
    public bool IsTouchedUI()
    {
        bool touchedUI = false;
        if (Application.isMobilePlatform)
        {
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                touchedUI = true;
            }
        }
        else if (EventSystem.current.IsPointerOverGameObject())
        {
            touchedUI = true;
        }
        return touchedUI;
    }

}
