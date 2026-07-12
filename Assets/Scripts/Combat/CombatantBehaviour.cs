using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CombatantBehaviour : MonoBehaviour
{
    public static int MIN_DAMAGE = 1;
    private bool isDefending = false;
    public event UnityAction<bool> OnDefendChange; 

    public bool IsDefending
    {
        get { return isDefending; }
        set
        {
            if (isDefending != value)
            {
                isDefending = value;
                OnDefendChange?.Invoke(isDefending);
            }
        }
    }
    public virtual CombatStats CombatStats
    {
        get { return null; }
    }

    public bool IsAlive
    {
        get
        {
            return CombatStats.HP > 0;
        }
    }
    
    public virtual void TakeDamage(int damage)
    {
        if (IsDefending)
        {
            damage /= 2;
        }
        CombatStats.HP -= Mathf.Max(MIN_DAMAGE, damage - CombatStats.def);
    }

    public virtual void Initialize()
    {
        
    }
}
