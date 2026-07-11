using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyCombatantBehaviour : CombatantBehaviour
{
    public List<AttackObject> attacks;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private CombatStats combatStats;
    public GameObject targetButton;

    public override CombatStats CombatStats
    {
        get { return combatStats; }
    }

    public override void Initialize()
    {
        combatStats.ResetStats();
        healthText.text = $"HP: {combatStats.HP}/{combatStats.maxHP}";
    }

    private void OnEnable()
    {
        combatStats.onHPChanged += OnHPChanged;
    }

    private void OnDisable()
    {
        combatStats.onHPChanged -= OnHPChanged;
    }

    public override void TakeDamage(int damage)
    {
        combatStats.HP -= damage;
    }
    
    private void OnHPChanged(int value)
    {
        healthText.text = $"HP: {combatStats.HP}/{combatStats.maxHP}";
    }
}
