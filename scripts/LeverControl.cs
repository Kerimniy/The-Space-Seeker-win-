using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverControl : MonoBehaviour
{
    private Quaternion targetRotation;
    public Transform obj;
    void Start()
    {

        obj = GameObject.Find("lever").transform;
       
    }

    void Update()
    {
        float ZRotate = Input.GetAxis("Vertical") * 100f * Time.deltaTime * -1;
        float XRotate = Input.GetAxis("Horizontal") * 100f * Time.deltaTime * -1;
     

        if (XRotate/100 == 0)
        {
           
            targetRotation = Quaternion.Euler(Mathf.LerpAngle(obj.localEulerAngles.x, 0, 5f * Time.deltaTime), 0, obj.localEulerAngles.z); 
            obj.rotation = Quaternion.Slerp(obj.rotation, targetRotation, 5f * Time.deltaTime);
            obj.rotation = targetRotation;

        
        }
        if (ZRotate == 0)
        {

            targetRotation = Quaternion.Euler(obj.localEulerAngles.x, 0, Mathf.LerpAngle(obj.localEulerAngles.z, 0, 5f * Time.deltaTime));
            obj.rotation = Quaternion.Slerp(obj.rotation, targetRotation, 5f * Time.deltaTime);
            obj.rotation = targetRotation;

        }
        Vector3 currentRotation = obj.localEulerAngles;
        currentRotation.x = Mathf.DeltaAngle(0, currentRotation.x);
        currentRotation.z = Mathf.DeltaAngle(0, currentRotation.z);

        currentRotation.x = Mathf.Clamp(currentRotation.x + XRotate, -30f, 30f);
        currentRotation.z = Mathf.Clamp(currentRotation.z + ZRotate, -30f, 30f);
        currentRotation.y = -90f;
        obj.localEulerAngles = currentRotation;


    }
}
