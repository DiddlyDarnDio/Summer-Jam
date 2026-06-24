using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AttackButtonBehaviour : MonoBehaviour
{
    [SerializeField] private AttackObject _attackObject;
    [SerializeField] private TextMeshProUGUI text;

    private void Awake()
    {
        if (_attackObject == null)
        {
            Debug.LogWarning("No attackObject assigned", this);
            return;
        }

        text.text = _attackObject.title;
    }

    public void OnButtonClick()
    {
        CombatManager.instance.ExcecuteAttack(_attackObject);
    }
}
