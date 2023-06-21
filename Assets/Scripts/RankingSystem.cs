using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingSystem : MonoBehaviour
{
    public float Distance;
    public GameObject Target;
    public int Rank;
    void Start()
    {
        
    }

    
    void Update()
    {
        CalculateDistance();
    }

    void CalculateDistance()
    {
        Distance = Vector3.Distance(transform.position, Target.transform.position);
    }
}
