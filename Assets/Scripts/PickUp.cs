using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public float pickUpRange = 5; // 5
    public Transform holdParent;
    private GameObject heldObj;
    public float moveForce = 250;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(heldObj == null)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(0,5.5f,1), out hit, pickUpRange))
                {
                    Debug.Log("Clicked on " + hit.transform.name);
                    PickUpObject(hit.transform.gameObject);
                }
            }
            else
            {
                DropObject();
            }

        }

        if(heldObj != null)
        {
            MoveObject();
        }
    }

    void MoveObject()
    {
        if(Vector3.Distance(heldObj.transform.position, holdParent.position) > 0.1f) //0.1f
        {
            Vector3 moveDirection = (holdParent.position - heldObj.transform.position);
            heldObj.GetComponent<Rigidbody>().AddForce(moveDirection * moveForce);
        }
    }

    void PickUpObject(GameObject pickObj)
    {
        if (pickObj.GetComponent<Rigidbody>())
        {
            Rigidbody objRig = pickObj.GetComponent<Rigidbody>();
            objRig.useGravity = false;
            objRig.drag = 10;

            heldObj = pickObj;
        }
    }

    void DropObject()
    {
        Rigidbody heldRig = heldObj.GetComponent<Rigidbody>();
        heldObj.GetComponent<Rigidbody>().useGravity = true;
        heldRig.drag = 1;
        heldObj.transform.parent = null;
        heldObj = null;

    }
}
