using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System;

public class SoundsScript : MonoBehaviour
{
    public static AudioSource button_click;
    public AudioMixer audioMixer;
    public Scrollbar Music_Scrollbar;
    public Scrollbar SFX_Scrollbar;
    



    public void Start()
    {
       
        button_click = GameObject.Find("ButtonClickSound").GetComponent<AudioSource>();
        
        
        Music_Scrollbar = GameObject.Find("Music_Scrollbar").GetComponent<Scrollbar>();
        SFX_Scrollbar = GameObject.Find("SFX_Scrollbar").GetComponent<Scrollbar>();
        SFX_Scrollbar.value = PlayerPrefs.GetInt("SFX_Value", 50)/100f;
        Music_Scrollbar.value = PlayerPrefs.GetInt("Music_Value", 50)/100f;

        SetMusicVolume();
        SetSFXVolume();
    }
    public static void Button_Click_Play()
    {
        DontDestroyOnLoad(button_click);
        button_click.Play();
    }

    public void SetMusicVolume()
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

    public void SetSFXVolume()
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
  

}
