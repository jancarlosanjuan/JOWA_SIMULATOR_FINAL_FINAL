using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoader : MonoBehaviour
{
    public BundleManager bundleManager;

    public string assetBundleName;
    public string assetName;

    private void Start()
    {

        bundleManager = GameObject.FindGameObjectWithTag("AssetBundle").GetComponent<BundleManager>();
        LoadImage();
    }

    public void LoadImage()
    {
        Sprite image = bundleManager.GetAsset<Sprite>(assetBundleName, assetName);
        this.gameObject.GetComponent<SpriteRenderer>().sprite = image;
    }
}
