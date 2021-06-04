using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    public Player player;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        gameManager = FindObjectOfType<GameManager>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            player.ItemCollected(other.GetComponent<Ball>());

        }

        if (other.gameObject.tag == "CheckPoint")
        {
            player._tempSpeed = player._forwardSpeed;
            player._forwardSpeed = 0;
            Destroy(other.gameObject);
            Basket _basket = other.GetComponent<Checkpoint>().basket;
            StartCoroutine(gameManager.CheckPoint(_basket));
        }

        if (other.gameObject.tag == "FinishPoint")
        {
            Destroy(other.gameObject);
            player.cam.GetComponent<Animator>().SetInteger("CamDown", 1);
            gameManager.LoadNextPlatform();

        }

        if (other.gameObject.tag == "NewPoint")
        {
            Destroy(other.gameObject);
            player.cam.GetComponent<Animator>().SetInteger("CamDown", 0);
        }

    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            player.ItemLost(other.GetComponent<Ball>());
        }

    }

 
}
