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



        //StartCoroutine(StartBuubleSort(list));
        StartCoroutine(StartInsertionSort(list));
        //StartCoroutine(QuickSort(list,0, list.Count-1));

        StartCoroutine(StartTime());
    }

    IEnumerator StartInsertionSort(List<int> listt)
    {
        

        int n = listt.Count;
        for (int i = 1; i < n; ++i)
        {
            
            int key = listt[i];
            int j = i - 1;
            //ai = j
            //podnieœ klucz L

            ai.targetPoint = j;
            yield return new WaitForSeconds(4);
            pickUp.PickUpL();
            yield return new WaitForSeconds(2);


            //zmieniaj pozycje  [j] dopóki 
            while (j >= 0 && listt[j] > key)
            {
                
                //podnieœ j R
                pickUp.PickUpR();
                yield return new WaitForSeconds(0.5f);
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



            //podnieœ R
            if (pickUp.heldObjL != null)
            {
                pickUp.DropObjectL();
            }

            yield return new WaitForSeconds(1);
            listt[j + 1] = key;
        }
    }

    IEnumerator QuickSort(List<int> listt, int left, int right)
    {
        ai.targetPoint = left; // ai idzie na lew¹ strone tablicy
        yield return new WaitForSeconds(6f);
        

        var i = left;
        var j = right;
        var pivot = listt[left];
        
        //yield return new WaitForSeconds(1.5f);
        

        while (i <= j)
        {
            
            ai.targetPoint = i;
            yield return new WaitForSeconds(1.5f);
            pickUp.PickUpR();
            yield return new WaitForSeconds(0.5f);

            

            while (listt[i] < pivot)
            {
                i++;
                
            }

            ai.targetPoint = j;
            yield return new WaitForSeconds(1.5f);
            

            while (listt[j] > pivot)
            {
                j--;
                ai.targetPoint = j;
                yield return new WaitForSeconds(1.5f);
            }

            




            if (i <= j)
            {
                ai.targetPoint = j-1;
                yield return new WaitForSeconds(1.5f);
                pickUp.PickUpL();
                yield return new WaitForSeconds(0.5f);

                ai.targetPoint = j;
                yield return new WaitForSeconds(1.5f);
                pickUp.DropObjectR();
                yield return new WaitForSeconds(1.5f);

                ai.targetPoint = i;
                yield return new WaitForSeconds(5);
                pickUp.LeftToRight();
                yield return new WaitForSeconds(1.5f);
                pickUp.DropObjectR();
                yield return new WaitForSeconds(1.5f);


                int temp = listt[i];
                listt[i] = listt[j];
                listt[j] = temp;
                i++;
                j--;
            }
            else
            {
                ai.targetPoint = i;
                yield return new WaitForSeconds(5);
                pickUp.DropObjectR();
                yield return new WaitForSeconds(1.5f);

            }

        }
        Debug.Log("----------------------------------------");
        for (int k = 0; k < listt.Count; k++)
        {
            Debug.Log(listt[k]);
        }
        


        
        if (left < j)
            StartCoroutine(QuickSort(listt, left, j));
        yield return new WaitForSeconds(100);
        Debug.Log("robie lewe");
        if (i < right)
            StartCoroutine(QuickSort(listt, i, right));
        yield return new WaitForSeconds(10);
        Debug.Log("robie prawe");

        /*
        for (int k = 0; k < listt.Count; k++)
        {
            Debug.Log(listt[k]);
        }
        */
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
        for (int i = 0; i < listt.Count; i++)
        {
            //Debug.Log(listt[i]);
        }
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
