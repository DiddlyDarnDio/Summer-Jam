using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "PlayerStatusObject", menuName = "Scriptable Objects/PlayerStatusObject")]
public class PlayerStatusObject : ScriptableObject
{
    public event UnityAction<int> onHealthChanged;
    public event UnityAction<int> onManaChanged;
    [SerializeField] private int health = 100;
    public int maxHealth = 100;
    [SerializeField] private int mana = 100;
    public int maxMana = 100;

    public void ResetStatus()
    {
        Health = maxHealth;
        Mana = maxMana;
    }

    public int Health
    {
        get { return health; }
        set
        {
            if (value != health)
            {
                health = value;
                if (health < 0)
                {
                    health = 0;
                }
                else if (health > maxHealth)
                {
                    health = maxHealth;
                }
                onHealthChanged?.Invoke(health);
            }
        }
    }

    public int Mana
    {
        get { return mana; }
        set
        {
            if (value != mana)
            {
                mana = value;
                if (mana < 0)
                {
                    mana = 0;
                }
                else if (mana > maxMana)
                {
                    mana = maxMana;
                }
                onManaChanged?.Invoke(mana);
            }
        }
    }
}
