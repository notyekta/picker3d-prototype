using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Image[] basketComplationImages;
    public Text levelText;
    public Text statusText;

    public GameObject losePanel;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

    }

    public void LevelCheck()
    {
        levelText.text = "Level " + gameManager.playerLevel;
    }

    public void GameOver()
    {
        losePanel.SetActive(true);
    }

 

    // Update is called once per frame
    void Update()
    {
        
    }
}
