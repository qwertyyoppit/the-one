using System;
using UnityEngine;

[Serializable]
public class BaseTile
{
    [SerializeField] private string tileId = "base";
    public string TileId => tileId;
    [SerializeField] private float maxHealth = 10f;
    public float MaxHealth => maxHealth;
    [SerializeField] private int strength;
    public int Strength => strength;
}
