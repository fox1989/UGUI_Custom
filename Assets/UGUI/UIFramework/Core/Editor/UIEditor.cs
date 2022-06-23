using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UIEditor : EditorWindow
{
    public string ClassName;

    [MenuItem("Assets/CreateView")]
    static void Init()
    {
        //弹出窗口
        EditorWindow.GetWindow(typeof(UIEditor));
    }


    void OnGUI()
    {
        //在弹出窗口中控制变量
        ClassName = EditorGUILayout.TextField("Name", ClassName);

        //创建一个按钮
        if (GUILayout.Button("Create"))
        {
            CreateClass(ClassName);
            Close();
        }

        if (GUILayout.Button("Test"))
        {


        }

    }




    void CreateClass(string name)
    {

        string basePath = Application.dataPath + "/Scripts/UI/";


        string controllerPath = basePath + "Controllers/";
        string viewPath = basePath + "Views/";



        if (!Directory.Exists(controllerPath))
            Directory.CreateDirectory(controllerPath);

        if (!Directory.Exists(viewPath))
            Directory.CreateDirectory(viewPath);



        if (File.Exists(controllerPath + name + "Controller.cs"))
        {
            Debug.LogError("已经存在了" + name + "Controller.cs");
        }
        else
        {
            File.WriteAllText(controllerPath + name + "Controller.cs", controlerTemplate.Replace("{0}", name));
        }

        if (File.Exists(viewPath + name + "View.cs"))
        {
            Debug.LogError("已经存在了" + name + "View.cs");
        }
        else
        {
            File.WriteAllText(viewPath + name + "View.cs", viewTemplate.Replace("{0}", name));
        }

        AssetDatabase.Refresh();
        CreatePrefab(name);
    }



    void CreatePrefab(string name)
    {
        GameObject go = new GameObject(name);
        Canvas canvas = FindObjectOfType<Canvas>();
        go.transform.parent = canvas.transform;
        go.transform.localPosition = Vector3.zero;
        Image image = go.AddComponent<Image>();
        image.rectTransform.sizeDelta = canvas.GetComponent<RectTransform>().sizeDelta;
        Assembly assembly = Assembly.Load(Assembly.GetExecutingAssembly().GetName().Name.Replace("-Editor", ""));
        Type t = assembly.GetType(name + "View");
        go.AddComponent(t);
        PrefabUtility.SaveAsPrefabAssetAndConnect(go, Application.dataPath + "/Resources/UIPrefab/" + name + ".prefab", InteractionMode.AutomatedAction);

    }



    string controlerTemplate = @"using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class {0}Controller : Controller<{0}View>
{

}
";


    string viewTemplate = @"using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class {0}View : View<{0}Controller>
{

}";
}