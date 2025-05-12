using System;
using UnityEngine;
using Clicking.Clicking;

namespace Tiles.Tiles
{
public class Block : MonoBehaviour
{
    public BaseTile baseInfo;
    public BaseTile Info;
    public float health;
    public Action<Block> BlockDestroyed = delegate { };

    private void Start()
    {
        ClickingSystem.ClickedAction += OnClick;
        return;

        void OnClick(GameObject arg1, ClickingComponent arg2)
        {
            if (arg1.TryGetComponent<Block>(out var block))
            {
                TileSystem.DamageTile(block, 10f);
            }
        }
    }
}
}