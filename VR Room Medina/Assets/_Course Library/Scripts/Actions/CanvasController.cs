using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public GameObject canvasToDeactivate;

    public void DeactivateCanvas()
    {
        canvasToDeactivate.SetActive(false);
    }
}
