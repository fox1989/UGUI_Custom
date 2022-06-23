using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ABEditor : MonoBehaviour
{

    [MenuItem("Tool/CreatAb")]
    public static void CreatAb()
    {
        string path = Application.dataPath.Replace("Assets", "ab");

        BuildPipeline.BuildAssetBundles(path, BuildAssetBundleOptions.ChunkBasedCompression, BuildTarget.Android);

    }


}
