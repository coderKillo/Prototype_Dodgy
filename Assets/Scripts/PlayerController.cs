using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float m_movementSpeed = 10;
    [SerializeField] private float m_rotationSpeed = 2;

    // INPUT
    private Vector2 m_input_move;

    // COMPONENT REFERENCES
    private CharacterController m_characterController;
    private Animator m_animator;

    // ANIMATOR CONST
    private int horizontal;
    private int vertical;

    void Start()
    {
        m_characterController = GetComponent<CharacterController>();
        m_animator = GetComponent<Animator>();

        horizontal = Animator.StringToHash("Horizontal");
        vertical = Animator.StringToHash("Vertical");
    }

    void Update()
    {
        var moveDir = new Vector3(m_input_move.x, 0, m_input_move.y);

        TurnTowardsMovement(moveDir);

        m_characterController.Move(moveDir * m_movementSpeed * Time.deltaTime);
        m_animator.SetFloat(vertical, moveDir.magnitude);
    }

    // --------------------------------------------------

    private void TurnTowardsMovement(Vector3 moveDir)
    {
        if (moveDir == Vector3.zero)
        {
            return;
        }

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDir), m_rotationSpeed * Time.deltaTime);
    }

    // --------------------------------------------------

    private void OnMove(InputValue value)
    {
        m_input_move = value.Get<Vector2>();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        var mesh = hit.gameObject.GetComponent<MeshRenderer>();

        if (mesh)
        {
            if (mesh.material.color != Color.red)
            {
                mesh.material.color = Color.red;
                GameManager.instance.PlayerHit();
            }
        }
    }
}
