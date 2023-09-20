using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    private ProjectileManager _projectileManager;
    private PlayerInputController controller;

    [SerializeField] private Transform projectilePivot;
    private Vector2 _aimDir = Vector2.right;

    private void Awake()
    {
        controller = GetComponent<PlayerInputController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _projectileManager = ProjectileManager.Instance;
        controller.OnAttackEvent += OnShoot;
        controller.OnLookEvent += OnAim;
        
    }

    private void OnAim(Vector2 newAimDir)
    {
        _aimDir = newAimDir;
    }

    private void OnShoot(AttackSO attackSO)
    {
        RangedAttackData rangedAttackData = attackSO as RangedAttackData;
        float projectilesAngleSpace = rangedAttackData.multipleProjectilesAngel;
        int numberOfProjectilesPerShot = rangedAttackData.numberofProjectilesPerShot;

        float minAngle = (numberOfProjectilesPerShot / 2f) * projectilesAngleSpace * 0.5f * rangedAttackData.multipleProjectilesAngel;

        for (int i = 0; i < numberOfProjectilesPerShot; ++i)
        {
            float angle = minAngle + projectilesAngleSpace * i;
            float randomSpread = UnityEngine.Random.Range(-rangedAttackData.spread, rangedAttackData.spread);
            angle += randomSpread;
            CreateProjectile(rangedAttackData, angle);
        }
    }

    private void CreateProjectile(RangedAttackData rangedAttackData, float angle)
    {
        _projectileManager.ShootBullet(
            projectilePivot.position,
            RotateVector2(_aimDir, angle),
            rangedAttackData);
        //Instantiate(projectile, projectilePivot.position, Quaternion.identity);
    }

    private static Vector2 RotateVector2(Vector2 v, float degree)
    {
        return Quaternion.Euler(0, 0, degree) * v;
    }
}
