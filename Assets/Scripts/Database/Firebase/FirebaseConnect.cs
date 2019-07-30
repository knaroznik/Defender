using Firebase;
using Firebase.Unity.Editor;
using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class FirebaseConnect : Database
{
    public string DataBaseUrl;

    void Awake()
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl(DataBaseUrl);
    }
    
    //TO WORK WITH - WAY OF RETURNING PLACES
    public override void ReadData(LeaderboardData parent)
    {
        FirebaseDatabase.DefaultInstance.GetReference("LeaderBoard").GetValueAsync().ContinueWith(task => {
              if (task.IsFaulted)
              {
                    Debug.LogWarning("Reading data from firebase failed. Exception : " + task.Exception);
                    return;
              }
              else if (task.IsCompleted)
              {
                DataSnapshot data = task.Result;
                PlaceData[] output = new PlaceData[3];
                int i = 0;
                foreach (DataSnapshot d in data.Children)
                {
                    int x = 0;
                    int.TryParse(d.Value.ToString(), out x);
                    output[i] = new PlaceData();
                    output[i].placePoints = x;
                    i++;
                }
                parent.initComplete = true;
                parent.places = output;
            }
          });
        
    }

    public override void SetStatus(bool value)
    {
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
        reference.Child("loading").SetValueAsync(value);
    }

    public override async Task<bool> DatabaseReady()
    {
        DataSnapshot output = await FirebaseDatabase.DefaultInstance.GetReference("loading").GetValueAsync();
        return !bool.Parse(output.Value.ToString());
    }

    public override void UpdateObject(int position, int score)
    {
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.GetReference("LeaderBoard");
        reference.Child(position.ToString()).SetValueAsync(score);
    }
}