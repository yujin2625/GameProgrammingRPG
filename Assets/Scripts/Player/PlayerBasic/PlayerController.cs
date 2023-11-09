using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public partial class PlayerController : MonoBehaviour
{
    private NavMeshAgent m_navAgent;
    private Animator m_anim;
    private Tools tools;

    private void Awake()
    {
        m_anim = GetComponentInChildren<Animator>();
        m_navAgent = GetComponent<NavMeshAgent>();

    }
    private void Update()
    {
        
    }
}
