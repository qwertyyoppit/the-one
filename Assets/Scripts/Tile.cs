using System;
using UnityEngine;
using Systems.Clicking;
using Components.Clicking;
using Systems.Tiles;

namespace Components.Tiles
{
public class Block : MonoBehaviour
{
    public BaseTile Info;
    public float health;
    public Action<Block> BlockDestroyed = delegate { };

    private void Start()
    {
        health = Info.MaxHealth;
        
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