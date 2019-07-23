using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingText : MonoBehaviour
{
    Animator animator;
    Text damage_text;

    public void Start()
    {
        animator = GetComponentInChildren<Animator>();
        damage_text = animator.GetComponent<Text>();
        AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
        Destroy(this.gameObject, clipInfo[0].clip.length);
    }

    public void SetText(string _value)
    {
        damage_text.text = _value;
    }
}
