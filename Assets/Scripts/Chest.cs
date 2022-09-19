using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    public GameObject chest;
    //public Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 1; i <= 15; i++)
        {
            chest.name = "Chest" + i;
            Instantiate(chest, transform.position, transform.rotation);

            transform.position = new Vector3(transform.position.x + 0.6f, transform.position.y, transform.position.z);
            //chest = GameObject.Find("/Chest0/CanvasSW/Text (TMP)");
            //GameObject.Find("Chest0(Clone)/CanvaSW/Text (TMP)").GetComponent<TMPro.TextMeshProUGUI>().text = "" + i;
            //GameObject.Find("Chest5(Clone)").GetComponent<TMPro.TextMeshProUGUI>().text = "" + i;

            //GameObject.Find("Text (TMP)").GetComponent<TMPro.TextMeshProUGUI>().text = "" + i;
            GameObject.FindGameObjectWithTag("1").GetComponent<TMPro.TextMeshProUGUI>().text = "" + i;
            GameObject.FindGameObjectWithTag("1").tag = "2";
        }
        

        //chest = new GameObject("ch");
        //chest.gameObject.GetComponentInParent = this.gameObject;

        //chest.transform.position = new Vector3(3, 5, 0);

        //GameObject newObject = new GameObject("ab");
        //Instantiate(chest, pos.position, pos.rotation);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
