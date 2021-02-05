using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    [SerializeField] private Text waveText;
    [SerializeField] private Text waveCounterText;
    [SerializeField] private GameObject resultPanel;
    [SerializeField] private GameObject sharePanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        waveText.text = waveCounterText.text;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Shop()
    {
        SceneManager.LoadScene("ShopMenu");
    }

    public void CloseUploadMessage()
    {
        resultPanel.SetActive(false);
        sharePanel.SetActive(false);
    }
}
