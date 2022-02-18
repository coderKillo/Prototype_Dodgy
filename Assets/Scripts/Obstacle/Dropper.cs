using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    [SerializeField] private Transform m_droppedObject;
    [SerializeField] private float m_delay = 0;

    private Rigidbody m_rigidbody;
    private LineRenderer m_lineRenderer;

    void Start()
    {
        m_lineRenderer = GetComponent<LineRenderer>();

        m_rigidbody = m_droppedObject.GetComponent<Rigidbody>();
        m_rigidbody.useGravity = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(DelayDrop());
    }

    IEnumerator DelayDrop()
    {
        yield return new WaitForSeconds(m_delay);
        m_rigidbody.useGravity = true;
        m_lineRenderer.enabled = false;
    }
}
