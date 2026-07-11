using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class CombatState
{
    public CombatBehaviour combatBehaviour;

    public CombatState(CombatBehaviour combatBehaviour)
    {
        this.combatBehaviour = combatBehaviour;
    }

    public virtual void Update()
    {
        
    }

    public virtual void Awake()
    {
        
    }

    public virtual void Enter()
    {
        
    }

    public virtual void Exit()
    {
        
    }

    public virtual void SelectMove()
    {
        
    }

    public virtual void SelectTarget(MoveObject move)
    {
        
    }

    public virtual void ExecuteTurn(MoveObject move, List<CombatantBehaviour> targets)
    {
        
    }

    public virtual void TurnPhaseDone()
    {
        
    }

    public virtual void Play()
    {
        
    }

    public virtual void EndTurn()
    {
        
    }
}

public sealed class SetupCombatState : CombatState
{
    public SetupCombatState(CombatBehaviour combatBehaviour) : base(combatBehaviour)
    {
        this.combatBehaviour = combatBehaviour;
    }

    public override void Enter()
    {
        foreach (EnemyCombatantBehaviour enemyCombatant in combatBehaviour.enemyCombatants)
        {
            enemyCombatant.Initialize();
        }
        combatBehaviour.playerCombatant.Initialize();
        //todo add time for intro animations?
        combatBehaviour.Play();
    }
}

public sealed class HumanMoveCombatState : CombatState
{
    public HumanMoveCombatState(CombatBehaviour combatBehaviour) : base(combatBehaviour)
    {
        
    }

    public override void Enter()
    {
        combatBehaviour.playerCombatant.SelectButtons.SetActive(true);
    }

    public override void Exit()
    {
        combatBehaviour.playerCombatant.SelectButtons.SetActive(false);//todo reset more properly
    }
}

public sealed class RandomMoveCombatState : CombatState
{
    public RandomMoveCombatState(CombatBehaviour combatBehaviour) : base(combatBehaviour)
    {
        
    }
    public override void Enter()
    {
        EnemyCombatantBehaviour currentCombatant = (EnemyCombatantBehaviour)combatBehaviour.combatantQueue.Peek();
        
        MoveObject move = currentCombatant.attacks[Random.Range(0, currentCombatant.attacks.Count)];
        if (move.target == MoveObject.MoveTarget.Self)
        {
            combatBehaviour.ExecuteTurn(move, currentCombatant);
        }
        else if (move.target == MoveObject.MoveTarget.Ally)
        {
            combatBehaviour.ExecuteTurn(move, combatBehaviour.enemyCombatants[Random.Range(0, combatBehaviour.enemyCombatants.Count)]);
        }
        else if (move.target == MoveObject.MoveTarget.Party)
        {
            List<CombatantBehaviour> targets = new List<CombatantBehaviour>();
            foreach (EnemyCombatantBehaviour enemyCombatantBehaviour in combatBehaviour.enemyCombatants)
            {
                targets.Add(enemyCombatantBehaviour);
            }
            combatBehaviour.ExecuteTurn(move, targets);
        }
        else if (move.target == MoveObject.MoveTarget.Enemy)
        {
            combatBehaviour.ExecuteTurn(move, combatBehaviour.playerCombatant);
        }
        else if (move.target == MoveObject.MoveTarget.All)
        {
            List<CombatantBehaviour> targets = new List<CombatantBehaviour>();
            targets.Add(combatBehaviour.playerCombatant);
            foreach (EnemyCombatantBehaviour enemyCombatantBehaviour in combatBehaviour.enemyCombatants)
            {
                targets.Add(enemyCombatantBehaviour);
            }
            combatBehaviour.ExecuteTurn(move, targets);
        }
        else
        {
            Debug.LogWarning($"No target exists for type: {move.target}");
        }
    }
}

public sealed class SelectMoveCombatState : CombatState
{
    public HumanMoveCombatState humanMoveCombatState;
    public RandomMoveCombatState randomMoveCombatState;
    private CombatState currentState;
    
    public SelectMoveCombatState(CombatBehaviour combatBehaviour) : base(combatBehaviour)
    {
        humanMoveCombatState = new HumanMoveCombatState(combatBehaviour);
        randomMoveCombatState = new RandomMoveCombatState(combatBehaviour);
    }
    
    public void Transit(CombatState toState)
    {
        currentState.Exit();
        currentState = toState;
        currentState.Enter();
    }

    public override void Awake()
    {
        humanMoveCombatState.Awake();
        randomMoveCombatState.Awake();
    }

    public override void Enter()
    {
        if (combatBehaviour.combatantQueue.Peek() is PlayerCombatantBehaviour)
        {
            currentState = humanMoveCombatState;
        }
        else
        {
            currentState = randomMoveCombatState;
        }
        currentState.Enter();
    }

    public override void Exit()
    {
        combatBehaviour.playerCombatant.SelectButtons.SetActive(false);
    }
}

public sealed class SelectTargetCombatState : CombatState
{
    public MoveObject move;
    public SelectTargetCombatState(CombatBehaviour combatBehaviour) : base(combatBehaviour)
    {
        
    }

    public override void Enter()
    {
        combatBehaviour.playerCombatant.BackButtons.SetActive(true);
        if (move.target == MoveObject.MoveTarget.Enemy)
        {
            if (combatBehaviour.enemyCombatants.Count == 1)
            {
                combatBehaviour.ExecuteTurn(move, combatBehaviour.enemyCombatants[0]);
            }
            foreach (EnemyCombatantBehaviour enemyCombatantBehaviour in combatBehaviour.enemyCombatants)
            {
                combatBehaviour.tempMove = move;
                enemyCombatantBehaviour.targetButton.SetActive(true);
            }
        }
        else if (move.target == MoveObject.MoveTarget.Self)
        {
            combatBehaviour.ExecuteTurn(move, combatBehaviour.playerCombatant);
        }
        else if (move.target == MoveObject.MoveTarget.Enemies)
        {
            List<CombatantBehaviour> targets = new List<CombatantBehaviour>();
            foreach (EnemyCombatantBehaviour enemyCombatant in combatBehaviour.enemyCombatants)
            {
                targets.Add(enemyCombatant);
            }
            combatBehaviour.ExecuteTurn(move, targets);
        }
        else if (move.target == MoveObject.MoveTarget.All)
        {
            List<CombatantBehaviour> targets = new List<CombatantBehaviour>();
            targets.Add(combatBehaviour.playerCombatant);
            foreach (EnemyCombatantBehaviour enemyCombatant in combatBehaviour.enemyCombatants)
            {
                targets.Add(enemyCombatant);
            }
            combatBehaviour.ExecuteTurn(move, targets);
        }
        else
        {
            Debug.LogWarning($"No target exists for type: {move.target}");
        }
    }

    public override void Exit()
    {
        combatBehaviour.tempMove = null;
        combatBehaviour.playerCombatant.BackButtons.SetActive(true);
        foreach (EnemyCombatantBehaviour enemyCombatantBehaviour in combatBehaviour.enemyCombatants)
        {
            enemyCombatantBehaviour.targetButton.SetActive(false);
        }
    }
}

public sealed class ExecuteTurnCombatState : CombatState
{
    public MoveObject move;
    public List<CombatantBehaviour> targets;

    public ExecuteTurnCombatState(CombatBehaviour combatBehaviour) : base(combatBehaviour)
    {
        
    }

    public override void Enter()
    {
        if (move is AttackObject attack)
        {
            foreach (CombatantBehaviour combatantBehaviour in targets)
            {
                combatantBehaviour.TakeDamage(attack.damage);
            }
        }
        combatBehaviour.EndTurn();
    }
}

public sealed class EndTurnCombatState : CombatState
{
    public EndTurnCombatState(CombatBehaviour combatBehaviour) : base(combatBehaviour)
    {
        
    }

    public override void Enter()
    {
        if (!combatBehaviour.playerCombatant.IsAlive)
        {
            Debug.LogWarning("Make something happen when player is dead");
            //todo plaayer is dead
        }

        if (!combatBehaviour.AnyEnemyAlive)
        {
            Debug.LogWarning("All enemies dead, do something");
            //todo all enemies dead
        }
        CombatantBehaviour currentCombatant = combatBehaviour.combatantQueue.Dequeue();
        combatBehaviour.combatantQueue.Enqueue(currentCombatant);
        
        while (!combatBehaviour.combatantQueue.Peek().IsAlive)
        {
            currentCombatant = combatBehaviour.combatantQueue.Dequeue();
            combatBehaviour.combatantQueue.Enqueue(currentCombatant);
        }
        
        combatBehaviour.Play();
    }
}

public sealed class PlayCombatState : CombatState
{
    public SelectMoveCombatState selectMoveCombatState;
    public SelectTargetCombatState selectTargetCombatState;
    public ExecuteTurnCombatState executeTurnCombatState;
    public EndTurnCombatState endTurnCombatState;

    private CombatState currentState;

    public PlayCombatState(CombatBehaviour combatBehaviour) : base(combatBehaviour)
    {
        selectMoveCombatState = new SelectMoveCombatState(combatBehaviour);
        selectTargetCombatState = new SelectTargetCombatState(combatBehaviour);
        executeTurnCombatState = new ExecuteTurnCombatState(combatBehaviour);
        endTurnCombatState = new EndTurnCombatState(combatBehaviour);
    }
    
    public void Transit(CombatState toState)
    {
        currentState.Exit();
        currentState = toState;
        currentState.Enter();
    }

    public override void Enter()
    {
        currentState = selectMoveCombatState;
        currentState.Enter();
    }

    public override void Update()
    {
        currentState.Update();
    }

    public override void SelectMove()
    {
        Transit(selectMoveCombatState);
    }

    public override void SelectTarget(MoveObject move)
    {
        selectTargetCombatState.move = move;
        Transit(selectTargetCombatState);
    }

    public override void ExecuteTurn(MoveObject move, List<CombatantBehaviour> targets)
    {
        executeTurnCombatState.move = move;
        executeTurnCombatState.targets = targets;
        Transit(executeTurnCombatState);
    }

    public override void EndTurn()
    {
        Transit(endTurnCombatState);
    }
}

public sealed class GameCombatState : CombatState
{
    public SetupCombatState setupCombatState;
    public PlayCombatState playCombatState;
    private CombatState currentState;

    public GameCombatState(CombatBehaviour combatBehaviour) : base(combatBehaviour)
    {
        setupCombatState = new SetupCombatState(combatBehaviour);
        playCombatState = new PlayCombatState(combatBehaviour);
    }

    public void Transit(CombatState toState)
    {
        currentState.Exit();
        currentState = toState;
        currentState.Enter();
    }

    public override void Enter()
    {
        currentState = setupCombatState;
        currentState.Enter();
    }

    public override void Update()
    {
        currentState.Update();
    }

    public override void SelectMove()
    {
        currentState.SelectMove();
    }

    public override void SelectTarget(MoveObject move)
    {
        currentState.SelectTarget(move);
    }

    public override void ExecuteTurn(MoveObject moveObject, List<CombatantBehaviour> targets)
    {
        currentState.ExecuteTurn(moveObject, targets);
    }

    public override void EndTurn()
    {
        currentState.EndTurn();
    }

    public override void Play()
    {
        Transit(playCombatState);
    }
}

public sealed class RootCombatState : CombatState
{
    public GameCombatState gameCombatState;

    public RootCombatState(CombatBehaviour combatBehaviour) : base(combatBehaviour)
    {
        gameCombatState = new GameCombatState(combatBehaviour);
    }

    public override void Update()
    {
        gameCombatState.Update();
    }

    public override void Enter()
    {
        gameCombatState.Enter();
    }

    public override void Awake()
    {
        gameCombatState.Awake();
    }

    public override void SelectMove()
    {
        gameCombatState.SelectMove();
    }

    public override void SelectTarget(MoveObject move)
    {
        gameCombatState.SelectTarget(move);
    }

    public override void ExecuteTurn(MoveObject move, List<CombatantBehaviour> targets)
    {
        gameCombatState.ExecuteTurn(move, targets);
    }

    public override void TurnPhaseDone()
    {
        gameCombatState.TurnPhaseDone();
    }

    public override void Play()
    {
        gameCombatState.Play();
    }

    public override void EndTurn()
    {
        gameCombatState.EndTurn();
    }
}
