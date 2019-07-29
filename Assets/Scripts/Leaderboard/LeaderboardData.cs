using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using System.Threading.Tasks;

public class LeaderboardData
{
    private PlaceData[] places;
    private FirebaseConnect firebaseDatabase;
    public bool initComplete;

    public LeaderboardData(FirebaseConnect _firebaseDatabase)
    {
        places = new PlaceData[3];
        initComplete = false;
        for(int i=0; i<places.Length; i++)
        {
            places[i] = new PlaceData();
        }
        firebaseDatabase = _firebaseDatabase;
    }

    public void UpdateData()
    {
        initComplete = false;
        firebaseDatabase.ReadDataOnce(PlaceData);
    }

    private void PlaceData(DataSnapshot data)
    {
        int i = 0;
        foreach (DataSnapshot d in data.Children)
        {
            int x;
            int.TryParse(d.Value.ToString(), out x);
            places[i].placePoints = x;
            i++;
        }
        initComplete = true;
    }

    //ROZBIĆ
    private async void WriteData(PlaceData _newData)
    {
        
        bool ready = await firebaseDatabase.DatabaseReady();
        while (!ready && !initComplete)
        {
            await Task.Delay(5);

        }
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
                break;
            }
        }
        
        firebaseDatabase.UpdateOnce("loading", true);
        firebaseDatabase.UpdateOnce(1, places[0].placePoints);
        firebaseDatabase.UpdateOnce(2, places[1].placePoints);
        firebaseDatabase.UpdateOnce(3, places[2].placePoints);
        firebaseDatabase.UpdateOnce("loading", false);
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
