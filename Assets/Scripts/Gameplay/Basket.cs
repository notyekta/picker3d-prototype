using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Basket : MonoBehaviour
{
    public GameManager gameManager;
    public Animator anim;

    public GroundPlatform ground; //Ground that Basket connected 
    public int basketNumber; //Basket ID

   
    
   public int collectedBallInBasket;
    public Text requiredBallText;

    public bool isCompleted;



    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        requiredBallText.text = collectedBallInBasket+ "/" + Convert.ToUInt32(ground.totalBalls/gameManager.divideTheBallAmountTo);
        
        
        if(collectedBallInBasket  > ground.totalBalls / gameManager.divideTheBallAmountTo)
        {
            isCompleted = true;
        }
        else
        {
            isCompleted = false;
        }


    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            collectedBallInBasket = collectedBallInBasket + 1;

        }
    }


    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            collectedBallInBasket = collectedBallInBasket - 1;

        }
    }

}
