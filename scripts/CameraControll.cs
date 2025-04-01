using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    public Transform CameraTransform;
    private Vector3 originalTransform;
    private Vector3 newPosition;
    float randomIntx;
    float randomInty;
    float randomIntz;
    public linkst Linkst;
    void Start()
    {
        newPosition = CameraTransform.localPosition;
        originalTransform = CameraTransform.localPosition;
        
        Linkst = GetComponent<linkst>();
    }
    void Update()
    {
        if(linkst.rad_status == true)
        {
            StartCoroutine(UpdateWithWait());
        }
    }
    IEnumerator UpdateWithWait()
    {
        
        while (true)
        {
            randomIntx = Random.Range(-0.08f, 0.08f);
            randomInty = Random.Range(-0.08f, 0.08f);
            randomIntz = Random.Range(-0.03f, 0.03f);
            yield return new WaitForSeconds(0.02f);
            newPosition.x = originalTransform.x + randomIntx;
            newPosition.y = originalTransform.y + randomInty;
            newPosition.z = originalTransform.z + randomIntz;

            CameraTransform.localPosition = newPosition;
            if (linkst.rad_status != true)
            {
                CameraTransform.localPosition = originalTransform;
                break;
            }
        }
        
    }

}