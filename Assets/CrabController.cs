using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CrabController : MonoBehaviour
{
    Transform goal;
    NavMeshAgent agent;

    void Start() {
        goal = FindObjectOfType<FirstPersonAIO>().transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update() {
        agent.destination = goal.position;
    }
}
