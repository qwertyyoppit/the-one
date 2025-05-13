using System;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public StatSet BaseStats;
    public Stats Stats;

    private void Awake()
    {
        Stats = new Stats(BaseStats);
    }
}
