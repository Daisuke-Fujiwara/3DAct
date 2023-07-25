using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // ���s���x
    public float walkSpeed;
    // ���s���x
    public float sprintSpeed;

    private float _moveSpeed;

    //x�������̓��͂�ۑ�
    private float _vertical;
    //z�������̓��͂�ۑ�
    private float _horizontal;

    // transform�̃L���b�V��
    private Transform _transform;

    public MovementState state;

    public enum MovementState
    {
        walking,
        sprinting,
        idling,
        air
    }

    public Animator PlayerAnimator;



    private void Awake()
    {
        _transform = transform;
    }

    void Start()
    {

    }

    void Update()
    {
        StateHandler();
        InputHandler();
    }

    private void FixedUpdate()
    {
        AttackHandler();
    }

    private void StateHandler()
    {
        // shift���͗L���ړ����͗L
        if (Input.GetKey(KeyCode.LeftShift) & (_vertical != 0 || _horizontal != 0))
        {
            state = MovementState.sprinting;
            _moveSpeed = sprintSpeed;
            PlayerAnimator.SetBool("sprinting", true);
        }
        // �ړ����͗L
        else if(_vertical != 0 || _horizontal != 0)
        {
            state = MovementState.walking;
            _moveSpeed = walkSpeed;
            PlayerAnimator.SetBool("walking", true);
        }
        // �ړ����͖�
        else if (_vertical == 0 || _horizontal == 0)
        {
            state = MovementState.idling;
            PlayerAnimator.SetBool("sprinting", false);
            PlayerAnimator.SetBool("walking", false);
            _moveSpeed = 0;
        }
    }

    private void InputHandler()
    {
        // ���͎擾
        _vertical = Input.GetAxis("Vertical");
        _horizontal = Input.GetAxis("Horizontal");
        var horizontalRotation = Quaternion.AngleAxis(Camera.main.transform.eulerAngles.y, Vector3.up);

        Vector3 velocity = new Vector3(_horizontal, 0, _vertical);
        Vector3 direction = horizontalRotation * velocity.normalized;

        float distance = _moveSpeed * Time.deltaTime;
        Vector3 destination = _transform.position + direction * distance;

        _transform.LookAt(destination);

        _transform.position = destination;
    }

    private void AttackHandler()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PlayerAnimator.SetBool("attack", true);
        }
    }
}
