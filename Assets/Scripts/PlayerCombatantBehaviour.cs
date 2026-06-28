using TMPro;
using UnityEngine;

public class PlayerCombatantBehaviour : CombatantBehaviour
{
    public PlayerStatusObject playerStatus;
    public TextMeshProUGUI playerHealth;
    public TextMeshProUGUI playerMana;

    private void Awake()
    {
        playerHealth.text = $"HP: {playerStatus.Health}/{playerStatus.maxHealth}";
        playerMana.text = $"MP: {playerStatus.Mana}/{playerStatus.maxMana}";
    }
    public override void TakeDamage(int damage)
    {
        playerStatus.Health -= damage;
    }
}
