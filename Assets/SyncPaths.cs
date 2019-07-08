using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncPaths : MonoBehaviour
{

    public List<Path> scenePaths;

    public void SynchronizePaths()
    {
        Path p = GetLongestPath();
        for(int i=0; i<scenePaths.Count; i++)
        {
            if (scenePaths[i] == p) continue;

            SyncPath(p, scenePaths[i]);
        }
    }

    private Path GetLongestPath()
    {
        Path output = scenePaths[0];
        for (int i = 0; i < scenePaths.Count; i++)
        {
            if(scenePaths[i].Length() > output.Length())
            {
                output = scenePaths[i];
            }
        }
        return output;
    }

    private void SyncPath(Path original, Path copy)
    {
        if(original.Length() == copy.Length())
        {
            SyncPositions(original, copy);
        }
        else
        {
            AddPositions(original, copy);
            SyncPositions(original, copy);
        }
    }

    private void AddPositions(Path original, Path copy)
    {
        int diff = original.Length() - copy.Length();
        for(int i=0; i<diff; i++)
        {
            copy.AddDefaultPoint();
        }
    }

    private void SyncPositions(Path original, Path copy)
    {
        int length = original.Length();
        for (int i = 0; i < length; i++)
        {
            copy.GetTransform(i).localPosition = original.GetTransform(i).localPosition;
        }
    }
}
