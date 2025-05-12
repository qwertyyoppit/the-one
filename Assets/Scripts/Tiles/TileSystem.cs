using UnityEngine;

namespace Tiles.Tiles
{
public abstract class TileSystem
{
    public static void DamageTile(Block tile, float damage)
    {
        tile.health -= damage;

        if (tile.health <= 0)
        {
            DestroyBlock(tile);
        }
    }

    public static void DestroyBlock(Block tile)
    {
        tile.BlockDestroyed?.Invoke(tile);
        Object.Destroy(tile.gameObject);
    }
}
}