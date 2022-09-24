using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiScript : MonoBehaviour
{
    NavMeshAgent agent;
    //public Transform point;
    Animator animator;
    //private bool go = true;
    public int targetPoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
            agent.destination = GameObject.Find("Point" + targetPoint + "(Clone)").transform.position;
            animator.SetFloat("Speed", agent.velocity.magnitude);
            agent.transform.LookAt(GameObject.Find("Pointa").transform.position);
    }
    public void AiGo(int i)
    {

        Debug.Log("no hej");
    }
}
