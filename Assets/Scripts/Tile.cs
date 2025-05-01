using System;
using UnityEngine;

public class Block : MonoBehaviour, IDamageable
{
    public BaseTile info;
    public float health;
    public Action<Block> BlockDestroyed = delegate { };

    public Block()
    {
        health = info.MaxHealth;
    }

    private void Awake()
    {
        health = info.MaxHealth;
        GetComponent<SpriteRenderer>().forceRenderingOff = true;
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
