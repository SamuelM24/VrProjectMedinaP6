using UnityEngine;

public class PrintButton : MonoBehaviour
{
    public GameObject table; // Reference to the table where the miniature version will be placed

    private GameObject currentCreation; // Reference to the currently selected 3D creation

    // Called when the "Print" button is clicked
    public void OnPrintButtonClick()
    {
        if (currentCreation != null && table != null)
        {
            // Duplicate the currently selected 3D creation
            GameObject miniatureCreation = Instantiate(currentCreation);

            // Resize the miniature (you may need to adjust the scale factor)
            miniatureCreation.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

            // Place the miniature on the table
            miniatureCreation.transform.position = table.transform.position;
        }
    }

    // Set the currently selected 3D creation
    public void SetCurrentCreation(GameObject newCreation)
    {
        currentCreation = newCreation;
    }
}
