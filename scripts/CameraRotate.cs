using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraRotate : MonoBehaviour
{
   
    private Quaternion origRotation;
    private Quaternion newRotation;
    public float Sensity = 100f;
    public new Transform camera;


    void Start()
    {
        origRotation = camera.localRotation;       
    } 

    void Update()
    { 
        if (Input.GetKey(KeyCode.C))
        { 
            float mouseX = Input.GetAxis("Mouse X") * Sensity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * Sensity * Time.deltaTime;
           
            camera.Rotate(Vector3.down * mouseX * -1);
            camera.Rotate(Vector3.right * mouseY);

            Vector3 rotation = camera.localRotation.eulerAngles;
            rotation.z = 0;
            rotation.y = (rotation.y > 180) ? rotation.y - 360 : rotation.y;
            rotation.y = ClampAngle(rotation.y, -75, 75f);
            rotation.x = Mathf.Clamp(rotation.x, 10f, 32f);

            camera.localRotation = Quaternion.Euler(rotation.x,rotation.y, rotation.z);
            newRotation = camera.rotation;
            
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            camera.localRotation = Quaternion.Slerp(newRotation, origRotation,1f);
    
        }
    
    
    float ClampAngle(float var, float min,float max)
        {
            if (var < min )
            {
                return min;
            }
            else if (var > max)
            {
                return max;
            }
            return var;
        
        }

    
    
    }
}
