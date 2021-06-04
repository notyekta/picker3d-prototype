using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPlatform : MonoBehaviour
{
    public GameManager gameManager;
    public int totalBalls;

    public Transform[] spawnPoints;

    // Start is called before the first frame update
    void Start()
    {

        gameManager = FindObjectOfType<GameManager>();
        

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            int randomTypeBallPack = Random.Range(0, gameManager.ballPrefabs.Length);

            GameObject _ballPack = Instantiate (gameManager.ballPrefabs[randomTypeBallPack]);


            _ballPack.transform.SetParent(this.transform, true);


           _ballPack.transform.position = spawnPoints[i].position;

            BallManager _ballManager = _ballPack.GetComponent<BallManager>();

           totalBalls = totalBalls + _ballManager.ballObjects.Length;
            
        }

       
    }


  

    // Update is called once per frame
    void Update()
    {
        
    }
}
