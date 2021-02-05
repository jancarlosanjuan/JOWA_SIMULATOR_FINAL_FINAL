using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossOutofBounds : MonoBehaviour
{
    [SerializeField] private GameObject _gamemanager;
    private Game_Manager gamemanager;
    [SerializeField] private GameObject _text;
    private ChangeText text;
    [SerializeField] private GameObject _playerVariables;
    private PlayerVariables playervariables;
    [SerializeField] private GameObject gameOverPanel;

    private void Start()
    {
        //gameOverPanel.SetActive(false);
        _gamemanager = GameObject.FindGameObjectWithTag("GameManager");
        gamemanager = _gamemanager.GetComponent<Game_Manager>();
        _text = GameObject.FindGameObjectWithTag("AttractionMeterText");
        text = _text.GetComponent<ChangeText>();
        _playerVariables = GameObject.FindGameObjectWithTag("Player");
        playervariables = _playerVariables.GetComponent<PlayerVariables>();
        gameOverPanel = GameObject.FindGameObjectWithTag("GameOver");
    }
    void Update()
    {
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPosition.y > Screen.height || screenPosition.y < 0 || screenPosition.x < 0 || screenPosition.x > Screen.width)
        {
            GlobalAudio.Instance.playSound("EnemyDeath", 1f);
            gamemanager.destroyBoss(this.gameObject);

            int health = playervariables.health - (4 + gamemanager.waveNumber);
            playervariables.health = health - 1;
            Debug.Log("Health is: " + health);
            text.changeCurrencyText(health);

            if (health <= 0)
            {
                Time.timeScale = 0;
                gameOverPanel.SetActive(true);
                //playervariables.gameObject.GetComponent<SceneChanger>().onButtonClicked();
            }
        }

    }
}
