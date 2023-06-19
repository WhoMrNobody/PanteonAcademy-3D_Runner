using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class ClickToMove : MonoBehaviour
{
    NavMeshAgent _nMeshAgent;
    RaycastHit _hitInfo = new RaycastHit();

    void Start()
    {
        _nMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray.origin, ray.direction, out _hitInfo))
            {
                _nMeshAgent.destination = _hitInfo.point;
            }
        }
    }
}
