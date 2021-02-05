using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    private BundleManager bundleManager;

    // Start is called before the first frame update
    void Start()
    {
        bundleManager = GameObject.FindGameObjectWithTag("AssetBundle").GetComponent<BundleManager>();
        gameObject.GetComponent<Animator>().runtimeAnimatorController = bundleManager.getAnimationController("animations", "Explosion_0");
        gameObject.GetComponent<SpriteRenderer>().material = bundleManager.GetAsset<Material>("materials", "White");
    }

   
}
