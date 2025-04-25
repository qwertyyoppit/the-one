using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StatSet", menuName = "Scriptable Objects/StatSet")]
public class StatSet : ScriptableObject
{
    [SerializeField] private List<Stat> statList;

    public bool GetStat(StatType type, out float statValue)
    {
        foreach (Stat stat in statList)
        {
            if (stat.Type == type)
            {
                statValue = stat.Value;
                return true;
            }
        }
        statValue = 0f;
        return false;
    }
}
