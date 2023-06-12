using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _runningSpeed;
    [SerializeField] float _xSpeed;
    [SerializeField] float _limitX;
    void Start()
    {
        
    }

    
    void Update()
    {
       SwipeCheck();
    }

    void SwipeCheck()
    {
        float _touchXDelta = 0f;
        float _newX = 0f;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Debug.Log("Touched");
            _touchXDelta = Input.GetTouch(0).deltaPosition.x / Screen.width;
        }
        else if (Input.GetMouseButton(0))
        {
            _touchXDelta = Input.GetAxis("Mouse X");
        }

        _newX = transform.position.x + _xSpeed * _touchXDelta * Time.deltaTime;
        _newX = Mathf.Clamp(_newX, -_limitX, _limitX);

        Vector3 newPos = new Vector3(_newX, transform.position.y, transform.position.z + _runningSpeed * Time.deltaTime);
        transform.position = newPos;
    }
}
