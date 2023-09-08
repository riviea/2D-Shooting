using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinMove : MonoBehaviour
{
    private PenguinInputController _controller;
    private Vector2 moveDir = Vector2.zero;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _controller = GetComponent<PenguinInputController>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _controller.OnMoveEvent += MovePenguin;
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = moveDir.normalized*5;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void MovePenguin(Vector2 vector)
    {
        moveDir = vector;
    }
}
