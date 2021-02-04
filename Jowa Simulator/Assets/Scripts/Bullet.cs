using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject GameManager;
    public BundleManager bundleManager;
    private Game_Manager gamemanager;
    [SerializeField] private Transform playerPosition;
    [SerializeField] private GameObject playervar;
    //[SerializeField] private Transform transform;
    [SerializeField] private Transform midpoint;
//    [SerializeField] private List<Sprite> spriteList;
 //   [SerializeField] private SpriteRenderer sr;

//    [SerializeField] private List<RuntimeAnimatorController> animatorList;

    //initialize these
    public int type;
    public float bulletspeed;
    public int damage;
    // Start is called before the first frame update

    private const string ANIMATIONS = "animations";

    private void Awake()
    {
        Start();
        gameObject.SetActive(true);
    }


    void Start()
    {

        GameManager = GameObject.FindGameObjectWithTag("GameManager");
        bundleManager = GameObject.FindGameObjectWithTag("AssetBundle").GetComponent < BundleManager>();
        playerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        playervar = GameObject.FindGameObjectWithTag("Player");
        midpoint = GameObject.FindGameObjectWithTag("Midpoint").GetComponent<Transform>();



        type = playervar.GetComponent<PlayerVariables>().type;
        bulletspeed = playervar.GetComponent<PlayerVariables>().bulletSpeed;
        damage = playervar.GetComponent<PlayerVariables>().bulletDamage;

        //get animator list from the asseet bundle
        switch (type){
            case 0:
                Debug.Log("exdeeeee");
                // this.GetComponent<Animator>().runtimeAnimatorController = bundleManager.GetAsset<RuntimeAnimatorController>(ANIMATIONS, "Red_Enemy");
                this.GetComponent<Animator>().runtimeAnimatorController = bundleManager.getAnimationController(ANIMATIONS, "Red_Bullet");
                Debug.Log("HASDHASDHASHDAHSDHASD");
                break;
            case 1:
                //this.GetComponent<Animator>().runtimeAnimatorController = bundleManager.GetAsset<RuntimeAnimatorController>(ANIMATIONS, "Guitar_Controller");
                this.GetComponent<Animator>().runtimeAnimatorController = bundleManager.getAnimationController(ANIMATIONS, "Guitar_Controller");
                break;
            case 2:
                //this.GetComponent<Animator>().runtimeAnimatorController = bundleManager.GetAsset<RuntimeAnimatorController>(ANIMATIONS, "Juul_Controller");
                this.GetComponent<Animator>().runtimeAnimatorController = bundleManager.getAnimationController(ANIMATIONS, "Juul_Controller");
                break;
            default:
                break;
        }


        //this.GetComponent<Animator>().runtimeAnimatorController = animatorList[type];
        //sr.sprite = spriteList[type];

        Vector3 diff = midpoint.position - playerPosition.position;
        diff.Normalize();
        float rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ - playervar.GetComponent<PlayerVariables>().bulletDirection);//-90 inwards // +90 outwards
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * bulletspeed * Time.deltaTime *1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "Player")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
   
    /*private void OnBecameInvisible()
    {
        //   GameManager.GetComponent<GameManager>().bulletContainer.Remove(this.gameObject);
        //    Destroy(this.gameObject);
        if (GameManager.GetComponent<GameManager>() != null && this.gameObject != null)
        {
            Debug.Log("Does this work");
            GameManager.GetComponent<GameManager>().destroyBullet(this.gameObject);
        }
        
    }*/
}
