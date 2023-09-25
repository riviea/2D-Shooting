using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInputController _controller;
    private CharacterStatsHandler _stats;

    private Vector2 _movementDir = Vector2.zero;
    private Rigidbody2D _rigidBody;

    private Vector2 _knockback = Vector2.zero;
    private float knockbackDuration = 0.0f;

    // Start is called before the first frame update
    void Awake()
    {
        _controller = GetComponent<PlayerInputController>();
        _stats = GetComponent<CharacterStatsHandler>();
        _rigidBody = GetComponent<Rigidbody2D>();    
    }

    private void Start()
    {
        _controller.OnMoveEvent += Move;
    }

    private void FixedUpdate()
    {
        ApllyMovement(_movementDir);
        if(knockbackDuration>0.0f)
        {
            knockbackDuration -= Time.fixedDeltaTime;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ApplyKnockback(Transform other, float power, float duration)
    {
        knockbackDuration = duration;
        _knockback = -(other.position - transform.position).normalized * power;
    }

    private void Move(Vector2 direction)
    {
        _movementDir = direction;
    }

    private void ApllyMovement(Vector2 direction)
    {
        direction = direction * _stats.CurrentStats.speed;
        if(knockbackDuration > 0.0f)
        {
            direction += _knockback;
        }
        _rigidBody.velocity = direction;
    }
}
