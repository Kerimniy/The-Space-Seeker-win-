using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class SettingsScript : MonoBehaviour
{   private int currentResolutionIndex;
    public bool a;
    public Sprite spriteR;
    public Sprite spriteE;
    public GameObject Background;
    public Toggle Newtoggle;
    public TMP_Dropdown resolutionDropdown;
    public Toggle languageButton;
    public TMP_Dropdown qualityDropdown;
    private Locale locale;
    public TMP_Text Quality_Text;
    private static Resolution[] resolutions;
    void Start()
    {
        SetQualityName(Convert.ToBoolean(PlayerPrefs.GetInt("SetLanguage", 0)));
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        resolutions = Screen.resolutions;
        
        currentResolutionIndex = PlayerPrefs.GetInt("ResolutionPreference", 17);

        
        for (int i =0; i < resolutions.Length; i++){
            int roundedRefreshRate = Mathf.RoundToInt((float)resolutions[i].refreshRateRatio.numerator / resolutions[i].refreshRateRatio.denominator);
            string option = resolutions[i].width + "x" + resolutions[i].height + " " + roundedRefreshRate + "Hz";
            options.Add(option);
            
        }
        
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.RefreshShownValue();
        resolutionDropdown.value = PlayerPrefs.GetInt("ResolutionPreference", 17);


        qualityDropdown.value = PlayerPrefs.GetInt("QualitySettingPreference", 3);
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("QualitySettingPreference", 3));

     
        Newtoggle.isOn = System.Convert.ToBoolean(PlayerPrefs.GetInt("FullscreenPreference", 1));
        Screen.fullScreen = System.Convert.ToBoolean(PlayerPrefs.GetInt("FullscreenPreference", 1));


        languageButton.isOn = Convert.ToBoolean(PlayerPrefs.GetInt("SetLanguage", 0));
    }


    public void SetFullscreen(bool IsFullscreen)
    {
        if (Newtoggle.isOn)
            Screen.fullScreen = true;
        else Screen.fullScreen = false;

        PlayerPrefs.SetInt("FullscreenPreference", System.Convert.ToInt32(Newtoggle.isOn));
        PlayerPrefs.Save();
    }


    public void SetResolution()
    {
        if (a)
        {
            SoundsScript.Button_Click_Play();
        }
        Resolution resolution = resolutions[resolutionDropdown.value];  
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        PlayerPrefs.SetInt("ResolutionPreference", resolutionDropdown.value);
        PlayerPrefs.Save();
        
        


    }


    public void SetQuality()
    {
        if (a)
        {
            SoundsScript.Button_Click_Play();
        }
        QualitySettings.SetQualityLevel(qualityDropdown.value);
        PlayerPrefs.SetInt("QualitySettingPreference", qualityDropdown.value);
        int currentQualityLevel = QualitySettings.GetQualityLevel();
        string currentQualityName = QualitySettings.names[currentQualityLevel];
        PlayerPrefs.Save();
 
    }


    public void SetLanguage()
    {
       
        if (languageButton.isOn == false)
        {
            locale = LocalizationSettings.AvailableLocales.GetLocale("ru"); 
            LocalizationSettings.SelectedLocale = locale;
            Background.GetComponent<Image>().sprite = spriteR;
            SetQualityName(false);

        }
        else if (languageButton.isOn == true)
        {
            locale = LocalizationSettings.AvailableLocales.GetLocale("en");
            LocalizationSettings.SelectedLocale = locale;
            Background.GetComponent<Image>().sprite = spriteE;
            SetQualityName(true);

        }
        PlayerPrefs.SetInt("SetLanguage",Convert.ToInt32(languageButton.isOn));
        Quality_Text.text = qualityDropdown.options[qualityDropdown.value].text;
        PlayerPrefs.Save();
   
        }


    public void SetQualityName(bool status)
       {
        if (status == true)
        {
            qualityDropdown.options[0].text = "Low";
            qualityDropdown.options[1].text = "Medium";
            qualityDropdown.options[2].text = "High";
        }
        if (status == false)
        {
            qualityDropdown.options[0].text = "Низкие";
            qualityDropdown.options[1].text = "Средние";
            qualityDropdown.options[2].text = "Высокие";
        }
    }
    public void Set_a()
    {
        a = true;
    }


}
