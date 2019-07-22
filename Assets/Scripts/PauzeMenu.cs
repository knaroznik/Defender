using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauzeMenu : MonoBehaviour
{
    public static PauzeMenu main;
    public GameObject DeathUIObject;
    public GameObject PauzeAddUIObject;

    public bool pauzeOn = false;

    private void Awake()
    {
        main = this;
    }
    
    public void PlayAgain()
    {
        StartCoroutine(EPlayAgain());
    }

    private IEnumerator EPlayAgain()
    {
        Time.timeScale = 1f;
        DeathUIObject.SetActive(false);
        PauzeAddUIObject.SetActive(false);
        yield return StartCoroutine(LoadingScreen.main.ChangeColor(Color.black));
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //CO JEŚLI NIE JEST EKRAN CZARNY
    public void MainMenu()
    {
        StartCoroutine(EMainMenu());   
    }

    private IEnumerator EMainMenu()
    {
        Time.timeScale = 1f;
        DeathUIObject.SetActive(false);
        PauzeAddUIObject.SetActive(false);
        yield return StartCoroutine(LoadingScreen.main.ChangeColor(Color.black));
        SceneManager.LoadScene(0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauzeOn)
            {
                Resume();
            }
            else
            {
                Pauze();
            }
        }
    }

    public void Pauze()
    {
        DeathUIObject.SetActive(true);
        PauzeAddUIObject.SetActive(true);
        Time.timeScale = 0f;
        pauzeOn = true;
    }

    public void Resume()
    {
        DeathUIObject.SetActive(false);
        PauzeAddUIObject.SetActive(false);
        Time.timeScale = 1f;
        pauzeOn = false;
    }
}
