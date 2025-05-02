using System;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "BaseTile", menuName = "Scriptable Objects/BaseTile")]
public class BaseTile : ScriptableObject
{
    [SerializeField] private string tileId;
    public string TileId => tileId;
    [SerializeField] private float maxHealth = 10f;
    public float MaxHealth => maxHealth;
    [SerializeField] private int strength;
    public int Strength => strength;

    public GameObject tileCreated;

    public Block CreateBlock()
    {
        var newBlock = Instantiate(tileCreated).GetComponent<Block>();
        newBlock.Info = this;
        return newBlock;
    }
}
