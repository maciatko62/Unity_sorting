using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSort : MonoBehaviour
{
    public List<int> list;
    public PickUp pickUp;

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

        int n = listt.Count;
        do
        {
            for (int i = 0; i < n - 1; i++)
            {
                if (list[i] > list[i + 1])
                {
                    int tmp = list[i];
                    list[i] = list[i + 1];
                    list[i + 1] = tmp;
                }
            }
            n--;
        }
        while (n > 1);

        for (int i = 0; i < listt.Count; i++)
        {
            //Debug.Log(listt[i]);
        }
    }

}
