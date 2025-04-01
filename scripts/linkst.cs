using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class linkst : MonoBehaviour
{
    public static byte object_count = 0;
    public static bool rad_status;
    public static bool IsInCollider;
    public static int[] LevelComplete = {0,0,0,0};
    public static int currentScene = 1;
    void OnEnable()
    {
        LevelComplete[0] = PlayerPrefs.GetInt("AccesLevel0", 0);
        LevelComplete[1] = PlayerPrefs.GetInt("AccesLevel1", 0);
        LevelComplete[2] = PlayerPrefs.GetInt("AccesLevel2", 0);
        LevelComplete[3] = PlayerPrefs.GetInt("AccesLevel3", 0);
        
    }


    void OnApplicationQuit()
    {
    
        PlayerPrefs.SetInt("AccesLevel0", LevelComplete[0]);
        PlayerPrefs.SetInt("AccesLevel1", LevelComplete[1]);
        PlayerPrefs.SetInt("AccesLevel2", LevelComplete[2]);
        PlayerPrefs.SetInt("AccesLevel3", LevelComplete[3]);
       
        PlayerPrefs.Save();
        
        
    }
}