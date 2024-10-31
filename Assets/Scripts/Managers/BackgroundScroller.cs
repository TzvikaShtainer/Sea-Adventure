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
        backgroundWidth = backgroundsArray[0].GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void Update()
    {
        foreach (GameObject background in backgroundsArray)
        {
            background.transform.position += Vector3.left * (speed * Time.deltaTime);
        }
        
        foreach (GameObject background in backgroundsArray)
        {
            if (background.transform.position.x <= -backgroundWidth)
            {
                GameObject rightmostBackground = GetRightmostBackground();
                
                Vector3 newPosition = new Vector3(rightmostBackground.transform.position.x + backgroundWidth, 
                    background.transform.position.y, 
                    background.transform.position.z);
                background.transform.position = newPosition;
            }
        }
    }
    
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

    public void SetBackgroundScrollerArray(Sprite newBackgroundImage)
    {
        for (int i = 0; i < backgroundsArray.Length; i++)
        {
            backgroundsArray[i].GetComponent<SpriteRenderer>().sprite = newBackgroundImage;
        }
    }
}
