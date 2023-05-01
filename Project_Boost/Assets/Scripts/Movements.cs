using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Pressed SPACE - Thrusting");
        }
        
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.D))
        {   
            Debug.Log("Pressed D - Steering Right");
        }
        else if (Input.GetKey(KeyCode.A))
        {   
            Debug.Log("Pressed A - Steering Left");
        }
    }
}
