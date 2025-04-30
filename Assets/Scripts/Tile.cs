using System;
using UnityEngine;

public class Block : MonoBehaviour, IDamageable
{
    public BaseTile info;
    public float health;
    public Action<Block> BlockDestroyed = delegate { };

    private void Awake()
    {
        health = info.maxHealth;
    }

    public void Damage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            DestroyBlock();
        }
    }

    public void DestroyBlock()
    {
        BlockDestroyed?.Invoke(this);
        Destroy(gameObject);
    }
}
