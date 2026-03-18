using System.Collections;
using UnityEngine;

public class Grower : MonoBehaviour
{
    public Transform treeTransform;
    public Transform appleTransform;
    public float appleDelay = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        treeTransform.localScale = Vector2.zero;
        appleTransform.localScale = Vector2.zero;

        StartCoroutine(GrowTree());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartTreeGrowing()
    {
        StartCoroutine(GrowTree());
    }
    IEnumerator GrowTree()
    {
        float t = 0;
        treeTransform.localScale = Vector2.zero;
        appleTransform.localScale = Vector2.zero;

        while (t < 1)
        {
            t += Time.deltaTime;
            treeTransform.localScale = Vector2.one * t;
            yield return null; // come back next frame
        }

        yield return new WaitForSeconds(appleDelay); // come back after this amount of time has passed

        t = 0;

        while (t < 1)
        {
            t += Time.deltaTime;
            appleTransform.localScale = Vector2.one * t;
            yield return null;
        }
    }
}
