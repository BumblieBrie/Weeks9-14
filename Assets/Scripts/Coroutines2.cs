using System.Collections;
using UnityEngine;

public class Coroutines2 : MonoBehaviour
{
    public Transform treeTransform;
    public Transform appleTransform;

    Coroutine doTheGrowingCoroutine; // Be specific when storing a reference to a coroutine
    Coroutine growTreeCoroutine;
    Coroutine growAppleCoroutine;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        treeTransform.localScale = Vector2.zero;
        appleTransform.localScale = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartTreeGrowing()
    {
        if (doTheGrowingCoroutine != null) // There is no variable in the coroutine the first time it runs, so check if it's not null
        {
            StopCoroutine(doTheGrowingCoroutine); 
            // Stop the coroutine if it's still running to prevent it from running at the same time
            // If it is on a prefab, you HAVE to stop the coroutine if you are destroying the prefab
            // otherwise the coroutine will continue to run and cause errors because the object it is trying to access has been destroyed
        }
        if (growAppleCoroutine != null)
        {
            StopCoroutine(growAppleCoroutine);
        }
        if (growTreeCoroutine != null)
        {
            StopCoroutine(growTreeCoroutine);
        }

        doTheGrowingCoroutine = StartCoroutine(DoTheGrowing()); 
        // Start the coroutine that handles both the tree and apple growth, use this when needed to have a yield return to
        // ensure one coroutine starts before the next, otherwise they will both begin at the same time
    }

    IEnumerator DoTheGrowing()
    {
        yield return growTreeCoroutine = StartCoroutine(GrowTree()); // Wait for the tree to finish growing before starting the apple
        yield return growAppleCoroutine = StartCoroutine(GrowApple()); // Wait for the apple to finish growing before doing anything else (if needed)
    }

    IEnumerator GrowTree()
    {
        Debug.Log("Starting to grow the tree...");
        float t = 0f;
        treeTransform.localScale = Vector2.zero;
        appleTransform.localScale = Vector2.zero;

        while (t < 1f)
        {
            t += Time.deltaTime;
            treeTransform.localScale = Vector2.one * t;
            yield return null;
        }
        Debug.Log("Tree has fully grown!");
    }
    IEnumerator GrowApple()
    {
        Debug.Log("Starting to grow the apple...");
        float t = 0f;
        appleTransform.localScale = Vector2.zero;

        while (t < 1f)
        {
            t += Time.deltaTime;
            appleTransform.localScale = Vector2.one * t;
            yield return null;
        }
        Debug.Log("Apple has fully grown!");
    }
}
