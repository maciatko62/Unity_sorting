using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BubbleSort : MonoBehaviour
{
    public List<int> list;
    public PickUp pickUp;
    public AiScript ai;
    public MenuScript menu;
    private bool stopTime =false;
    private int numberOfSteps = 0;

    void Start()
    {
        menu.FinalMessageOff();
        pickUp = GetComponent<PickUp>();
        for (int i = 0; i < PlayerPrefs.GetInt("listCount"); i++)
        {
            list.Add(PlayerPrefs.GetInt("list_" + i));
        }

        for (int i = 0; i < list.Count; i++)
        {
            //Debug.Log(list[i]);
        }

        StartCoroutine(StartBuubleSort(list));
        StartCoroutine(StartTime());
    }
    IEnumerator StartBuubleSort(List<int> listt)
    {

        int n = listt.Count;
        do
        {
            
            for (int i = 0; i < n - 1; i++)
            {
                ai.targetPoint = i;
                yield return new WaitForSeconds(1.5f);
                pickUp.PickUpL();
                pickUp.PickUpR();
                //numberOfSteps++;
                //GameObject.Find("TextN").GetComponent<Text>().text = "Number of steps: " + numberOfSteps;
                yield return new WaitForSeconds(0.5f);

                if (list[i] > list[i + 1])
                {
                    numberOfSteps++;
                    GameObject.Find("TextN").GetComponent<Text>().text = "Number of steps: " + numberOfSteps;
                    pickUp.PickUpT();
                    yield return new WaitForSeconds(0.5f);
                    pickUp.RightToLeft();
                    yield return new WaitForSeconds(0.5f);
                    pickUp.LeftToRight();
                    yield return new WaitForSeconds(0.5f);
                    

                    int tmp = list[i];
                    list[i] = list[i + 1];
                    list[i + 1] = tmp;
                }
                pickUp.DropObjectL();
                pickUp.DropObjectR();
                
                yield return new WaitForSeconds(0.5f);
            }
            n--;
            ai.targetPoint = 0;
            yield return new WaitForSeconds(6f);
        }
        while (n > 1);
        menu.FinalMessageOn();
        stopTime = true;
        for (int i = 0; i < listt.Count; i++)
        {
            //Debug.Log(listt[i]);
        }
    }

    IEnumerator StartTime()
    {
        yield return new WaitForSeconds(1.5f);
        //GameObject.Find("TextN").GetComponent<Text>().text = "Number of steps: 0";
        //GameObject.Find("TextT").GetComponent<Text>().text = "Sorting time: 00:00";
        for(int j = 0; j < 10; j++)
        {
            for (int i = 0; i < 60; i++)
            {
                if(stopTime == true)
                {
                    break;
                }
                if (i < 10)
                {
                    GameObject.Find("TextT").GetComponent<Text>().text = "Sorting time: 0" + j +":0" + i;
                }
                else
                {
                    GameObject.Find("TextT").GetComponent<Text>().text = "Sorting time: 0" + j + ":" + i;
                }
                yield return new WaitForSeconds(1);
            }

        }
        
    }
}
