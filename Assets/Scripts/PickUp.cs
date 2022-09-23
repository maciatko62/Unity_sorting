using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public float pickUpRange = 5; // 5
    public Transform holdParentR;
    public Transform holdParentL;
    private GameObject heldObjR;
    private GameObject heldObjL;
    public float moveForce = 250;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(heldObjR == null)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(0, 0.5f, 1), out hit, pickUpRange)) //5.5f  transform.TransformDirection(0,0,1)  transform.TransformDirection(Vector3.forward)
                {
                    Debug.Log("Clicked on " + hit.transform.name);
                    PickUpObjectR(hit.transform.gameObject);
                }
            }
            else
            {
                DropObjectR();
            }

        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (heldObjL == null)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(0, -0.5f, 1), out hit, pickUpRange)) //5.5f  transform.TransformDirection(0,0,1)  transform.TransformDirection(Vector3.forward)
                {
                    Debug.Log("Clicked on " + hit.transform.name);
                    PickUpObjectL(hit.transform.gameObject);
                }
            }
            else
            {
                DropObjectL();
            }

        }

        if (heldObjR != null)
        {
            MoveObjectR();
        }
        if (heldObjL != null)
        {
            MoveObjectL();
        }
    }

    void MoveObjectR()
    {
        if(Vector3.Distance(heldObjR.transform.position, holdParentR.position) > 0.1f) //0.1f
        {
            Vector3 moveDirection = (holdParentR.position - heldObjR.transform.position);
            heldObjR.GetComponent<Rigidbody>().AddForce(moveDirection * moveForce);
        }
    }
    void MoveObjectL()
    {
        if(Vector3.Distance(heldObjL.transform.position, holdParentL.position) > 0.1f) //0.1f
        {
            Vector3 moveDirection = (holdParentL.position - heldObjL.transform.position);
            heldObjL.GetComponent<Rigidbody>().AddForce(moveDirection * moveForce);
        }
    }

    void PickUpObjectR(GameObject pickObj)
    {
        if (pickObj.GetComponent<Rigidbody>())
        {
            Rigidbody objRig = pickObj.GetComponent<Rigidbody>();
            objRig.useGravity = false;
            objRig.drag = 20;

            heldObjR = pickObj;
        }
    }
    void PickUpObjectL(GameObject pickObj)
    {
        if (pickObj.GetComponent<Rigidbody>())
        {
            Rigidbody objRig = pickObj.GetComponent<Rigidbody>();
            objRig.useGravity = false;
            objRig.drag = 20;

            heldObjL = pickObj;
        }
    }

    void DropObjectR()
    {
        Rigidbody heldRig = heldObjR.GetComponent<Rigidbody>();
        heldObjR.GetComponent<Rigidbody>().useGravity = true;
        heldRig.drag = 1;
        heldObjR.transform.parent = null;
        heldObjR = null;

    }
    void DropObjectL()
    {
        Rigidbody heldRig = heldObjL.GetComponent<Rigidbody>();
        heldObjL.GetComponent<Rigidbody>().useGravity = true;
        heldRig.drag = 1;
        heldObjL.transform.parent = null;
        heldObjL = null;

    }
}
