using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    public GameObject chest;

    void Start()
    {
        for(int i = 0; i < PlayerPrefs.GetInt("listCount"); i++)
        {
            chest.name = "Chest" + i;
            Instantiate(chest, transform.position, transform.rotation);

            transform.position = new Vector3(transform.position.x + 0.7f, transform.position.y, transform.position.z);

            GameObject.FindGameObjectWithTag("1").GetComponent<TMPro.TextMeshProUGUI>().text = "" + PlayerPrefs.GetInt("list_" + i);
            GameObject.FindGameObjectWithTag("1").tag = "2";
        }
        
    }

}
