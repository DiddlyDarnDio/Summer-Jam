using System.Collections.Generic;
using UnityEngine;

public class CombatantBehaviour : MonoBehaviour
{
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
        
    }

    public virtual void Initialize()
    {
        
    }
}
