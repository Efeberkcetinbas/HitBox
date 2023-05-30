using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyMovement : MonoBehaviour
{
    public bool isDead=false;

    [SerializeField] private bool canMove;

    public NavMeshAgent agent;
    public Transform player;


    [SerializeField] private Animator animator;

    private void Update() 
    {
        if(canMove && !isDead)
        {
            agent.SetDestination(player.position);
            animator.SetBool("Run",true);
        }
    }

}
