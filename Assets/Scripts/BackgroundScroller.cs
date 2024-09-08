using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField]
    public float speed = 5f;
    [SerializeField] private GameObject[] backgroundsArray;
    
    private float backgroundWidth;

    private void Start()
    {
        // Assuming all backgrounds have the same width
        backgroundWidth = backgroundsArray[0].GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void Update()
    {
        // Move each background to the left
        foreach (GameObject background in backgroundsArray)
        {
            background.transform.position += Vector3.left * (speed * Time.deltaTime);
        }

        // Check if any background has moved completely off-screen
        foreach (GameObject background in backgroundsArray)
        {
            if (background.transform.position.x <= -backgroundWidth)
            {
                // Find the rightmost background
                GameObject rightmostBackground = GetRightmostBackground();
                
                // Reposition the off-screen background to the right of the rightmost one
                Vector3 newPosition = new Vector3(rightmostBackground.transform.position.x + backgroundWidth, 
                    background.transform.position.y, 
                    background.transform.position.z);
                background.transform.position = newPosition;
            }
        }
    }

    // Helper function to find the rightmost background
    private GameObject GetRightmostBackground()
    {
        GameObject rightmost = backgroundsArray[0];
        foreach (GameObject background in backgroundsArray)
        {
            if (background.transform.position.x > rightmost.transform.position.x)
            {
                rightmost = background;
            }
        }
        return rightmost;
    }
}
