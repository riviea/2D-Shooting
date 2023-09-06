using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInputController _controller;
    private Vector2 _movementDir = Vector2.zero;
    private Rigidbody2D _rigidBody;


    // Start is called before the first frame update
    void Awake()
    {
        _controller = GetComponent<PlayerInputController>();
        _rigidBody = GetComponent<Rigidbody2D>();    
    }

    private void Start()
    {
        _controller.OnMoveEvent += Move;
    }

    private void FixedUpdate()
    {
        ApllyMovement(_movementDir);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Move(Vector2 direction)
    {
        _movementDir = direction;
    }

    private void ApllyMovement(Vector2 direction)
    {
        direction = direction * 5;
        _rigidBody.velocity = direction;
    }
}
