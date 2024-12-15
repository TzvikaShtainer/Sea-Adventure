using UnityEngine;
using UnityEngine.UI;

public class UpAndDownEffect : MonoBehaviour
{
    // Movement variables
    [SerializeField] private float moveDistance = 20f; // How far the button moves up and down
    [SerializeField] private float speed = 2f; // Speed of movement

    private Vector3 startPos;

    void Start()
    {
        // Store the starting position of the button
        startPos = transform.localPosition;
    }

    void Update()
    {
        // Calculate the new Y position using a sine wave for smooth back and forth movement
        float newY = startPos.y + Mathf.Sin(Time.time * speed) * moveDistance;
        
        // Set the button's position
        transform.localPosition = new Vector3(startPos.x, newY, startPos.z);
    }
}