using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject chest;
    //public Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 10; i++)
        {
            Instantiate(chest, transform.position, transform.rotation);
            transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
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
