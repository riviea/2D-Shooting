using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    private PlayerInputController controller;

    [SerializeField] private Transform projectilePivot;
    private Vector2 _aimDir = Vector2.right;

    [SerializeField] private GameObject projectile;

    private void Awake()
    {
        controller = GetComponent<PlayerInputController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        controller.OnAttackEvent += OnShoot;
        controller.OnLookEvent += OnAim;
    }

    private void OnAim(Vector2 newAimDir)
    {
        _aimDir = newAimDir;
    }

    private void OnShoot()
    {
        CreateProjectile();
    }

    private void CreateProjectile()
    {
        Instantiate(projectile, projectilePivot.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
