using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public float pickUpRange = 5; // 5
    public Transform holdParentR;
    public Transform holdParentL;
    public Transform holdParentT; //top
    private GameObject heldObjR;
    private GameObject heldObjL;
    private GameObject heldObjT;
    public float moveForce = 250;

    private void Update()
    {

        if (heldObjR != null)
        {
            MoveObjectR();
        }
        if (heldObjL != null)
        {
            MoveObjectL();
        }
        if (heldObjT != null)
        {
            MoveObjectT();
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

    void MoveObjectT()
    {
        if (Vector3.Distance(heldObjT.transform.position, holdParentT.position) > 0.1f) //0.1f
        {
            Vector3 moveDirection = (holdParentT.position - heldObjT.transform.position);
            heldObjT.GetComponent<Rigidbody>().AddForce(moveDirection * moveForce);
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
    void PickUpObjectT(GameObject pickObj)
    {
        if (pickObj.GetComponent<Rigidbody>())
        {
            Rigidbody objRig = pickObj.GetComponent<Rigidbody>();
            objRig.useGravity = false;
            objRig.drag = 20;

            heldObjT = pickObj;
        }
    }

    public void DropObjectR()
    {
        Rigidbody heldRig = heldObjR.GetComponent<Rigidbody>();
        heldObjR.GetComponent<Rigidbody>().useGravity = true;
        heldRig.drag = 1;
        heldObjR.transform.parent = null;
        heldObjR = null;

    }
    public void DropObjectL()
    {
        Rigidbody heldRig = heldObjL.GetComponent<Rigidbody>();
        heldObjL.GetComponent<Rigidbody>().useGravity = true;
        heldRig.drag = 1;
        heldObjL.transform.parent = null;
        heldObjL = null;

    }

    public void PickUpR()
    {
        if (heldObjR == null)
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

    public void PickUpL()
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
    public void PickUpT()
    {
        if (heldObjL != null & heldObjR != null)
        {
            heldObjL.transform.position = holdParentT.position;
            heldObjT = heldObjL;
            heldObjL = null;
            MoveObjectT();
        }
        else
        {
            //DropObjectL();
        }
    }

    public void RightToLeft()
    {
        if (heldObjL == null & heldObjR != null)
        {
            heldObjR.transform.position = holdParentL.position;
            heldObjL = heldObjR;
            heldObjR = null;
            MoveObjectL();
        }
        else
        {
            //DropObjectL();
        }
    }
    public void LeftToRight()
    {
        if (heldObjL != null & heldObjR == null)
        {
            heldObjT.transform.position = holdParentR.position;
            heldObjR = heldObjT;
            heldObjT = null;
            MoveObjectR();
        }
        else
        {
            //DropObjectL();
        }
    }
}
