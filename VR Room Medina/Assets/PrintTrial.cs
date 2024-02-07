using UnityEngine;

public class PrintTrial : MonoBehaviour
{
    public Transform paintbrush;
    public GameObject trailPrefab;
    public Transform spawnPoint;

    private GameObject drawnTrail; // Store the drawn trail GameObject

    void Update()
    {
        // Update the position of this GameObject based on the paintbrush position
        if (paintbrush != null)
        {
            transform.position = paintbrush.position - Vector3.forward * 0.5f + Vector3.right * 1.5f;
        }
    }

    public void SpawnTrail()
    {
        if (drawnTrail != null)
        {
            // Duplicate the drawn trail GameObject at the spawn point
            GameObject newTrail = Instantiate(drawnTrail, spawnPoint.position, drawnTrail.transform.rotation);

            // Optionally, you can apply any modifications to the new trail GameObject here

            Debug.Log("Trail cloned at the spawn point.");
        }
        else
        {
            Debug.LogWarning("No drawn trail found to duplicate!");
        }
    }

    public void SetDrawnTrail(GameObject trail)
    {
        drawnTrail = trail;
    }
}
