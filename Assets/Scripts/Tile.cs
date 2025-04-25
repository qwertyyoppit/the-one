using System;
using UnityEngine;

public class Block : MonoBehaviour
{
    public BlockInfo info;
    public float Health;
    public Action<Block> BlockDestroyed;

    private void Awake()
    {
        Health = info.Health;
    }

    public void Damage(float damage)
    {
        Health -= damage;

        if (Health <= 0)
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
