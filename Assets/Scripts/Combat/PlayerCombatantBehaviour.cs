using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerCombatantBehaviour : CombatantBehaviour
{
    public PlayerStatusObject playerStatus;
    public TextMeshProUGUI playerHPText;
    public TextMeshProUGUI playerMPText;
    public GameObject SelectButtons;
    public GameObject BackButtons;
    public bool resetOnStart = false;

    public override CombatStats CombatStats
    {
        get
        {
            return playerStatus.combatStats;
        }
    }

    public override void Initialize()
    {
        if (resetOnStart)
        {
            playerStatus.ResetStats();
        }
        playerHPText.text = $"HP: {playerStatus.combatStats.HP}/{playerStatus.combatStats.maxHP}";
        playerMPText.text = $"MP: {playerStatus.combatStats.MP}/{playerStatus.combatStats.maxMP}";
        SelectButtons.SetActive(false);
        BackButtons.SetActive(false);
    }
    
    private void OnEnable()
    {
        CombatStats.onHPChanged += OnHPChanged;
        CombatStats.onMPChanged += OnMPChanged;
    }

    private void OnDisable()
    {
        CombatStats.onHPChanged -= OnHPChanged;
        CombatStats.onMPChanged -= OnMPChanged;
    }

    private void OnHPChanged(int value)
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
