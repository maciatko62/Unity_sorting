using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class List : MonoBehaviour
{
    public Slider slider;
    public List<int> list;
    //public int listCount;
    public int sliderValue;
    private int temp = 0;

    

    public void Start()
    {
        sliderValue = (int)slider.value;
        if (temp == 0){
            ShuffleTheNumbers();
        }
        

    }
    /*
    private void Update()
    {
        sliderValue = (int)slider.value;
    }*/
    public void ShuffleTheNumbers()
    {
        sliderValue = (int)slider.value;
        list.Clear();

        // Zapisanie d³ugoœæ listy
        PlayerPrefs.SetInt("listCount", sliderValue);

        //wype³nienie listy od 1 do x
        for (int i = 1; i <= sliderValue; i++)
        {
            list.Add(i);
        }

        // Stworzenie i zapisanie w pamiêci pomieszanej listy bez powtórzeñ

        int j; // losowany indeks z listy
        j = Random.RandomRange(0, list.Count);
        for (int i = 0; i < sliderValue; i++)
        {
            while (list[j] == 0) //jeœli wybra³eœ t¹ sam¹ liczbê (czyli pozycjê)
            {
                j = Random.RandomRange(0, list.Count); //losuj ponownie
            }
            PlayerPrefs.SetInt("list_" + i, list[j]); //wstawienie wylosowanej liczby
            list[j] = 0; //wyzerowanie miejsca, ¿eby nie powtarzaæ liczb
        }

        Debug.Log("Kontrola");

        //wypisanie pomieszanej listy z pamiêci
        for (int i = 0; i < list.Count; i++)
            Debug.Log(PlayerPrefs.GetInt("list_" + i));

        //wypisanie wyzerowanej listy
        for (int i = 0; i < list.Count; i++)
            Debug.Log(list[i]);

        temp = 1;
        Debug.Log(temp);
    }

}
