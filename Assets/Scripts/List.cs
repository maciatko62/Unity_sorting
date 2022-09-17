using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class List : MonoBehaviour
{
    public Slider slider;
    public ArrayList list = new ArrayList();
    public int sliderValue;
    private int temp = 0;

    public void Start()
    {
        temp = Random.RandomRange(0, 10);
        list.Add(temp);
        for (int i = 1; i < 10; i++)
        {
            for (int j = 0; j < list.Count; j++)
            {
                if(temp == (int)list[j])
                {
                    temp = Random.RandomRange(1, 11);
                }
                j = 0;
            }
            list.Add(temp);
            //list.Add(i);
        }


        foreach (int x in list)
        {
            Debug.Log(x);
        }
    }

    private void Update()
    {
        sliderValue = (int)slider.value;
    }
    public void ShuffleTheNumbers()
    {

    }

}
