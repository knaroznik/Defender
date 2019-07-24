using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardData
{
    private PlaceData[] places;

    public LeaderboardData()
    {
        places = new PlaceData[3];
        for(int i=0; i<3; i++)
        {
            places[i] = new PlaceData();
            if (!PlayerPrefs.HasKey((i + 1).ToString()))
            {
                PlayerPrefs.SetInt((i + 1).ToString(), 0);
            }
        }
        
    }

    //PlayerPrefs -> GoogleDocs
    public void UpdateData()
    {
        places[0].placePoints = PlayerPrefs.GetInt("1");
        places[1].placePoints = PlayerPrefs.GetInt("2");
        places[2].placePoints = PlayerPrefs.GetInt("3");
    }

    private void WriteData()
    {
        PlayerPrefs.SetInt("1", places[0].placePoints);
        PlayerPrefs.SetInt("2", places[1].placePoints);
        PlayerPrefs.SetInt("3", places[2].placePoints);
    }


    public void TryInsertData(PlaceData _newData)
    {
        UpdateData();
        for(int i=0; i<3; i++)
        {
            if(_newData.placePoints > places[i].placePoints)
            {
                PlaceData temp = places[i];
                places[i] = _newData;
                for (int j=i+1; j< 3; j++)
                {
                    PlaceData temp2 = places[j];
                    places[j] = temp;
                    temp = temp2;
                }
                WriteData();
                return;
            }
        }


    }

    public PlaceData ReadData(int _index)
    {
        return places[_index-1];
    }
}
