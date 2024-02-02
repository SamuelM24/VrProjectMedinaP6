using System.Diagnostics;
using UnityEngine;

public class PrintButton : MonoBehaviour
{
    public GameObject spawnedObject; // Reference to the spawned object

    // This function will be called when the "Print" button is clicked
    public void OnPrintButtonClick()
    {
        if (spawnedObject != null)
        {
            
            GameObject table = GameObject.FindWithTag("Table");

            if (table != null)
            {
                
                spawnedObject.transform.position = table.transform.position;



                UnityEngine.Debug.Log("3D creation printed!");
            }
        }
        else
        {
            UnityEngine.Debug.LogError("No object to print. Make sure an object is spawned on the pedestal.");
        }
    }
}
