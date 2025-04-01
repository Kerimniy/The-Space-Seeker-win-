using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    private Quaternion newRotation;
    public GameObject target;
    public GameObject target1;
    private float angle;
    
    void Start()
    {
       // target = GameObject.Find("cockpit");
       target1 = GameObject.Find("spaceship1");
    }

    void Update()
    {
        short koef;
        Vector3 currentRotation = transform.rotation.eulerAngles;
        Vector3 directionToTarget = target1.transform.position - transform.position; 
        float angle = Mathf.Atan(directionToTarget.z/ directionToTarget.x)* Mathf.Rad2Deg;
        if (angle < 0)
        {
            koef = 90;
        }
        else
        {
            koef=270;
        }
       
        transform.rotation = Quaternion.Euler(new Vector3(currentRotation.x, currentRotation.y, (currentRotation.y + angle+koef)*-1));
    }
}
