using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLSandRS : MonoBehaviour
{
    public float speed = 5f; // Speed of the player movement
    public Vector2 movement; // Variable to store movement input
    public Vector2 rotation; // Variable to store rotation input

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)movement * speed * Time.deltaTime; // Move the player based on input and speed

        Vector3 newRot = transform.eulerAngles;
        newRot.z -= speed * rotation.y * Time.deltaTime; // Rotate the player around the Z-axis based on input and speed
        transform.eulerAngles = newRot; // Apply the new rotation to the player
    }
    public void OnMove(InputAction.CallbackContext context)
    {
       movement = context.ReadValue<Vector2>(); // Read the movement input from the context and store it in the movement variable
    }
    public void OnLook(InputAction.CallbackContext context)
    {
        rotation = context.ReadValue<Vector2>(); // Read the rotation input from the context and store it in the rotation variable
    }
}
