using UnityEngine;

//[CreateAssetMenu(fileName = "AttackObject", menuName = "Scriptable Objects/AttackObject")]
public class MoveObject : ScriptableObject
{
    public enum MoveTarget
    {
        Enemy,
        Enemies,
        Self,
        Ally,
        Party,
        All
    }
    
    public string title;
    public MoveTarget target;
    public int cost;
}
