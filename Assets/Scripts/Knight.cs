using UnityEngine;

public class Knight : MonoBehaviour
{
    public AudioSource footstepSFX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Footstep()
    {
        // Play footstep sound effect
        footstepSFX.Play();

        Debug.Log("Knight footstep sound played.");
    }
}
