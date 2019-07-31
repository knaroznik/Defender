using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardMainMenu : MonoBehaviour
{
    public List<ChartColumn> columns;
    public GameObject LeaderBoardOverLay;
    public float Offset = 0.01f;
    public float MinSpeed = 0.4f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InitChart());
    }

    IEnumerator InitChart()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            SetPanelActive(false);
        }
        else
        {
            SetPanelActive(true);
            while (!Leaderboard.main.InitComplete)
            {
                yield return new WaitForFixedUpdate();
            }

            int highScore = Leaderboard.main.ReadData(0).placePoints;
            for (int i = 0; i < 3; i++)
            {
                int localScore = Leaderboard.main.ReadData(i).placePoints;
                columns[i].columnText.text = localScore.ToString();
                float scale = (float)localScore / (float)highScore;
                StartCoroutine(ShowColumn(columns[i].column.transform, scale));
            }
        }
    }

    public void OnClickReconnectButton()
    {
        StartCoroutine(InitChart());
    }

    private void SetPanelActive(bool _value)
    {
        LeaderBoardOverLay.SetActive(!_value);
        for (int i = 0; i < 3; i++)
        {
            columns[i].gameObject.SetActive(_value);
        }
    }

    IEnumerator ShowColumn(Transform column, float scale)
    {

        float i = 0.0f;
        float rate = 0.05f / scale;
        while (i < 1.0)
        {
            i += Time.deltaTime * rate;
            column.localScale = new Vector3(1f, Mathf.Lerp(column.localScale.y, scale, i), 1f);
            yield return new WaitForEndOfFrame();
        }
        
    }
}
