using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "BaseTile", menuName = "Scriptable Objects/BaseTile")]
public class BaseTile : TileBase
{
    public float Health = 10f;
    public int BlockStrength = 0;
}
