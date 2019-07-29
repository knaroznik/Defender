using Firebase;
using Firebase.Unity.Editor;
using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class FirebaseConnect : MonoBehaviour
{
    public string DataBaseUrl;
    // Start is called before the first frame update
    void Awake()
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl(DataBaseUrl);
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.GetReference("LeaderBoard");
    }

    public void ReadDataOnce(FirebaseLoadItems actionAfterLoad)
    {
        FirebaseDatabase.DefaultInstance
      .GetReference("LeaderBoard")
      .GetValueAsync().ContinueWith(task => {
          if (task.IsFaulted)
          {
              // Handle the error...
          }
          else if (task.IsCompleted)
          {
              DataSnapshot snapshot = task.Result;
              actionAfterLoad.Invoke(snapshot);
          }
      });
    }

    public async Task<bool> DatabaseReady()
    {
        DataSnapshot output = await FirebaseDatabase.DefaultInstance.GetReference("loading").GetValueAsync();
        return !bool.Parse(output.Value.ToString());
    }

    public void UpdateOnce(int position, int score)
    {
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.GetReference("LeaderBoard");
        reference.Child(position.ToString()).SetValueAsync(score);
    }

    public void UpdateOnce(string key, bool value)
    {
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
        reference.Child(key).SetValueAsync(value);
    }

    private void HandleChildAdded(DataSnapshot arg)
    {
        Debug.Log(arg.Value.ToString() + " - " + arg.Key.ToString());

    }


}

public delegate void FirebaseLoadItems(DataSnapshot d);