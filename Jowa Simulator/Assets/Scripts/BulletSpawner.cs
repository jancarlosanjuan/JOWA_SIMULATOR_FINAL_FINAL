using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private GameObject gamemanagerObject;
    private Game_Manager gamemanager;
    [SerializeField] private BundleManager bundleManager;
    [SerializeField] private GameObject playerReference;
    //[SerializeField] private List<GameObject> bulletList;

    private Transform spawnLocation;
    // Start is called before the first frame update
    void Start()
    {
        gamemanager = gamemanagerObject.GetComponent<Game_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnBullets()
    {

        GameObject prefab = bundleManager.GetAsset<GameObject>("prefabs", "Bullet PREFAB");
        GameObject spawn = Instantiate(prefab, playerReference.transform.position, Quaternion.identity);

        spawn.SetActive(true);
        gamemanager.bulletContainer.Add(spawn);
        
    }

    /*public List<GameObject> getBulletList()
    {
        return bulletList;
    }*/
}
