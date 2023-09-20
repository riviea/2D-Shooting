using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatsHandler : MonoBehaviour
{
    [SerializeField] private CharacterStats baseStats;
    public CharacterStats CurrentStates { get; private set; }
    public List<CharacterStats> statsModifers = new List<CharacterStats>();

    private void Awake()
    {
        UpdateCharacterStats();
    }

    private void UpdateCharacterStats()
    {
        AttackSO attackSO = null;
        if (baseStats.attackSO)
        {
            attackSO = Instantiate(baseStats.attackSO);
        }

        CurrentStates = new CharacterStats { attackSO = attackSO };

        CurrentStates.statsChangeType = baseStats.statsChangeType;
        CurrentStates.maxHealth = baseStats.maxHealth;
        CurrentStates.speed = baseStats.speed;
    }
}
