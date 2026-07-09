using UnityEngine;

[CreateAssetMenu(fileName = "AttackObject", menuName = "Scriptable Objects/AttackObject")]
public class AttackObject : MoveObject
{
    public int damage;
    [Range(0, 100)] public int accuracy = 100;
}
