using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class BundleManager : MonoBehaviour
{
    //declare the root path of the added bundle
    public string BundleRoot{
        get{
#if UNITY_EDITOR
            return Application.streamingAssetsPath;
#elif UNITY_ANDROID
            return Application.persistentDataPath;
#endif
        }
   }

    //dont load assets twice. this keeps track of whats loaded and whats not
    Dictionary<string, AssetBundle> LoadedBundles = new Dictionary<string, AssetBundle>();


    public AssetBundle LoadBundle(string bundleTarget)
    {
        //check if loaded
        if (LoadedBundles.ContainsKey(bundleTarget))
        {
            return LoadedBundles[bundleTarget];
        }

        AssetBundle ret = AssetBundle.LoadFromFile(Path.Combine(BundleRoot, bundleTarget));

        if(ret == null)
        {
            Debug.LogError("Failed to load " + bundleTarget);
        }
        else
        {
            LoadedBundles.Add(bundleTarget, ret);
        }

        return ret;
    }


    public T GetAsset<T>(string bundleTarget, string assetName) where T : UnityEngine.Object
    {
        T ret = null;
        AssetBundle bundle = LoadBundle(bundleTarget);

        if(bundle != null)
        {
            ret = bundle.LoadAsset<T>(assetName);
        }

        return ret;
    }

    public RuntimeAnimatorController getAnimationController(string bundleTarget, string assetName)
    {
        AssetBundle bundle = LoadBundle(bundleTarget);
        RuntimeAnimatorController controller = null;
        if (bundle != null)
        {
            controller = bundle.LoadAsset<RuntimeAnimatorController>(assetName);
            Debug.Log("Loaded Animation!");
        }
        return controller;
    }

}
