using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AttackButtonBehaviour : MonoBehaviour
{
    [SerializeField] private MoveObject moveObject;
    [SerializeField] private TextMeshProUGUI text;

    private void Awake()
    {
        if (moveObject == null)
        {
            Debug.LogWarning("No attackObject assigned", this);
            return;
        }

        text.text = moveObject.title;
    }

    public void OnButtonClick()
    {
        CombatBehaviour.instance.SelectTarget(moveObject);
    }
}
