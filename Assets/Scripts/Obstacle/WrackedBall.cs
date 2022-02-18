using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrackedBall : MonoBehaviour
{
    private LineRenderer m_lineRenderer;
    private HingeJoint m_joint;

    // Start is called before the first frame update
    void Start()
    {
        m_joint = GetComponent<HingeJoint>();

        m_lineRenderer = GetComponent<LineRenderer>();
        m_lineRenderer.SetPosition(1, m_joint.connectedAnchor);

    }

    // Update is called once per frame
    void Update()
    {
        m_lineRenderer.SetPosition(0, transform.position);
    }
}
