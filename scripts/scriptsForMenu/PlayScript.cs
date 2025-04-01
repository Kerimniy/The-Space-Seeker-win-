using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayScript : MonoBehaviour
{

    public GameObject exiting;
    public Button level0;
    public Button level1;
    public Button level2;
    public Button level3;
    public Button level4;
    public GameObject LoadingScreen;
    public Slider scale;
    public float holdTime = 0.5f; // Время удержания кнопки в секундах
    private float timer = 0f;
    private bool isHolding = false;


    void Awake()
    {
        linkst.LevelComplete[0] = PlayerPrefs.GetInt("AccesLevel0", 0);
        linkst.LevelComplete[1] = PlayerPrefs.GetInt("AccesLevel1", 0);
        linkst.LevelComplete[2] = PlayerPrefs.GetInt("AccesLevel2", 0);
        linkst.LevelComplete[3] = PlayerPrefs.GetInt("AccesLevel3", 0);

        Screen.fullScreen = System.Convert.ToBoolean(PlayerPrefs.GetInt("FullscreenPreference", 1));
        if (linkst.LevelComplete[0] == 1)
        {
            level1.interactable = true;
            level2.interactable = false;
            level3.interactable = false;
            level4.interactable = false;
        }
        if (linkst.LevelComplete[1] == 1)
        {
            level1.interactable = true;
            level2.interactable = true;
            level3.interactable = false;
            level4.interactable = false;
        }
        if (linkst.LevelComplete[2] == 1)
        {
            level1.interactable = true;
            level2.interactable = true;
            level3.interactable = true;
            level4.interactable = false;
        }
        if (linkst.LevelComplete[3] == 1)
        {
            level1.interactable = true;
            level2.interactable = true;
            level3.interactable = true;
            level4.interactable = true;
        }
    }


public void Play()
    {
        //SceneManager.LoadSceneAsync(linkst.currentScene);
        LoadingScreen.SetActive(true);
        StartCoroutine(LoadAsync(linkst.currentScene));
    }


private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (exiting.activeInHierarchy == false)
            {
                exiting.SetActive(true);
            }
            if (!isHolding)
            {
                isHolding = true;
                timer = 0f;
            }
            timer += Time.deltaTime*2.5f;

            if (timer >= holdTime)
            {
                timer = 0f;
                isHolding = false;
                QuitGame();
               
            }
        }
        else
        {
            if (exiting.activeInHierarchy == true)
            {
                exiting.SetActive(false);
            }
            if (isHolding)
            {
                isHolding = false;
                timer = 0f;
            }
        }

    }


    public void QuitGame()
    {
        Application.Quit();
        
    }
public void StartNewLevelwith(int levelindex)
    {
        LoadingScreen.SetActive(true);
        StartCoroutine(LoadAsync(levelindex));
        //SceneManager.LoadSceneAsync(levelindex);
    }

    IEnumerator LoadAsync(int levelindex)
    {
        AsyncOperation loadAsync = SceneManager.LoadSceneAsync(levelindex);
        loadAsync.allowSceneActivation = false;

        while (!loadAsync.isDone)
        {
            scale.value = loadAsync.progress;
            
            if (loadAsync.progress >= .9f && !loadAsync.allowSceneActivation)
            {
                scale.value += 0.05f;
                yield return new WaitForSeconds(0.4f);
                scale.value += 0.05f;
                yield return new WaitForSeconds(0.4f);
                loadAsync.allowSceneActivation = true;
            }

            yield return null;
        }
    }





}
