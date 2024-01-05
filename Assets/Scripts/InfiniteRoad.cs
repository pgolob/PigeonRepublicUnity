using UnityEngine;

public class InfiniteRoad : MonoBehaviour
{
    public GameObject roadSegmentPrefab;
    public float scrollSpeed = 15f;
    public float distanceBetweenSegments = 10f;

    private float lastSpawnXPosition = 0f;

    void Start()
    {
        // Initial instantiation of the road segments
        InstantiateRoadSegment();
    }

    void Update()
    {
        // Move the road segments forward
        transform.Translate(Vector3.right * scrollSpeed * Time.deltaTime);

        // Check if a new road segment needs to be instantiated
        if (transform.position.x > lastSpawnXPosition + distanceBetweenSegments)
        {
            // Update the spawn point to the new segment's end
            InstantiateRoadSegment();
        }
    }

    void InstantiateRoadSegment()
    {
        // Instantiate a new road segment
        GameObject newRoad = Instantiate(roadSegmentPrefab, new Vector3(lastSpawnXPosition, 0, 0), Quaternion.identity);

        // Set the parent of the new road segment to the InfiniteRoad object
        newRoad.transform.parent = transform;

        // Update the spawn position to the new segment's end
        lastSpawnXPosition += distanceBetweenSegments;
    }
}
