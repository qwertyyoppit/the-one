using System.Collections.Generic;
using UnityEngine;

public class Stats
{
    private StatSet _baseStats;

    public Stats(StatSet baseStats)
    {
        _baseStats = baseStats;
    }

    private float ProcessBaseStat(StatType type)
    {
        if (_baseStats.GetStat(type, out float statValue))
        {
            return statValue;
        }
        return 1f;
    }

    public float MoveAcceleration
    {
        get => ProcessBaseStat(StatType.MoveAcceleration);
    }

    public float MoveSpeed
    {
        get => ProcessBaseStat(StatType.MoveSpeed);
    }

    public float JumpHeight
    {
        get => ProcessBaseStat(StatType.JumpHeight);
    }
}
