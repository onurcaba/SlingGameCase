using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed = 2f;
    public float distancetMoveSpeed = 2f;
    public PlayerControls playerControls;

    Vector2 moveDirection = Vector2.zero;
    private InputAction move;

    public GameObject playerStartPoint;

    public SkinnedMeshRenderer skinnedMeshRenderer;

    float moveY;

    //private InputAction fire;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerControls = new PlayerControls();
    }
    private void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
    }

    void Update()
    {
        moveDirection = move.ReadValue<Vector2>();

        float distanceFromStartPoint = Vector3.Distance(transform.position, playerStartPoint.transform.position);

        if (distanceFromStartPoint > 1f)
        {
            moveSpeed = distancetMoveSpeed / distanceFromStartPoint;
        }

        skinnedMeshRenderer.SetBlendShapeWeight(1, distanceFromStartPoint * 20);
    }

    private void FixedUpdate()
    {
        if (moveDirection.y<0)
        {
            moveY = moveDirection.y;
        }

        rb.velocity = new Vector3(moveDirection.x * moveSpeed, rb.velocity.y, moveY * moveSpeed);
    }

}
