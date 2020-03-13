using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CrabController : MonoBehaviour
{
    Transform goal;
    NavMeshAgent agent;
    int health;

    void Start() {
        goal = FindObjectOfType<FirstPersonAIO>().transform;
        agent = GetComponent<NavMeshAgent>();

        health = 100;
    }

    public void Damage(int amount) {
        health -= amount;

        if (health <= 0) {
            EnemySpawner.enemyCount--;
            Destroy(gameObject);
        }
    }

    private void Update() {
        agent.destination = goal.position;
    }
}
