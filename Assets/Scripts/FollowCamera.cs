using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] Transform _targetTransform;
    [SerializeField] float _followSpeed = 10f;
    [SerializeField] Vector3 _distance;
    [SerializeField] Transform _lookTarget;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 dPos = _targetTransform.position + _distance;
        Vector3 sPos = Vector3.Lerp(transform.position, dPos, _followSpeed * Time.deltaTime);
        transform.position = sPos;
        transform.LookAt(_lookTarget);
    }
}
