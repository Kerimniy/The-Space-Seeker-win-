using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeSceneScript : MonoBehaviour {
    public GameObject pauseMenu;
    public GameObject LoadingScreen;
    public Slider scale;

    void Awake()
    {
        pauseMenu = GameObject.Find("cockpit/Main_Camera/newCanvas/PauseMenu").gameObject;

    }
    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        int sceneIndex = currentScene.buildIndex;
        
        
            if (SceneExists(sceneIndex + 1) || sceneIndex == 5)
            {
                if (linkst.object_count == 5 && Input.GetKeyDown(KeyCode.Space) && linkst.IsInCollider == true)
                {
                    if (sceneIndex == 5)
                    {
                    LoadingScreen.SetActive(true);
                    StartCoroutine(LoadAsync(0));
                }
                else { 
                    linkst.object_count = 0;
                    linkst.LevelComplete[sceneIndex - 1] = 1;
                    //SceneManager.LoadSceneAsync(sceneIndex + 1);

                    switch (sceneIndex - 1)
                    {
                        case 0:
                            PlayerPrefs.SetInt("AccesLevel0", linkst.LevelComplete[sceneIndex - 1]); PlayerPrefs.Save();
                            break;
                        case 1:
                            PlayerPrefs.SetInt("AccesLevel1", linkst.LevelComplete[sceneIndex - 1]); PlayerPrefs.Save();
                            break;
                        case 2:
                            PlayerPrefs.SetInt("AccesLevel2", linkst.LevelComplete[sceneIndex - 1]); PlayerPrefs.Save();
                            break;
                        case 3:
                            PlayerPrefs.SetInt("AccesLevel3", linkst.LevelComplete[sceneIndex - 1]); PlayerPrefs.Save();
                            break;

                    }
                    LoadingScreen.SetActive(true);
                    StartCoroutine(LoadAsync(sceneIndex + 1));
                }
                

            }

            }


            if (Input.GetKeyDown(KeyCode.Escape) && pauseMenu.activeSelf == false)
            {   
                pauseMenu.SetActive(!pauseMenu.activeSelf);
                Time.timeScale = 0f;
                

            }
            else if (Input.GetKeyDown(KeyCode.Escape)&& pauseMenu.activeSelf == true)
            {
  
              Resume();

            }



    }
        public void Resume()
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }

        public void returnMenu()
        {
        linkst.object_count = 0;
        LoadingScreen.SetActive(true);
        Time.timeScale = 1f;
        StartCoroutine(LoadAsync(0));
        
        }


    bool SceneExists(int sceneIndex)
    {
        if (sceneIndex < SceneManager.sceneCountInBuildSettings) return true;
        else return false;
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
