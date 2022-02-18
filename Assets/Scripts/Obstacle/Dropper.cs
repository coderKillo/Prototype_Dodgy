using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    [SerializeField] private float m_timeToWait = 3f;

    private Rigidbody m_rigidbody;

    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_rigidbody.useGravity = false;
    }

    void Update()
    {
        if (Time.time > m_timeToWait)
        {
            m_rigidbody.useGravity = true;
        }
    }
}
