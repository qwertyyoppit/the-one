using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileData : MonoBehaviour, IDamageable
{
    [NonSerialized] public readonly BaseTile baseTile;
    [NonSerialized] public int ID = 0;
    [NonSerialized] public float Health = 10;
    [NonSerialized] public int Strength = 0;

    public void Damage(float damage)
    {
        Health -= damage;

        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
