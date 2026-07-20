using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "PlayerStatusObject", menuName = "Scriptable Objects/PlayerStatusObject")]
public class PlayerStatusObject : ScriptableObject
{
    public CombatStats combatStats;

    public void ResetStats()
    {
        combatStats.ResetStats();
    }

    public void ResetHP()
    {
        combatStats.HP = combatStats.maxHP;
    }

    public void ResetMP()
    {
        combatStats.MP = combatStats.maxMP;
    }
}
