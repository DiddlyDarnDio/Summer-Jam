using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public static CombatManager instance;
    [SerializeField] private GameObject buttonLayer1;
    [SerializeField] private GameObject attackButtons;
    [SerializeField] private GameObject spellButtons;
    private PlayerCombatantBehaviour playerCombatant;
    private EnemyCombatantBehaviour[] enemyCombatants;

    private void Awake()
    {
        instance = this;
        buttonLayer1.SetActive(true);
        attackButtons.SetActive(false);
        spellButtons.SetActive(false);
        playerCombatant = FindAnyObjectByType<PlayerCombatantBehaviour>();
        enemyCombatants = FindObjectsByType<EnemyCombatantBehaviour>(FindObjectsSortMode.None);
    }

    public void ExcecuteMove(MoveObject moveObject, CombatantBehaviour target)
    {
        if (moveObject is AttackObject attackObject)
        {
            ExecuteAttack(attackObject, target);
        }
        else if (moveObject is BuffObject buffObject)
        {
            ExecuteBuff(buffObject, target);
        }
    }

    private void ExecuteAttack(AttackObject attackObject, CombatantBehaviour target)
    {
        target.TakeDamage(attackObject.damage);
    }

    private void ExecuteBuff(BuffObject buffObject, CombatantBehaviour target)
    {
        
    }

    public void SelectMove(MoveObject moveObject, CombatantBehaviour sender)
    {
        if (moveObject.target == MoveObject.MoveTarget.Self)
        {
            ExcecuteMove(moveObject, sender);
        }
        if (moveObject.target == MoveObject.MoveTarget.Enemy)
        {
            if (sender is PlayerCombatantBehaviour)
            {
                ExcecuteMove(moveObject, enemyCombatants[0]);
            }
            else if (sender is EnemyCombatantBehaviour)
            {
                ExcecuteMove(moveObject, playerCombatant);
            }
        }
        if (moveObject.target == MoveObject.MoveTarget.Enemies)
        {
            
        }
        if (moveObject.target == MoveObject.MoveTarget.All)
        {
            
        }
    }
}
