using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Opponent : MonoBehaviour
{
    [SerializeField] Transform _target;

    NavMeshAgent _opponentAgent;
    void Start()
    {
        _opponentAgent = GetComponent<NavMeshAgent>();
        
    }
    void Update()
    {
        _opponentAgent.SetDestination(_target.transform.position);
    }
}
