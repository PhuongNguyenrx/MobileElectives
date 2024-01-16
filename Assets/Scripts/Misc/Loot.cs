using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]

[RequireComponent(typeof(Collider2D))]
public class Loot: MonoBehaviour
{
    public float dropChance;
    public float addedStats;
    public LootEffect lootEffect;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.TryGetComponent<PlayerBehaviour>(out PlayerBehaviour playerBehaviour))
        {
            switch (lootEffect)
            {
                case LootEffect.increaseDamage:
                    playerBehaviour.IncreaseDamage(addedStats);
                    break;
                case LootEffect.increaseSpeed:
                    playerBehaviour.IncreaseSpeed(addedStats);
                    break;
                case LootEffect.increaseHealth:
                    playerBehaviour.IncreaseHealth(addedStats);
                    break;
                case LootEffect.reduceReload:
                    playerBehaviour.ReduceReload(addedStats);
                    break;
                default:
                    break;
            }
            Destroy(gameObject);
        }
    }

}
public enum LootEffect
{
    increaseDamage,
    increaseSpeed,
    increaseHealth,
    reduceReload
}
