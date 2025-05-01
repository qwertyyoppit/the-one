using System;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "BaseTile", menuName = "Scriptable Objects/BaseTile")]
public class BaseTile : ScriptableObject
{
    [SerializeField] int tileId;
    public int TileId => tileId;
    [SerializeField] private float maxHealth = 10f;
    public float MaxHealth => maxHealth;
    [SerializeField] private int strength;
    public int Strength => strength;
}
