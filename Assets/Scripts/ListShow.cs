using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListShow : MonoBehaviour
{
    private string task;
    [SerializeField]  public List<int> list;
    // Start is called before the first frame update
    void Start()
    {
        list = GetComponent<List<int>>();
        //YourList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void YourList()
    {
        task = "";
        for (int i = 0; i < list.Count; i++)
        {
            task = task + PlayerPrefs.GetInt("list_" + i) + ", ";
        }
        GameObject.Find("YourList").GetComponent<Text>().text = task;
    }
}
