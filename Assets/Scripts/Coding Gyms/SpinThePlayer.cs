using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpinThePlayer : MonoBehaviour
{
    public Transform playerOneTransform;
    public Transform playerTwoTransform;

    public bool spaceButtonInteractible = true;
    public bool leftClickInteractible = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerOneTransform.localEulerAngles = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            spaceButtonInteractible = false;
            StartCoroutine(SpinningPlayer());
        }
        if(Mouse.current.leftButton.wasPressedThisFrame)
        {
            leftClickInteractible = false;
            StartCoroutine(SpinningPlayer());
        }
    }
   
    IEnumerator SpinningPlayer()
    {
        float t = 0;
  
        if(spaceButtonInteractible == false)
        {
            while (t < 1)
            {
                t += Time.deltaTime;
                playerOneTransform.localEulerAngles = new Vector3(0, 0, 360 * t);
                yield return null;
            }
            spaceButtonInteractible = true;
        }
        if(leftClickInteractible == false)
        {
            while (t < 1)
            {
                t += Time.deltaTime;
                playerTwoTransform.localEulerAngles = new Vector3(0, 0, 360 * (-t));
                yield return null;
            }
            leftClickInteractible = true;
        }

    }
}
