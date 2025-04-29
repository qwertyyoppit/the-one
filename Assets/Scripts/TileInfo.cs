using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "BaseTile", menuName = "Scriptable Objects/BaseTile")]
public class BaseTile : Tile
{
    public float health = 10f;
    public int strength;
}
