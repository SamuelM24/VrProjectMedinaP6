using UnityEngine;

public class TrailController : MonoBehaviour
{
    public GameObject trailPrefab; // Prefab of the trail object
    public Transform objectToFollow; // Object to which the trail should stick

    private GameObject trailInstance;

    void Start()
    {
        // Instantiate the trail prefab and parent it to the object to follow
        trailInstance = Instantiate(trailPrefab, objectToFollow);
    }

    void Update()
    {
        // Optionally update the position and rotation of the trail to match the object to follow
        trailInstance.transform.position = objectToFollow.position;
        trailInstance.transform.rotation = objectToFollow.rotation;
    }
}
