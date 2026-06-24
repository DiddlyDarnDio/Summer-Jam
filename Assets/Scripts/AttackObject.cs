using UnityEngine;

[CreateAssetMenu(fileName = "AttackObject", menuName = "Scriptable Objects/AttackObject")]
public class AttackObject : ScriptableObject
{
    public enum AttackType
    {
        Enemy,
        Enemies,
        Self,
        Ally,
        Party,
        All
    }
    
    public string title;
    public AttackType type;
    public int damage;
    public int cost;
    public int accuracy;
}
