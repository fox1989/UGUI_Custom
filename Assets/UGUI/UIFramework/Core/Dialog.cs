using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Dialog : MonoBehaviour
{


    public Text title;
    public Text content;

    private Action onYes;
    public Action onNo;
    static Dialog ins;
    static Dialog Ins
    {
        get
        {
            if (ins == null)
                ins = UIManager.Ins.transform.Find("Dialog").GetComponent<Dialog>();
            return ins;
        }
        set { ins = value; }
    }



    public static void Show(string content, string title = "", Action yes = null, Action no = null)
    {

        if (Ins == null)
        {
            Debug.LogError("Error: Dialog Ins is null");
            return;
        }

        Ins.title.text = title;
        Ins.content.text = content;
        Ins.onYes = yes;
        Ins.onNo = no;
        Ins.gameObject.SetActive(true);
    }




    public void OnYes()
    {
        if (onYes != null)
            onYes();
        Hide();
    }

    public void OnNo()
    {
        if (onNo != null)
            onNo();
        Hide();
    }


    private void Hide()
    {
        gameObject.SetActive(false);
    }

}
