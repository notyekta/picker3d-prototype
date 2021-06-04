using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Player player;
    public GameManager gameManager;
    public Rigidbody rb;
    public Camera cam;

    //Gameplay
    public int collectedBall;

    public float _tempSpeed;
    
    //Movement
    private Vector3 _mousePos;
    private float _distanceToScreen;
    public float _horizontalSpeed;
    public float _forwardSpeed;

    //Game Settings
    public float checkPointDelay;

    //Push System
    private List <Ball> _collectedBalls;

    // Start is called before the first frame update
    void Start()
    {
       _collectedBalls = new List<Ball>();

        rb = GetComponent<Rigidbody>();
        player = FindObjectOfType<Player>();
        gameManager = FindObjectOfType<GameManager>();
    }


    #region Ball List System
    public void ItemCollected(Ball _collectedB)
    {
        Debug.Log("collect");
        collectedBall = collectedBall + 1;
        _collectedBalls.Add(_collectedB);
    }

    public void ItemLost(Ball _lostBall)
    {
        collectedBall = collectedBall - 1;
        Debug.Log("itemlost");
        _collectedBalls.Remove(_lostBall);


    }
    public void ClearBallList()
    {
        _collectedBalls.Clear();
    }

    public List<Ball> GetCollectedBallsList()
    {
        return _collectedBalls;
    }

#endregion

    private void FixedUpdate()
	{
      

        if (Input.GetMouseButton(0))
        {
            var position = Input.mousePosition;

            _distanceToScreen = cam.WorldToScreenPoint(gameObject.transform.position).x;
            _mousePos = cam.ScreenToWorldPoint(new Vector3( position.x ,position.y, _distanceToScreen));
            float direction = _horizontalSpeed;
            direction = _mousePos.z > transform.position.z ? direction : -direction;

            if (Math.Abs(_mousePos.z - transform.position.z) > 0.5f)
                transform.Translate(0, 0, Time.deltaTime * direction);
        }
        transform.Translate(-Time.deltaTime * _forwardSpeed, 0, 0);
    }
    #region OnTrigger
    public void OnTriggerEnter(Collider other)
    {
      

      



    }

    public void OnTriggerExit(Collider other)
    {
      

    }
#endregion

    public void PushTheBalls()
    {
        foreach (var balls in player.GetCollectedBallsList())
        {
            balls.Push();
        }
    }

 

}
