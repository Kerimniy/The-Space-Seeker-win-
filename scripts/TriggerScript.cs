using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TriggerScript : MonoBehaviour
{
    public GameObject AnimObj;
    public AudioSource pickup_sound;
    private Animator animator;
    public TextMeshProUGUI obj1;


   
    private void Awake()
    {
        AnimObj = GameObject.Find("button");
        animator = AnimObj.GetComponent<Animator>();
        obj1 = GameObject.Find("Player_text").GetComponent<TextMeshProUGUI>();
       
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("IsPressed", true);
            
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetBool("IsPressed", false);

        }
    }



    private void OnTriggerStay(Collider collider)
    {
        if (collider.CompareTag("Target")){
            if (Input.GetKey(KeyCode.Space))
            {
                if (!collider.gameObject.GetComponent<CountedFlag>())
                {
                    
                    Destroy(collider.gameObject);
                    linkst.object_count += 1;
                    collider.gameObject.AddComponent<CountedFlag>();
                    obj1.text = "";
                    pickup_sound.Play();

                }
            }
        }

    }
    public void OnTriggerEnter(Collider collider1)
    {
        if (collider1.CompareTag("Target"))
        {
            if (PlayerPrefs.GetInt("SetLanguage", 0) == 0)
            {
                obj1.text = "Подобрать (Пробел)";
            }
            else if (PlayerPrefs.GetInt("SetLanguage", 0) == 1)
            {
                obj1.text = "Pick up (Space)";
            }
        }
    }
    public void OnTriggerExit(Collider collider1)
    {
        if (collider1.CompareTag("Target"))
        {
            obj1.text = "";
        }
    }


}
