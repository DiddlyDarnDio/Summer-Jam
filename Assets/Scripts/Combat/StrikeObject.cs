using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StrikeObject", menuName = "Scriptable Objects/StrikeObject")]
public class StrikeObject : MoveObject
{
    public override void PerformMove(CombatantBehaviour user, List<CombatantBehaviour> targets)
    {
        foreach (CombatantBehaviour target in targets)
        {
            target.TakeDamage(user.CombatStats.atk);
        }
    }
}
