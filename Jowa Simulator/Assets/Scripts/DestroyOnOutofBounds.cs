using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnOutofBounds : MonoBehaviour
{
    [SerializeField] GameObject _gamemanager;
    private Game_Manager gamemanager;

    private void Start()
    {
        _gamemanager = GameObject.FindGameObjectWithTag("GameManager");
        gamemanager = _gamemanager.GetComponent<Game_Manager>();
    }
    void Update()
    {
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPosition.y > Screen.height || screenPosition.y < 0 || screenPosition.x < 0 || screenPosition.x > Screen.width)
            gamemanager.destroyBullet(this.gameObject);
    }
    
}
