using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemySpawnerContainerObject", menuName = "Scriptable Objects/EnemySpawnerContainerObject")]
public class EnemySpawnerContainerObject : ScriptableObject
{
    public List<EnemyCombatantBehaviour> enemies;
}
