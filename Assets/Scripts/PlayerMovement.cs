using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] [Min(0)] private float speed = 1;
    [SerializeField] [Min(0)] private float jumpForce = 1;
    [SerializeField] [Min(0)] private float gravity = 1;

    [SerializeField] private Transform rotator;
    [SerializeField] private CharacterController characterController;

    private Vector3 velocity;
    private Vector2 moveVector;

    private Vector3 MoveVector3
    {
        get
        {
            return new Vector3(moveVector.x, 0, moveVector.y);
        }
    }
    private bool doJump = false;

    private Vector3 gravityVector
    {
        get
        {
            return new Vector3(0, gravity);
        }
    }


    // Update is called once per frame
    void Update()
    {
        velocity = new Vector3(0, velocity.y, 0);
        velocity += MoveVector3 * speed;
        if (doJump)
        {
            doJump = false;
            if (characterController.isGrounded)
            {
                velocity.y = jumpForce;
            }
        }
        if (!characterController.isGrounded)
        {
            velocity -= gravityVector;
        }
        characterController.Move(velocity * Time.deltaTime);
        rotator.LookAt(rotator.position + MoveVector3);
    }

    #region Input Events

    public void OnMove(InputAction.CallbackContext context)
    {
        moveVector = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            doJump = true;
        }
        else
        {
            doJump = false;
        }
    }

    #endregion
    
}
