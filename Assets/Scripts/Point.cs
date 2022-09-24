using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public GameObject point;
    //public Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < PlayerPrefs.GetInt("listCount"); i++)
        {
            point.name = "Point" + i;
            Instantiate(point, transform.position, transform.rotation);

            transform.position = new Vector3(transform.position.x + 0.7f, transform.position.y, transform.position.z);

            //GameObject.FindGameObjectWithTag("1").GetComponent<TMPro.TextMeshProUGUI>().text = "" + PlayerPrefs.GetInt("list_" + i);
            //GameObject.FindGameObjectWithTag("1").tag = "2";
        }

    }
}