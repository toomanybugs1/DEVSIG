using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CrabController : MonoBehaviour
{
    Transform goal;
    NavMeshAgent agent;
    [SerializeField] int health = 100;
    int fullHealth;


    RectTransform healthBar;

    void Start() {
        goal = FindObjectOfType<FirstPersonAIO>().transform;
        agent = GetComponent<NavMeshAgent>();
        healthBar = GetComponentInChildren<HealthBar>().GetComponent<RectTransform>();

        fullHealth = health;
    }

    public void Damage(int amount) {
        health -= amount;

        if (health <= 0) {
            EnemySpawner.enemyCount--;
            Destroy(gameObject);
        }

        healthBar.sizeDelta = new Vector2(((float)health / fullHealth) * 10f, 1f);
    }

    private void Update() {
        agent.destination = goal.position;
    }
}
