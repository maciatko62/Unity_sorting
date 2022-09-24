using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSort : MonoBehaviour
{
    public List<int> list;
    public PickUp pickUp;
    public AiScript ai;

    void Start()
    {
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
    }
    IEnumerator StartBuubleSort(List<int> listt)
    {
        /*
        yield return new WaitForSeconds(5);
        pickUp.PickUpL();
        //yield return new WaitForSeconds(0.5f);
        pickUp.PickUpR();
        yield return new WaitForSeconds(0.5f);
        pickUp.PickUpT();
        yield return new WaitForSeconds(0.5f);
        pickUp.RightToLeft();
        yield return new WaitForSeconds(0.5f);
        pickUp.LeftToRight();
        yield return new WaitForSeconds(0.5f);
        pickUp.DropObjectL();
        pickUp.DropObjectR();
        yield return new WaitForSeconds(0.5f);
        ai.targetPoint = 3;
        */

        int n = listt.Count;
        do
        {
            
            for (int i = 0; i < n - 1; i++)
            {
                ai.targetPoint = i;
                yield return new WaitForSeconds(1.5f);

                pickUp.PickUpL();
                pickUp.PickUpR();
                yield return new WaitForSeconds(0.5f);

                if (list[i] > list[i + 1])
                {
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

        for (int i = 0; i < listt.Count; i++)
        {
            //Debug.Log(listt[i]);
        }
    }

}
