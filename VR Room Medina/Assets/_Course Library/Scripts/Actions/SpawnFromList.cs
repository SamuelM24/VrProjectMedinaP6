using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnFromList : MonoBehaviour
{
    [Tooltip("List of objects that are spawned")]
    public List<GameObject> originalObjects = null;

    [Tooltip("Transform for how the object will be spawned")]
    public Transform spawnPoint = null;

    [Tooltip("Will the spawned object be childed to the point?")]
    public bool attachToSpawnPoint = false;

    private GameObject currentObject = null;
    private int index = 0;

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
        CreateObject();
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
        GameObject prefabToSpawn = originalObjects[index];
        GameObject newObject = Instantiate(prefabToSpawn, spawnPoint.position, spawnPoint.rotation);
        if (attachToSpawnPoint) newObject.transform.SetParent(spawnPoint);
        return newObject;
    }

    private void ReplaceObject(GameObject newObject)
    {
        if (currentObject) Destroy(currentObject);
        currentObject = newObject;
    }

    private void PrintObject(GameObject objectToPrint)
    {
        // Assuming you have a reference to your table GameObject
        GameObject table = GameObject.FindWithTag("Table");

        if (table != null)
        {
            // Set the position of the printed object to be on the table
            objectToPrint.transform.position = table.transform.position;

            // Optionally, you can adjust the scale of the printed object
            // Example: objectToPrint.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        }
    }

    public void SpawnRandom()
    {
        index = Random.Range(0, originalObjects.Count);
        Spawn();
    }

    public void SpawnAtIndex(int value)
    {
        index = value;
        Spawn();
    }

    private void OnValidate()
    {
        if (!spawnPoint) spawnPoint = transform;
    }
}
