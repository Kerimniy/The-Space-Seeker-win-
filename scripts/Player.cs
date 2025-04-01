using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{


    public float tiltSpeed = 50f;
    private float rotationSpeed;
    private float moveSpeed;
    public float mSpeed;
    public float rSpeed;
    void Awake()
    {
        linkst.currentScene = SceneManager.GetActiveScene().buildIndex;
    }
    void FixedUpdate()
    {
   
        float upspeed = 0f;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float rotationSpeed = rSpeed*horizontal;
        float moveSpeed = mSpeed*vertical;
        Vector3 liftForce = Vector3.zero; 
        if (vertical < 0)
        {
            rotationSpeed *= -1;
        }
        if (Input.GetKey(KeyCode.Q)) { 
            liftForce = Vector3.up * -tiltSpeed; 
        } 
        else if (Input.GetKey(KeyCode.E)) 
        {
            liftForce = Vector3.up * tiltSpeed; 
        }
        GetComponent<Rigidbody>().AddRelativeForce(liftForce, ForceMode.Acceleration);
        
        GetComponent<Rigidbody>().AddRelativeTorque(0f, rotationSpeed,0f, ForceMode.Force);
      
        GetComponent<Rigidbody>().AddRelativeForce(0f, upspeed, moveSpeed, ForceMode.VelocityChange);
        
    }
    
}
