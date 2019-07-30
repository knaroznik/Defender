using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using System.Threading.Tasks;

public class LeaderboardData
{
    public PlaceData[] places;
    private Database database;
    public bool initComplete;

    public LeaderboardData(Database _firebaseDatabase)
    {
        places = new PlaceData[3];
        initComplete = false;
        for(int i=0; i<places.Length; i++)
        {
            places[i] = new PlaceData();
        }
        database = _firebaseDatabase;
    }

    public void UpdateData()
    {
        initComplete = false;
        database.ReadData(this);
    }

    private async void WriteData(PlaceData _newData)
    {
        await DatabaseReady();
        if (TryHighScore(_newData))
        {
            ServerWrite();
        }
    }

    private async Task DatabaseReady()
    {
        bool ready = await database.DatabaseReady();
        while (!ready && !initComplete)
        {
            await Task.Delay(5);

        }
    }
    private bool TryHighScore(PlaceData _newData)
    {
        for (int i = 0; i < 3; i++)
        {
            if (_newData.placePoints > places[i].placePoints)
            {
                PlaceData temp = places[i];
                places[i] = _newData;
                for (int j = i + 1; j < 3; j++)
                {
                    PlaceData temp2 = places[j];
                    places[j] = temp;
                    temp = temp2;
                }
                return true;
            }
        }
        return false;
    }
    //DUNNO : Wait for writing data, then setting status to false? Need it?
    private void ServerWrite()
    {
        database.SetStatus(true);
        database.UpdateObject(1, places[0].placePoints);
        database.UpdateObject(2, places[1].placePoints);
        database.UpdateObject(3, places[2].placePoints);
        database.SetStatus(false);
    }

    public void TryInsertData(PlaceData _newData)
    {
        UpdateData();
        WriteData(_newData);
    }

    public PlaceData ReadData(int _index)
    {
        return places[_index];
    }
}
