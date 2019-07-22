using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpSize : MonoBehaviour
{
    public Vector3 minScale;
    public Vector3 maxScale;
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoopLerp());
    }

    private IEnumerator LoopLerp()
    {
        while (true)
        {
            yield return LerpScale(this.transform.localScale, maxScale, 4f);
            yield return LerpScale(this.transform.localScale, minScale, 4f);
        }
    }

    private IEnumerator LerpScale(Vector3 start, Vector3 end, float time)
    {
        float i = 0.0f;
        float rate = (1.0f / time) * speed;
        while(i < 1.0f)
        {
            i += Time.deltaTime * rate;
            transform.localScale = Vector3.Lerp(start, end, i);
            yield return new WaitForEndOfFrame();
        }
    }
}
