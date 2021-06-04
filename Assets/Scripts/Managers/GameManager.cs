using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameStarted;

    public int levelNumber;

    public int checkPointNumber;

    public int totalBallAmount;
    public int requiredBallAmount;


    public GameObject previousPlatform;
    public GameObject currentPlatform;

    public GameObject[] ballPrefabs;

    public GameObject Platform;
    private Platform currentPlatformManager;

    private Player player;
    private UIManager uiManager;

    public int playerLevel;

    public Transform spawnPoint;

    public float divideTheBallAmountTo;

    public int currentCheckpointLevel;


    public Basket basket1;
    public Basket basket2;

    private int theDestroyeroftheLevelsCounter;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        uiManager = FindObjectOfType<UIManager>();
        if (PlayerPrefs.HasKey("PlayerLevel") == false)
        {
            PlayerPrefs.SetInt("PlayerLevel", 1);
        }
        playerLevel = PlayerPrefs.GetInt("PlayerLevel");
        
        FirstStart();
    }
    

    public void FirstStart()
    {
        uiManager.LevelCheck();
        currentPlatform = Instantiate(Platform);

        currentPlatformManager = currentPlatform.GetComponent<Platform>();

        spawnPoint = currentPlatformManager.newLevelSpawnPoint.transform;

        CalculateLevelDifficulty();

    }
    public void LevelSet()
    {
        PlayerPrefs.SetInt("PlayerLevel", PlayerPrefs.GetInt("PlayerLevel") + 1);
        playerLevel = PlayerPrefs.GetInt("PlayerLevel");
        CalculateLevelDifficulty();
        uiManager.LevelCheck();
        //---
    }

    public void CalculateLevelDifficulty()
    {
        //Primitive Self-Hardening Level difficulty system//
        // The all number divider gets lower level by level so the required ball to completing the---
        //---checkpoint is getting closer to the count of the certain number of the certain ground's total ball number.

        float _tempDivideVariable = (Mathf.Clamp(playerLevel * 0.050f, 1f, 2.4f));
        divideTheBallAmountTo = 3.4f - _tempDivideVariable;
    }

    public IEnumerator CheckPoint(Basket _basket)
    {
        Debug.Log("CheckpointReached");
        player.PushTheBalls();
        yield return new WaitForSeconds(5f);
        if(_basket.isCompleted == true)
        {
            currentCheckpointLevel = _basket.basketNumber;  //Basket index to Level checkpoint 
            _basket.anim.SetInteger("Open", 1);

            //play some effect; ////************************

            yield return new WaitForSeconds(1f);
            player._forwardSpeed = player._tempSpeed; //Move the player again
            CheckProgress();
            yield break;
        }
        else
        {
            //gameLost
            uiManager.levelText.text = "Game Over!";
            yield return new WaitForSeconds(1.5f);
            uiManager.GameOver();


    
        }


    }
    public void LoadNextPlatform()  //New level
    {
     

        currentCheckpointLevel = 0;
        CheckProgress();
        LevelSet();

        previousPlatform = currentPlatform;
        currentPlatform = null;
        currentPlatform = Instantiate(Platform); //Set the current platform the newly spawned platform.

        currentPlatform.transform.position = spawnPoint.position;
        currentPlatformManager = currentPlatform.GetComponent<Platform>();
        spawnPoint = currentPlatform.GetComponent<Platform>().newLevelSpawnPoint.transform; //Update the next Spawn Point 

        basket1 = currentPlatformManager.basket1;  //Update the baskets
        basket2 = currentPlatformManager.basket2;

    }

    public void CheckProgress()
    {
        if(currentCheckpointLevel == 1)
        {
            uiManager.basketComplationImages[0].color = new Color(0.3f, 0.3f, 1f, 1f);
        }
        else if (currentCheckpointLevel == 2)
        {
            uiManager.basketComplationImages[0].color = new Color(0.3f, 0.3f, 1f, 1f);
            uiManager.basketComplationImages[1].color = new Color(0.3f, 0.3f, 1f, 1f);
            ClearLevel(); //Clear the previous Level
        }
        else
        {
            uiManager.basketComplationImages[0].color = new Color(1f, 1f, 1f, 1f);
            uiManager.basketComplationImages[1].color = new Color(1f, 1f, 1f, 1f);
        }
  
    }
    public void ClearLevel()
    {
        if (previousPlatform != null)
        {
            Destroy(previousPlatform);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
