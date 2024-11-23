using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] Animator playerAnimator;
    [SerializeField] NavMeshAgent playerNavMeshAgent;
    
    void Update()
    {
        playerAnimator.SetFloat("Speed", playerNavMeshAgent.velocity.magnitude);
    }
}
