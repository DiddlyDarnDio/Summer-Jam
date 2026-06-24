using System;
using TMPro;
using UnityEngine;

public class EnemyCombatantBehaviour : CombatantBehaviour
{
    [SerializeField] private TextMeshProUGUI healthText;
    public int maxHealth;
    private int currentHealth;

    private void Start()
    {
        CurrentHealth = maxHealth;
    }

    public int CurrentHealth
    {
        get { return currentHealth; }
        set
        {
            if (currentHealth != value)
            {
                currentHealth = value;
                if (currentHealth < 0)
                {
                    currentHealth = 0;
                }

                if (currentHealth > maxHealth)
                {
                    currentHealth = maxHealth;
                }
                healthText.text = $"HP: {currentHealth}/{maxHealth}";
            }
        }
    }

    public override void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
    }
}
