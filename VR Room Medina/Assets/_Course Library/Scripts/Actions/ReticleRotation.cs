using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReticleRotation : MonoBehaviour
{
    private bool isScalingUp = true;

    [SerializeField] private float spinSpeed = 5f;
    [SerializeField] private float scaleSpeed = 0.3f;
    [SerializeField] private float maxScale = 1.5f;
    [SerializeField] private float minScale = 1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        // Rotate the reticle around the y-axis
        transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);

        // Scale the reticle up and down
        if (isScalingUp)
        {
            transform.localScale += Vector3.one * scaleSpeed * Time.deltaTime;
            if (transform.localScale.x >= maxScale)
            {
                isScalingUp = false;
            }
        }
        else
        {
            transform.localScale -= Vector3.one * scaleSpeed * Time.deltaTime;
            if (transform.localScale.x <= minScale)
            {
                isScalingUp = true;
            }
        }
    }
}
