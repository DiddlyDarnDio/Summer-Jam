using System;
using TMPro;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public static CombatManager instance;
    [SerializeField] private GameObject buttonLayer1;
    [SerializeField] private GameObject attackButtons;
    [SerializeField] private GameObject spellButtons;

    private void Awake()
    {
        instance = this;
        buttonLayer1.SetActive(true);
        attackButtons.SetActive(false);
        spellButtons.SetActive(false);
    }

    public void ExcecuteAttack(AttackObject attackObject)
    {
        
    }
}
