using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ContactEnemyController : EnemyController
{
    [SerializeField] [Range(0f, 100f)] private float followRange;
    [SerializeField] private string targetTag = "Player";
    private bool _isCollidingWithTarget;

    [SerializeField] private SpriteRenderer characterRenderer;

    private HealthSystem healthSystem;
    private HealthSystem _collidingTargethealthSystem;
    private PlayerMovement _collidingMovement;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        healthSystem = GetComponent<HealthSystem>();
        healthSystem.OnDamage += OnDamage;

    }

    private void OnDamage()
    {
        followRange = 100f;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        if(_isCollidingWithTarget)
        {
            ApplyHealthChange();
        }

        Vector2 direction = Vector2.zero;

        if (DistanceToTarget() < followRange)
        {
            direction = DirectionToTarget();
        }

        CallMoveEvent(direction);
        Rotate(direction);
    }

    private void Rotate(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        characterRenderer.flipX = Mathf.Abs(rotZ) > 90f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject receiver = collision.gameObject;

        if(!receiver.CompareTag(targetTag))
        {
            return;
        }

        _collidingTargethealthSystem = GetComponent<HealthSystem>();
        if(_collidingTargethealthSystem != null)
        {
            _isCollidingWithTarget = true;
        }

        _collidingMovement = receiver.GetComponent<PlayerMovement>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(!collision.CompareTag(targetTag))
        {
            return;
        }

        _isCollidingWithTarget = false;
    }

    private void ApplyHealthChange()
    {
        AttackSO attackSO = Stats.CurrentStats.attackSO;
        bool hasBennChanged = _collidingTargethealthSystem.ChangeHealth(-attackSO.power);
        if(attackSO.isOnKnockback && _collidingMovement != null)
        {
            _collidingMovement.ApplyKnockback(transform.transform, attackSO.knockbackPower, attackSO.knockbackTime);
        }
    }
}
