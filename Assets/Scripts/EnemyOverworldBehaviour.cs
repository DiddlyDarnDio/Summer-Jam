using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyOverworldBehaviour : MonoBehaviour
{
    public List<EnemyCombatantBehaviour> enemies;
    public EnemySpawnerContainerObject enemiesContainer;

    public void TransitionToCombat()
    {
        enemiesContainer.enemies.Clear();
        enemiesContainer.enemies.AddRange(enemies);
        FindAnyObjectByType<PlayerMovement>().SavePlayerLocation();
        SceneManager.LoadScene("Combat_Test");
    }
}
