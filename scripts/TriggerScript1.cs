using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TriggerScript1 : MonoBehaviour
{
    string new_txt;
    public TextMeshProUGUI obj1;
    
    private void Awake()
    {
        obj1 = GameObject.Find("Player_text").GetComponent<TextMeshProUGUI>();
       

    }

    public void OnTriggerEnter(Collider collider1)
    {
        if (linkst.object_count == 5)
        {
            obj1.fontSize = 0.045f;
            if (PlayerPrefs.GetInt("SetLanguage", 0) == 0)
            {
                new_txt = "Собрано  " + linkst.object_count + "/5  утеряных микросхем. Нажми пробел для перехода на следующий уровень";
            }

            else if (PlayerPrefs.GetInt("SetLanguage", 0) == 1)
            {
                new_txt = linkst.object_count + "/5 of the lost chips have been collected. Press the space bar to go to the next level";
            }
        }
        else
        {
            obj1.fontSize = 0.08f;
            if (PlayerPrefs.GetInt("SetLanguage", 0) == 0)
            {
                new_txt = "Собрано  " + linkst.object_count + "/5  утеряных микросхем.";
            }
            if (PlayerPrefs.GetInt("SetLanguage", 0) == 1)
            {
                new_txt = linkst.object_count + "/5 of the lost chips have been collected.";
            }
        }

        if (collider1.CompareTag("SpaceShip"))
        {
            obj1.text = new_txt;
        }
       else if (collider1.CompareTag("border"))
        {
            obj1.fontSize = 0.08f;
            if (PlayerPrefs.GetInt("SetLanguage", 0) == 0)
            {
                obj1.text = "Высокий уровень космической радиации";
            }
            if (PlayerPrefs.GetInt("SetLanguage", 0) == 1)
            {
                obj1.text = "High levels of cosmic radiation";
            }

        }
    }
    public void OnTriggerExit(Collider collider1)
    {
      
        if (collider1.CompareTag("SpaceShip"))
        {
            obj1.text = "";
            linkst.IsInCollider = false;
            

        }
       else if (collider1.CompareTag("border"))
        {
            obj1.text = "";
            linkst.rad_status = false;
        }
    }
    public void OnTriggerStay(Collider collider1)
    {

        
        if (collider1.CompareTag("SpaceShip"))
        {
            linkst.IsInCollider = true;
            obj1.text = new_txt;
        }
        else if (collider1.CompareTag("border"))
        {
            linkst.rad_status = true;
        }
    }


}
