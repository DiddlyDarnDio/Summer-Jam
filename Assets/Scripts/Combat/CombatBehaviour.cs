using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CombatBehaviour : MonoBehaviour
{
    private CombatState rootState;
    public static CombatBehaviour instance;
    [SerializeField] private GameObject buttonLayer1;
    [SerializeField] private GameObject attackButtons;
    [SerializeField] private GameObject spellButtons;
    public PlayerCombatantBehaviour playerCombatant;
    public EnemyCombatantBehaviour[] enemyCombatants;
    public Queue<CombatantBehaviour> combatantQueue = new Queue<CombatantBehaviour>();

    private void Awake()
    {
        playerCombatant = FindAnyObjectByType<PlayerCombatantBehaviour>();
        enemyCombatants = FindObjectsByType<EnemyCombatantBehaviour>(FindObjectsSortMode.None);
        combatantQueue.Enqueue(playerCombatant);
        foreach (EnemyCombatantBehaviour enemyCombatant in enemyCombatants)
        {
            combatantQueue.Enqueue(enemyCombatant);
        }
        rootState = new RootCombatState(this);
        rootState.Enter();
        instance = this;
        buttonLayer1.SetActive(true);
        attackButtons.SetActive(false);
        spellButtons.SetActive(false);
    }

    /*public void ExcecuteMove(MoveObject moveObject, CombatantBehaviour target)
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
        
    }*/

    /*public void SelectMove(MoveObject moveObject, CombatantBehaviour sender)
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
    }*/

    public void SelectMove()
    {
        rootState.SelectMove();
    }

    public void SelectTarget(MoveObject move)
    {
        rootState.SelectTarget(move);
    }

    public void ExecuteTurn(MoveObject move, CombatantBehaviour target)
    {
        List<CombatantBehaviour> targets = new List<CombatantBehaviour>();
        targets.Add(target);
        rootState.ExecuteTurn(move, targets);
    }

    public void ExecuteTurn(MoveObject move, List<CombatantBehaviour> targets)
    {
        rootState.ExecuteTurn(move, targets);
    }

    public void EndTurn()
    {
        CombatantBehaviour currentCombatant = combatantQueue.Dequeue();
        if (currentCombatant.IsAlive)
        {
            combatantQueue.Enqueue(currentCombatant);
        }

        while (!combatantQueue.Peek().IsAlive)
        {
            combatantQueue.Dequeue();
        }
        Play();
    }

    public void Play()
    {
        rootState.Play();
    }

    public void UpdateUI()
    {
        
    }
}
