using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinAI : MonoBehaviour
{
    public float speed = 3.0f;
    public float attackRange = 1.0f;
    public int attackDamage = 10;
    public float attackCooldown = 1.0f;

    private Transform player;
    private float attackTimer = 0.0f;

    private enum State
    {
        Idle,
        Chase,
        Attack
    }

    private State currentState = State.Idle;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        switch (currentState)
        {
            case State.Idle:
                // If the player is within range, switch to the Chase state
                if (Vector3.Distance(transform.position, player.position) <= attackRange * 5)
                {
                    currentState = State.Chase;
                }
                break;
            case State.Chase:
                // Move towards the player
                transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

                // If the player is within attack range, switch to the Attack state
                if (Vector3.Distance(transform.position, player.position) <= attackRange)
                {
                    currentState = State.Attack;
                }
                break;
            case State.Attack:
                // Attack the player if the attack is off cooldown
                if (attackTimer <= 0.0f)
                {
                    Attack();
                    attackTimer = attackCooldown;
                }

                // If the player moves out of range, switch back to the Chase state
                if (Vector3.Distance(transform.position, player.position) > attackRange)
                {
                    currentState = State.Chase;
                }
                break;
        }

        // Decrement the attack timer
        attackTimer -= Time.deltaTime;
    }

    void Attack()
    {
        // Damage the player
        //player.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
    }
}