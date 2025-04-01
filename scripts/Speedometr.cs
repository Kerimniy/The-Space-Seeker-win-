using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Speedometr : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    private new Rigidbody rigidbody;
    public GameObject obj;
    public Transform strel;
    private Vector3 newTransform;
    
    void Start()
    {
        
        strel = GameObject.Find("strel").transform;
        textMesh = GameObject.Find("Sp1").GetComponent<TextMeshProUGUI>();
        obj = GameObject.Find("cockpit");
        rigidbody = obj.GetComponent<Rigidbody>();
       
    }

    
    void Update()
    {
        newTransform = strel.localPosition;
        float speed = Mathf.Round(rigidbody.velocity.magnitude * 11.11111f);
        string txt = speed.ToString();
        textMesh.text = txt;
        speed = Mathf.Clamp(speed, 0, 300);
        newTransform.z = ((speed / 50f)-3f)*-1;
        strel.localPosition = newTransform;
       
        
    }
}
