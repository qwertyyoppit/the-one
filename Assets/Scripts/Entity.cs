using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] private StatSet _baseStatSet;
    public Stats Stats;

    private void Awake()
    {
        Stats = new Stats(_baseStatSet);
    }
}
