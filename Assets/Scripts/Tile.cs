using System;
using UnityEngine;

public class Block : MonoBehaviour, IDamageable
{
    public BaseTile baseInfo;
    public BaseTile Info;
    public float health;
    public Action<Block> BlockDestroyed = delegate { };

    public Block()
    {
        Info = ScriptableObject.CreateInstance(baseInfo.GetType()) as BaseTile;
        health = baseInfo.MaxHealth;
    }

    private void Awake()
    {
        health = baseInfo.MaxHealth;
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
