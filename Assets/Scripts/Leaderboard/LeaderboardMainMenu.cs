using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardMainMenu : MonoBehaviour
{

    public List<Text> texts;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EStart());
    }

    IEnumerator EStart()
    {
        while (!Leaderboard.main.InitComplete)
        {
            yield return new WaitForFixedUpdate();
        }
        for (int i = 0; i < 3; i++)
        {
            texts[i].text = Leaderboard.main.ReadData(i).placePoints.ToString();
        }
    }
}
