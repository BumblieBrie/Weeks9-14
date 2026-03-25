using UnityEngine;
using UnityEngine.InputSystem;

public class Knight : MonoBehaviour
{

    // Done in AnimationEvent scene to play footstep sound effects at the right time during the walking animation
    public int randomNumber;
    public Vector2 movement;

    public AudioSource footstep1SFX;
    public AudioSource footstep2SFX;
    public AudioSource footstep3SFX;
    public AudioSource footstep4SFX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = movement;
    }

    public void Footstep()
    {
        randomNumber = Random.Range(1, 5); // Generate a random number between 1 and 4
        // Play footstep sound effect

        if (randomNumber == 1)
        {
            footstep1SFX.Play();
        }
        else if (randomNumber == 2)
        {
            footstep2SFX.Play();
        }
        else if (randomNumber == 3)
        {
            footstep3SFX.Play();
        }
        else if (randomNumber == 4)
        {
            footstep4SFX.Play();
        }

        Debug.Log("Knight footstep sound played.");
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }
}
