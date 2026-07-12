using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "AttackObject", menuName = "Scriptable Objects/AttackObject")]
public abstract class MoveObject : ScriptableObject
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

    public virtual void PerformMove(CombatantBehaviour user, List<CombatantBehaviour> targets)
    {
        Debug.LogWarning("Move not implemented");
    }
}
