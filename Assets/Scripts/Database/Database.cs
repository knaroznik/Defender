using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public abstract class Database : MonoBehaviour
{
    public abstract Task<bool> DatabaseReady();
    public abstract void UpdateObject(int position, int score);
    public abstract void SetStatus(bool value);
    public abstract void ReadData(LeaderboardData parent);
}


