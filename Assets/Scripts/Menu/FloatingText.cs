using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingText : ObjectPoolAble
{
    Animator animator;
    Text damage_text;

    public void Start()
    {
        animator = GetComponentInChildren<Animator>();
        animator.Play(animator.GetCurrentAnimatorClipInfo(0)[0].clip.name, 0, 0);
        damage_text = animator.GetComponent<Text>();
        AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
        StartCoroutine(Wait(clipInfo[0].clip.length));
    }

    public void SetPosition(Vector3 towerPosition)
    {
        this.transform.position = Camera.main.WorldToScreenPoint(towerPosition);
        this.transform.rotation = Quaternion.Euler(Vector3.zero);
    }

    private IEnumerator Wait(float waitSeconds)
    {
        yield return new WaitForSeconds(waitSeconds);
        Destroy();
    }

    public void SetText(string _value)
    {
        damage_text.text = _value;
    }
}
