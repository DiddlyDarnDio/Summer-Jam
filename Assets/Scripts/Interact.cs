using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interact : MonoBehaviour
{
    [SerializeField] private GameObject visual;
    private Interactable currentInteractable;

    private void Awake()
    {
        visual.SetActive(false);
        currentInteractable = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Interactable interactable))
        {
            currentInteractable = interactable;
            visual.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Interactable interactable))
        {
            if (currentInteractable == interactable)
            {
                visual.SetActive(false);
                currentInteractable = null;
            }
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (currentInteractable != null)
            {
                currentInteractable.Interact();
            }
        }
    }
}
