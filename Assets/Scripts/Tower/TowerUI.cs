using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerUI : MonoBehaviour
{
    public Slider healhtSlider;

    public void UpdateHealth(int _value)
    {
        healhtSlider.value = _value;
    }

    public Text pointsText;

    public void UpdatePoints(int _value)
    {
        pointsText.text = "Points : " + _value;
    }
}
