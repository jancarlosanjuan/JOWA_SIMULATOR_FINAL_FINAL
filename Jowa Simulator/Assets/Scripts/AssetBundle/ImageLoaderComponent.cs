using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ImageLoaderComponent : MonoBehaviour
{
    public BundleManager bundleManager;

    public string assetBundleName;
    public string assetName;

    private void Start()
    {
        
        LoadImage();
       
    }

    public void LoadImage()
    {
        Sprite image = bundleManager.GetAsset<Sprite>(assetBundleName, assetName);
        this.gameObject.GetComponent<Image>().sprite = image;
    }


}
