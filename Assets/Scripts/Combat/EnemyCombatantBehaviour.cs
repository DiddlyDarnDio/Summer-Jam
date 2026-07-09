using System;
using TMPro;
using UnityEngine;

public class EnemyCombatantBehaviour : CombatantBehaviour
{
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private CombatStats combatStats;

    public override CombatStats CombatStats
    {
        get { return combatStats; }
    }

    private void OnEnable()
    {
        combatStats.onHPChanged += TakeDamage;
    }

    private void Start()
    {
        combatStats.HP = combatStats.maxHP;
    }

    public override void TakeDamage(int damage)
    {
        combatStats.HP -= damage;
    }
}
