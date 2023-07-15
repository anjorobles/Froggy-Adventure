using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float scrollSpeed = 1f; // Speed of the scrolling animation
    public float loopDistance = 10f; // Distance before the background starts to loop

    private float startPosition;
    private Transform backgroundTransform;

    private void Start()
    {
        backgroundTransform = transform;
        startPosition = backgroundTransform.position.y;
    }

    private void Update()
    {
        // Calculate the distance to move based on the scroll speed and delta time
        float distanceToMove = scrollSpeed * Time.deltaTime;

        // Update the position of the background
        backgroundTransform.Translate(Vector3.down * distanceToMove, Space.World);

        // Check if the background has reached the loop distance
        if (backgroundTransform.position.y - startPosition <= -loopDistance)
        {
            // Move the background back to the start position
            float excessDistance = Mathf.Abs(backgroundTransform.position.y - startPosition + loopDistance);
            backgroundTransform.Translate(Vector3.up * excessDistance, Space.World);
        }
    }
}
