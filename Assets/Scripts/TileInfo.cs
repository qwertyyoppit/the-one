using UnityEngine;

[CreateAssetMenu(fileName = "BlockInfo", menuName = "Scriptable Objects/BlockInfo")]
public class BlockInfo : ScriptableObject
{
    public float Health = 10f;
    public int BlockStrength = 0;
}
