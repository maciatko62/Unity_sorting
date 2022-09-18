using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSlider : MonoBehaviour
{
    public Slider slider;
    public Text sliderText;

    public void Updated()
    {
        GameObject.Find("Number").GetComponent<Text>().text = "" + slider.value;
    }
    public void Start()
    {
        GameObject.Find("Number").GetComponent<Text>().text = "" + slider.value;
    }

}
