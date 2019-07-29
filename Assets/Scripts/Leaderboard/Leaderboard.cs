using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    public static Leaderboard main;
    private LeaderboardData data;
    public FirebaseConnect firebaseDatabase;
    public bool InitComplete
    {
        get
        {
            return data.initComplete;
        }
    }

    private void Awake()
    {
        if(main == null)
        {
            main = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        Initialize();
    }

    private void Initialize()
    {
        if(data == null)
        {
            data = new LeaderboardData(firebaseDatabase);
            data.UpdateData();
        }
    }

    public void UpdateData()
    {
        data.UpdateData();
    }

    public void TryInsert(PlaceData _newData)
    {
        data.TryInsertData(_newData);
    }
    
    public PlaceData ReadData(int _index)
    {
        return data.ReadData(_index);
    }
}
