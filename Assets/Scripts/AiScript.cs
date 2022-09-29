using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiScript : MonoBehaviour
{
    NavMeshAgent agent;
    Animator animator;
    public int targetPoint = 0;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
            agent.destination = GameObject.Find("Point" + targetPoint + "(Clone)").transform.position;
            animator.SetFloat("Speed", agent.velocity.magnitude);
            agent.transform.LookAt(GameObject.Find("Pointa").transform.position);
    }

}
