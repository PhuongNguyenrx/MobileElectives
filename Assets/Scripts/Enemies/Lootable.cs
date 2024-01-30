using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;


public class Lootable : Damageable
{
    [SerializeField] List<Loot> possibleLoots = new List<Loot>();

    public override void Die()
    {
        if (health <= 0)
        {
            var droppedItem = GetDroppedItem();
            if (droppedItem != null)
                Instantiate(droppedItem.gameObject, transform.position, Quaternion.identity);
            GameManager.Instance.score += score;
        }
        GameManager.Instance.enemyOnScreen.Remove(transform);
        GameManager.Instance.EnemyCheck();
        Destroy(gameObject);
    }

    Loot GetDroppedItem()
    {
        int randomNumber = UnityEngine.Random.Range(1, 101);
        List<Loot> possibleItems = new List<Loot>();
        foreach(Loot item in possibleLoots)
        {
            if (randomNumber <= item.dropChance)
            {
                possibleItems.Add(item);
            }
        }
        if(possibleItems.Count > 0)
        {
            Loot droppedItem = possibleItems[UnityEngine.Random.Range(0,possibleItems.Count)];
            return droppedItem;
        }
        return null;
    }
}
