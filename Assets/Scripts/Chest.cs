using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject chest;
    public Transform pos;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(chest, pos.position, pos.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
