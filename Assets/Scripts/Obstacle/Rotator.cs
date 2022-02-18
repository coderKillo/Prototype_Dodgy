using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : BasicObstacle
{
    [SerializeField]
    private float m_rotationSpeed = 10;

    void Start()
    {

    }

    void Update()
    {
        transform.Rotate(0, m_rotationSpeed * Time.deltaTime, 0);
    }
}
