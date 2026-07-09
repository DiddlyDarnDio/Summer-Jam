using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerCombatantBehaviour : CombatantBehaviour
{
    public PlayerStatusObject playerStatus;
    public TextMeshProUGUI playerHPText;
    public TextMeshProUGUI playerMPText;
    public bool resetOnStart = false;

    public override CombatStats CombatStats
    {
        get
        {
            return playerStatus.combatStats;
        }
    }

    private void Awake()
    {
        if (resetOnStart)
        {
            playerStatus.ResetStats();
        }
        playerHPText.text = $"HP: {playerStatus.combatStats.HP}/{playerStatus.combatStats.maxHP}";
        playerMPText.text = $"MP: {playerStatus.combatStats.MP}/{playerStatus.combatStats.maxMP}";
    }
    public override void TakeDamage(int damage)
    {
        playerStatus.combatStats.HP -= damage;
    }

    private void onHPChanged(int value)
    {
        playerHPText.text = $"HP: {playerStatus.combatStats.HP}/{playerStatus.combatStats.maxHP}";
    }

    private void OnDeath()
    {
        Debug.Log("You are dead, make death do something");
    }
    
    private void OnMPChanged(int value)
    {
        playerMPText.text = $"MP: {playerStatus.combatStats.MP}/{playerStatus.combatStats.maxMP}";
    }
}
