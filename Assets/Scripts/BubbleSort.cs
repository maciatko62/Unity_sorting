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
    private bool stopTime = false;
    private int numberOfSteps = 0;

    void Start()
    {
        menu.FinalMessageOff();
        pickUp = GetComponent<PickUp>();

        for (int i = 0; i < PlayerPrefs.GetInt("listCount"); i++)
        {
            list.Add(PlayerPrefs.GetInt("list_" + i));
        }

        StartCoroutine(StartTime());

        if (PlayerPrefs.GetInt("Sort") == 1)
        {
            StartCoroutine(StartBuubleSort(list));
        }
        else if(PlayerPrefs.GetInt("Sort") == 2)
        {
            StartCoroutine(StartInsertionSort(list));
        }
        else
        {
            StartCoroutine(StartShellSort(list));
        }

        
    }

    IEnumerator StartShellSort(List<int> listt)
    {

        int n = listt.Count;

        for (int gap = n / 2; gap > 0; gap /= 2)
        {

            for (int i = gap; i < n; i++)
            {
                int temp = listt[i];

                ai.targetPoint = i - 1;
                yield return new WaitForSeconds(6);
                numberOfSteps++;

                GameObject.Find("TextN").GetComponent<Text>().text = "Number of steps: " + numberOfSteps;
                pickUp.PickUpL();
                yield return new WaitForSeconds(2);

                int j;
                for (j = i; j >= gap && listt[j - gap] > temp; j -= gap)
                {
                    listt[j] = listt[j - gap];

                    ai.targetPoint = j -gap;
                    yield return new WaitForSeconds(4);
                    numberOfSteps++;
                    GameObject.Find("TextN").GetComponent<Text>().text = "Number of steps: " + numberOfSteps;
                    pickUp.PickUpR();
                    yield return new WaitForSeconds(2);

                    numberOfSteps++;
                    GameObject.Find("TextN").GetComponent<Text>().text = "Number of steps: " + numberOfSteps;
                    pickUp.PickUpT();
                    yield return new WaitForSeconds(0.5f);
                    pickUp.RightToLeft();
                    yield return new WaitForSeconds(0.5f);
                    pickUp.TopToRight();
                    yield return new WaitForSeconds(2);


                    pickUp.DropObjectR();
                    yield return new WaitForSeconds(2);
                    ai.targetPoint = i - 1;
                    yield return new WaitForSeconds(4);
                }

                if(pickUp.heldObjL != null)
                {
                    pickUp.DropObjectL();
                    yield return new WaitForSeconds(2);
                }
                listt[j] = temp;
            }
        }

        menu.FinalMessageOn();
        stopTime = true;
    }

    IEnumerator StartInsertionSort(List<int> listt)
    {
        yield return new WaitForSeconds(2);

        int n = listt.Count;
        for (int i = 1; i < n; ++i)
        {
            int key = listt[i];
            int j = i - 1;
            //ai = j
            //podnieœ klucz L

            ai.targetPoint = j;
            yield return new WaitForSeconds(4);

            numberOfSteps++;
            GameObject.Find("TextN").GetComponent<Text>().text = "Number of steps: " + numberOfSteps;
            pickUp.PickUpL();
            yield return new WaitForSeconds(2);


            //zmieniaj pozycje  [j] dopóki 
            while (j >= 0 && listt[j] > key)
            {
                numberOfSteps++;
                GameObject.Find("TextN").GetComponent<Text>().text = "Number of steps: " + numberOfSteps;
                //podnieœ j R
                pickUp.PickUpR();
                yield return new WaitForSeconds(0.5f);

                numberOfSteps++;
                GameObject.Find("TextN").GetComponent<Text>().text = "Number of steps: " + numberOfSteps;
                //podmianka
                pickUp.PickUpT();
                yield return new WaitForSeconds(0.5f);
                pickUp.RightToLeft();
                yield return new WaitForSeconds(0.5f);
                pickUp.TopToRight();
                yield return new WaitForSeconds(0.5f);
                pickUp.DropObjectL();
                yield return new WaitForSeconds(0.5f);
                pickUp.RightToLeft();
                yield return new WaitForSeconds(0.5f);

                listt[j + 1] = listt[j];
                j = j - 1;                

                //ai = j
                if (j >=0)
                {
                    ai.targetPoint = j;
                    yield return new WaitForSeconds(2);
                    
                }
                else
                {
                    //R->L
                    pickUp.LeftToRight();
                    yield return new WaitForSeconds(1);
                    pickUp.DropObjectR();
                    yield return new WaitForSeconds(1);
                }
            }

            //
            if (pickUp.heldObjL != null)
            {
                pickUp.DropObjectL();
            }

            yield return new WaitForSeconds(1);
            listt[j + 1] = key;
        }
        menu.FinalMessageOn();
        stopTime = true;
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
                numberOfSteps++;
                GameObject.Find("TextN").GetComponent<Text>().text = "Number of steps: " + numberOfSteps;
                yield return new WaitForSeconds(0.5f);

                if (list[i] > list[i + 1])
                {
                    numberOfSteps++;
                    GameObject.Find("TextN").GetComponent<Text>().text = "Number of steps: " + numberOfSteps;
                    pickUp.PickUpT();
                    yield return new WaitForSeconds(0.1f);
                    pickUp.RightToLeft();
                    yield return new WaitForSeconds(0.1f);
                    pickUp.TopToRight();
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

    }


    IEnumerator StartTime()
    {
        yield return new WaitForSeconds(1.5f);
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
