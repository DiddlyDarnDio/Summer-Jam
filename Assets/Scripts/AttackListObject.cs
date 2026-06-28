using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackListObject", menuName = "Scriptable Objects/AttackListObject")]
public class AttackListObject : ScriptableObject
{
    public List<MoveObject> AttackObjects;
}
