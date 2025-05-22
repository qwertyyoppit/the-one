using System;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public StatSet BaseStats;
    public Stats Stats;

    public GameObject uid;

    private void Awake()
    {
        uid = gameObject;
        Stats = new Stats(BaseStats);
    }
}
