using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFunctions : MonoBehaviour
{
    public string MainSceneName;

    private void Start()
    {
        LoadingScreen.main.ChangeColorInstantly(Color.black);
        StartCoroutine(LoadingScreen.main.ChangeColor(Color.clear));
    }

    public void StartGame()
    {
        StartCoroutine(EStartGame());
    }

    private IEnumerator EStartGame()
    {
        yield return LoadingScreen.main.ChangeColor(Color.black);
        SceneManager.LoadScene(MainSceneName);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
