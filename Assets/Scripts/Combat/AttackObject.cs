using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackObject", menuName = "Scriptable Objects/AttackObject")]
public class AttackObject : MoveObject
{
    public int damage;
    [Range(0, 100)] public int accuracy = 100;

    public override void PerformMove(CombatantBehaviour user, List<CombatantBehaviour> targets)
    {
        foreach (CombatantBehaviour target in targets)
        {
            target.TakeDamage(damage);
        }
    }
}
