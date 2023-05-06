using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyReferences : MonoBehaviour
{

    [Header("Stats")]
    public float pathUpdateDelay = 0.2f;

    public UnityEngine.AI.NavMeshAgent navMeshagent;
    public Animator animator;


    // Start is called before the first frame update
    private void Awake() {
        navMeshagent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator = GetComponent<Animator>();
    }


 
}
