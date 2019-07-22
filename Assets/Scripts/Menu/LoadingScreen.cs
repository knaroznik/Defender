using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    public static LoadingScreen main;
    public Image loadingScreenImage;
    private Color wantedColor;

    private void Awake()
    {
        main = this;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            loadingScreenImage.color = wantedColor;
        }
    }

    public IEnumerator ChangeColor(Color c)
    {
        if (loadingScreenImage.color == c)
        {
            yield return null;
        }
        else
        {
            yield return StartCoroutine(EChangeColor(loadingScreenImage.color, c, 1f));
        }
    }

    public void ChangeColorInstantly(Color c)
    {
        loadingScreenImage.color = c;
        loadingScreenImage.gameObject.SetActive(true);
    }

    private IEnumerator EChangeColor(Color start, Color end, float time)
    {
        loadingScreenImage.gameObject.SetActive(true);
        wantedColor = end;
        float i = 0.0f;
        float rate = (1.0f / time) * 1;
        while (i < 1.0f)
        {
            if(loadingScreenImage.color == wantedColor)
            {
                if (end == Color.clear)
                {
                    loadingScreenImage.gameObject.SetActive(false);
                }
                yield break;
            }
            i += Time.deltaTime * rate;
            loadingScreenImage.color = Color.Lerp(start, end, i);
            yield return new WaitForEndOfFrame();
        }

        if(end == Color.clear)
        {
            loadingScreenImage.gameObject.SetActive(false);
        }
    }
}
