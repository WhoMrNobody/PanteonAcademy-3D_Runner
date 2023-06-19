using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAnim : MonoBehaviour
{
    [SerializeField] float _speed = 1f;
    [SerializeField] float _strenght = 2.5f;

    float _randomOfset;
    // Start is called before the first frame update
    void Start()
    {
        _randomOfset = Random.Range(-_strenght, _strenght);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Sin(Time.deltaTime * _speed * _randomOfset) * _strenght;
        transform.position = pos;
    }
}
