using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class CombatStats
{
    public event UnityAction<int> onHPChanged;
    public event UnityAction<int> onMPChanged;
    public int maxHP = 100;
    [SerializeField] private int hp;
    public int maxMP = 20;
    [SerializeField] private int mp;
    [SerializeField] private int atk = 10;
    [SerializeField] private int def = 5;

    public int HP
    {
        get { return hp; }
        set
        {
            if (hp != value)
            {
                hp = value;
                if (hp < 0)
                {
                    hp = 0;
                }
                else if (hp > maxHP)
                {
                    hp = maxHP;
                }
                onHPChanged?.Invoke(hp);
            }
        }
    }
    
    public int MP
    {
        get { return mp; }
        set
        {
            if (mp != value)
            {
                mp = value;
                if (mp < 0)
                {
                    mp = 0;
                }
                else if (mp > maxHP)
                {
                    mp = maxHP;
                }
                onMPChanged?.Invoke(mp);
            }
        }
    }
}
