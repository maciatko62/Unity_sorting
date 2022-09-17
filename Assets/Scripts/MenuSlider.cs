using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSlider : MonoBehaviour
{
    public Slider slider;
    public Text sliderText;

    private void Update()
    {
        GameObject.Find("Number").GetComponent<Text>().text = "" + slider.value;
    }

    
}
