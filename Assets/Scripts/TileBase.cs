using System;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "BaseTile", menuName = "Scriptable Objects/BaseTile")]
public class BaseTile : Tile, IDamageable
{
    public float maxHealth = 10f;
    public int strength;

    public float health;

    public Action<Tile> TileDestroyed = delegate { };

    public void Damage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            DestroyTile();
        }
    }

    public void DestroyTile()
    {
        Destroy(gameObject);
        TileDestroyed?.Invoke(this);
    }
}
