using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System;

public class SoundsScript1 : MonoBehaviour
{
    
    public AudioMixer audioMixer;
    public Scrollbar Music_Scrollbar;
    public Scrollbar SFX_Scrollbar;
    



    public void Start()
    {
       
        
        
        
        Music_Scrollbar = GameObject.Find("Music_Scrollbar").GetComponent<Scrollbar>();
        SFX_Scrollbar = GameObject.Find("SFX_Scrollbar").GetComponent<Scrollbar>();
        SFX_Scrollbar.value = PlayerPrefs.GetInt("SFX_Value", 50)/100f;
        Music_Scrollbar.value = PlayerPrefs.GetInt("Music_Value", 50)/100f;

        SetMusicVolume1();
        SetSFXVolume1();
    }


    public void SetMusicVolume1()
    {
        PlayerPrefs.SetInt("Music_Value", Convert.ToInt32(Music_Scrollbar.value*100));
        PlayerPrefs.Save();
        if (Music_Scrollbar.value == 0)
        {
            audioMixer.SetFloat("MusicBus", -80f);
        }
        else
        {
            float volume = Mathf.Log10(Music_Scrollbar.value) * 20;
            audioMixer.SetFloat("MusicBus", volume);
        }
        
    }

    public void SetSFXVolume1()
    {
        PlayerPrefs.SetInt("SFX_Value", Convert.ToInt32(SFX_Scrollbar.value*100));
        PlayerPrefs.Save();
        if (SFX_Scrollbar.value == 0)
        {
            audioMixer.SetFloat("SFXBus", -80f);
        }
        else
        {
            float volume = Mathf.Log10(SFX_Scrollbar.value) * 20;
            audioMixer.SetFloat("SFXBus", volume);
        }
    }
  
    public void Button_SFX()
    {
        try
        {
            SoundsScript.Button_Click_Play();
        }
        catch (NullReferenceException)
        {
            Debug.LogWarning("NullReferenceException");
        }
    }
}
