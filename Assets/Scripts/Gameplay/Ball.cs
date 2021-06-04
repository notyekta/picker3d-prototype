using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //Push(); debug
    }

    public void Push()
    {
        rb.AddForce(-10, 0, 0, ForceMode.VelocityChange);
        //Debug.Log("ForceApplied");
    }
  

}
