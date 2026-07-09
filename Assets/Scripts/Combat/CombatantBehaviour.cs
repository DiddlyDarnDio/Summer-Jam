using UnityEngine;

public class CombatantBehaviour : MonoBehaviour
{
    public virtual CombatStats CombatStats
    {
        get { return null; }
    }
    
    public virtual void TakeDamage(int damage)
    {
        
    }
}
