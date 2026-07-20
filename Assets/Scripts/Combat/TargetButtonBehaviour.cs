using UnityEngine;

public class TargetButtonBehaviour : MonoBehaviour
{
    public EnemyCombatantBehaviour target;

    public void OnButtonClick()
    {
        CombatBehaviour.instance.ExecuteTurn(target);
    }
}
