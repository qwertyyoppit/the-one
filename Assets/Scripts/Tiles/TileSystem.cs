using System;
using Components.Tiles;
using Object = UnityEngine.Object;

namespace Systems.Tiles
{
public abstract class TileSystem : SystemBase
{
    private void Awake()
    {
        throw new NotImplementedException();
    }

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