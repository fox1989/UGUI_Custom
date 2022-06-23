using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PoolManager : MonoBehaviour
{
    private static PoolManager ins;

    public static PoolManager Ins
    {
        get
        {
            if (ins == null)
            {
                GameObject go = new GameObject("PoolManager");
                ins = go.AddComponent<PoolManager>();
                DontDestroyOnLoad(go);
            }
            return ins;
        }
    }



    Dictionary<string, ObjectPool> pools = new Dictionary<string, ObjectPool>();


    public bool AddPool(GameObject go)
    {
        string key = go.name;

        if (pools.ContainsKey(key))
        {
            Log.E("对象池已经存在~");
            return false;
        }
        else
        {
            pools.Add(key, new ObjectPool(go));
        }
        return true;
    }


    public GameObject Get(string key)
    {
        if (!pools.ContainsKey(key))
        {
            GameObject go = Resources.Load(key) as GameObject;
            if (go != null)
            {
                go.name = key;
                AddPool(go);
            }
            else
            {
                Log.E("对象池不存在"+":"+key);
                return null;
            }
        }
        return pools[key].GetObject();
    }

    public GameObject Get(GameObject go)
    {
        string key = go.name;
        if (!pools.ContainsKey(key))
        {
            pools.Add(key, new ObjectPool(go));
        }
        return Get(key);
    }



    public void Recycle(GameObject go)
    {
        if (go == null)
        {
            Log.E("go is null");
            return;
        }

        string key = go.name;
        if (!pools.ContainsKey(key))
        {
            Log.E("对象池不存在");
            return;
        }
        pools[key].Recycle(go);
    }

    public void Recycle(List<GameObject> list)
    {
        if (list != null && list.Count >= 0)
        {

            foreach (var go in list)
            {
                Recycle(go);
            }
        }
        list.Clear();
    }


    public void Clear(string name)
    {
        string key = name;
        if (!pools.ContainsKey(key))
        {
            Log.E("对象池不存在");
            return;
        }
        pools[key].Clear();
    }

}



public class ObjectPool
{

    GameObject prefab;

    Queue<GameObject> gameObjects;

    public ObjectPool(GameObject gameObject)
    {
        prefab = gameObject;
        gameObjects = new Queue<GameObject>();
    }



    public GameObject GetObject()
    {
        GameObject reGo;
        if (gameObjects.Count <= 0)
        {
            reGo = GameObject.Instantiate(prefab);
            reGo.name = prefab.name;

        }
        else
            reGo = gameObjects.Dequeue();
        reGo.SetActive(true);
        return reGo;
    }

    public void Recycle(GameObject go)
    {
        go.SetActive(false);
        go.transform.parent = PoolManager.Ins.transform;
        go.transform.localPosition = Vector3.zero;
        gameObjects.Enqueue(go);
    }

    public void Clear()
    {
        foreach (var item in gameObjects)
        {
            Object.Destroy(item);
        }
        gameObjects.Clear();
    }
}
