using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpinThePlayer : MonoBehaviour
{
    public Transform playerOneTransform;

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
            StartCoroutine(SpinningPlayer());
        }
    }
   
    IEnumerator SpinningPlayer()
    {
        float t = 0;
  
        while (t < 1)
        {
            t += Time.deltaTime;
            playerOneTransform.localEulerAngles = new Vector3(0, 0, 360 * t);
            yield return null;
        }
    }
}
