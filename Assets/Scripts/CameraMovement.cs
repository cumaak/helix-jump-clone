using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    BallMovement _ballMovement;
    private Vector3 _endPosition;
    void Start()
    {
        _ballMovement = GameObject.Find("Ball").GetComponent<BallMovement>();
        _endPosition = transform.position;
    }

    
    void Update()
    {
        if (_ballMovement.IsPassed == true)
        {
            _endPosition -= new Vector3(0, 3, 0);
            _ballMovement.IsPassed = false;
        }
        transform.position = Vector3.MoveTowards(transform.position, _endPosition, 7 * Time.deltaTime);
    }
}
