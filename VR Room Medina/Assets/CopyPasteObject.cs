using UnityEngine;

public class CopyPasteObject : MonoBehaviour
{
    public void CopyAndPaste(GameObject originalObject, Vector3 position)
    {
        // Instantiate a copy of the original object
        GameObject copyObject = Instantiate(originalObject, position, Quaternion.identity);

        // Optionally, you can adjust the scale of the copied object
        // Example: copyObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

        // Set the copy object above the new pedestal
        copyObject.transform.position = position;

        // Optionally, you can adjust the scale of the copy object
        // Example: copyObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

        // Assuming your drawings are child objects, copy the drawings as well
        foreach (Transform child in originalObject.transform)
        {
            Instantiate(child.gameObject, copyObject.transform);
        }
    }
}
