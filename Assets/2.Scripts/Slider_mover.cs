using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;   

public class Slider_mover : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI text;
    private float Value = 0.5f;
    private int p = 50;
    public void slider_plus()
    {
        if (Value < 1f)
        {
            Value += 0.1f;
            p += 10;
        }
        text.text = p.ToString()+"%";
        slider.GetComponent<Slider>().value = Value;
    }
    public void slider_minus()
    {
        if (Value > 0.01f)
        {
            Value -= 0.1f;
            p -= 10;
        }
        text.text = p.ToString() + "%";
        slider.GetComponent<Slider>().value = Value;
    }
}
