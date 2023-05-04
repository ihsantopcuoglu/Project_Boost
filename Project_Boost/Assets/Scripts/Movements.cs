using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : MonoBehaviour
{
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationthrust = 1f;
    [SerializeField] AudioClip mainEngine;

    Rigidbody rb;
    AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
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
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            if(!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(mainEngine);

            }
            
        }
        else
        {
                audioSource.Stop();
        }
        
    }

    void ProcessRotation()
    {
        
        if (Input.GetKey(KeyCode.A))
        {   
            ApplyRotation(rotationthrust);
        }
        else if (Input.GetKey(KeyCode.D))
        {   
            ApplyRotation(-rotationthrust);
        }
    }
    private void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; // freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; // un freezing rotation so we the physics system can take over
    }
}
