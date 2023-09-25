using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItemModifier : PickupItem
{
    [SerializeField] private List<CharacterStats> statsModifier;

    protected override void OnPickedUp(GameObject receiver)
    {
        CharacterStatsHandler statsHandler = receiver.GetComponent<CharacterStatsHandler>();
        foreach (CharacterStats characterStats in statsModifier)
        {
            statsHandler.AddStatModifer(characterStats);
        }
    }
}
