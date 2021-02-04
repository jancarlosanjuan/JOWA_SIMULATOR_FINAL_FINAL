using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationLoader : MonoBehaviour
{
    [SerializeField] private BundleManager bundleManager;

    // Start is called before the first frame update
    public void Start()
    {
        this.gameObject.GetComponent<Animator>().runtimeAnimatorController = bundleManager.getAnimationController("animations", "Player");
        
    }

  
}
