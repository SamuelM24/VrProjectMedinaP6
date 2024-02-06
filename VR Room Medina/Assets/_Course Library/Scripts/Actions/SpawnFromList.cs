using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnFromList : MonoBehaviour
{
    [Tooltip("List of prefab objects that can be spawned")]
    public List<GameObject> originalObjects = null;

    [Tooltip("Transform for how the object will be spawned")]
    public Transform spawnPoint = null;

    [Tooltip("Transform for the small pedestal")]
    public Transform smallPedestal = null;

    [Tooltip("Will the spawned object be childed to the point?")]
    public bool attachToSpawnPoint = false;

    public ObjectRotation objectRotation;  // Reference to the ObjectRotation script

    private GameObject currentObject = null;
    private int index = 0;

    private void Start()
    {
        // Ensure smallPedestal is initialized before using it
        if (smallPedestal == null)
        {
            smallPedestal = GameObject.FindWithTag("SmallPedestal")?.transform;
            if (smallPedestal == null)
            {
                UnityEngine.Debug.LogError("Small pedestal not found or assigned.");
                return;
            }
        }

        // Spawn the initial object when the game starts
        Spawn();
    }

    public void SpawnAtDropdownIndex(Dropdown dropdown)
    {
        index = Mathf.Clamp(dropdown.value, 0, originalObjects.Count);
        Spawn();
    }

    public void SpawnAndReplaceAtDropdownIndex(int value)
    {
        index = Mathf.Clamp(value, 0, originalObjects.Count);
        SpawnAndReplace();
    }

    public void PrintAtDropdownIndex(Dropdown dropdown)
    {
        index = Mathf.Clamp(dropdown.value, 0, originalObjects.Count);
        PrintCreation();
    }

    public void Spawn()
    {
        // Only spawn if there's a valid prefab at the specified index
        if (originalObjects.Count > 0 && index < originalObjects.Count && originalObjects[index] != null)
        {
            CreateObject();
        }
        else
        {
            UnityEngine.Debug.LogError("Invalid prefab index or prefab is null.");
        }
    }

    public void SpawnAndReplace()
    {
        GameObject newObject = CreateObject();
        ReplaceObject(newObject);
    }

    public void PrintCreation()
    {
        GameObject newObject = CreateObject();
        PrintObject(newObject);
    }

    private GameObject CreateObject()
    {
        // Ensure index is within bounds
        if (index >= 0 && index < originalObjects.Count)
        {
            GameObject prefabToSpawn = originalObjects[index];

            // Ensure the prefabToSpawn is not null before instantiating
            if (prefabToSpawn != null)
            {
                UnityEngine.Debug.Log("Instantiating: " + prefabToSpawn.name);

                GameObject newObject = Instantiate(prefabToSpawn, spawnPoint.position, spawnPoint.rotation);

                if (attachToSpawnPoint)
                {
                    newObject.transform.SetParent(spawnPoint);
                }

                // Set the prefab instance in the ObjectRotation script
                if (objectRotation != null)
                {
                    objectRotation.SetPrefabInstance(newObject);
                }

                return newObject;
            }
            else
            {
                UnityEngine.Debug.LogError("Prefab to spawn is null.");
            }
        }
        else
        {
            UnityEngine.Debug.LogError("Invalid prefab index.");
        }

        return null;
    }

    private void ReplaceObject(GameObject newObject)
    {
        if (currentObject) Destroy(currentObject);
        currentObject = newObject;
    }

    private void PrintObject(GameObject objectToPrint)
    {
        UnityEngine.Debug.Log("objectToPrint: " + objectToPrint);
        UnityEngine.Debug.Log("smallPedestal: " + smallPedestal);

        if (objectToPrint != null && smallPedestal != null)
        {
            // Get the position of the original pedestal
            Vector3 originalPedestalPosition = spawnPoint.position;

            // Get the position of the small pedestal
            Vector3 smallPedestalPosition = smallPedestal.position + new Vector3(0, 0.5f, 0);

            // Calculate the position for the clone above the small pedestal
            Vector3 spawnPosition = new Vector3(smallPedestalPosition.x, smallPedestalPosition.y + 0.5f, smallPedestalPosition.z);

            // Create a clone of the original object above the small pedestal
            GameObject cloneObject = Instantiate(objectToPrint, spawnPosition, Quaternion.identity);

            // Optionally, you can set the cloneObject as a child of the small pedestal
            cloneObject.transform.parent = smallPedestal;

            UnityEngine.Debug.Log("Miniature version created above the small pedestal!");
        }
        else
        {
            UnityEngine.Debug.LogError("Invalid object or small pedestal reference. Make sure you have valid objects.");
        }
    }
}
