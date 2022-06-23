using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        AnimationClip clip = new AnimationClip();
       AnimationCurve animationCurve = new AnimationCurve();
        animationCurve.keys = null;
        clip.SetCurve("ddd", typeof(Transform),"" , animationCurve);



        AssetBundle assetBundle = null;
        assetBundle.LoadAsset<AnimationClip>("");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
