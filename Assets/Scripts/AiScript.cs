using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiScript : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform point;
    Animator animator;
    //private Vector3 temp;
    private bool go = true;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (go == true) {
            agent.destination = GameObject.Find("Point1(Clone)").transform.position;
            animator.SetFloat("Speed", agent.velocity.magnitude);
            agent.transform.LookAt(GameObject.Find("Pointa").transform.position);

        }


    }
}
