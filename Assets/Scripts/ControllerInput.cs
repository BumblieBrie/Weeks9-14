using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerInput : MonoBehaviour
{
    public float speed = 5f; // Speed of movement
    public Vector2 movement; // Store the movement input
    public AudioSource SFX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //use with a joystick or WASD keys to move the player
        //transform.position += (Vector3)movement * speed * Time.deltaTime;

        //use with the mouse position
        transform.position = movement;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }
    public void OnAttack(InputAction.CallbackContext context)
    {
        Debug.Log("Attack! " + context.phase);
        if (context.performed == true)
        {
            SFX.Play();
        }
    }
    public void OnPoint(InputAction.CallbackContext context) // where in our scene is under the cursor right now?
    {
        //same as mouse.current.position.ReadValue() but using the input system's callback context instead
        movement = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
    }
}
