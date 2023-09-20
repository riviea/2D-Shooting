using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : PlayerInputController
{
    GameManager gameManager;
    protected Transform CloseTarget { get; private set; }

    protected override void Awake()
    {
        base.Awake();
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        gameManager = GameManager.Instance;
        CloseTarget = gameManager.Player;
    }

    protected virtual void FixedUpdate()
    {

    }

    protected float DistanceToTarget()
    {
        return Vector3.Distance(transform.position, CloseTarget.position);
    }

    protected Vector2 DirectionToTarget()
    {
        return (CloseTarget.position - transform.position).normalized;
    }

}
