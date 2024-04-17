using System.Collections;
using TMPro;
using UnityEngine;

public class CaptionController : MonoBehaviour
{
    public TextMeshProUGUI captionText;
    public string[] captions;
    public float initialDelay = 0f; // Delay before the first caption
    public float lineDelay = 3f; // Delay between lines

    private Coroutine displayCoroutine;

    void Start()
    {
        // Hide the caption text initially
        captionText.text = "";

        // Start displaying captions after the initial delay
        StartCoroutine(StartWithDelay());
    }

    IEnumerator StartWithDelay()
    {
        // Delay before the first caption
        yield return new WaitForSeconds(initialDelay);

        // Start displaying captions
        StartCaptions();
    }

    public void StartCaptions()
    {
        // Start displaying captions immediately
        DisplayNextLine(0);
    }

    public void StopCaptions()
    {
        // Stop displaying captions
        if (displayCoroutine != null)
            StopCoroutine(displayCoroutine);

        // Hide the caption text
        captionText.text = "";
    }

    void DisplayNextLine(int index)
    {
        // Display current line
        captionText.text = captions[index];

        // Schedule the next line to be displayed after lineDelay seconds
        if (index < captions.Length - 1)
        {
            displayCoroutine = StartCoroutine(DelayNextLine(index + 1));
        }
    }

    IEnumerator DelayNextLine(int index)
    {
        // Wait for lineDelay seconds before displaying the next line
        yield return new WaitForSeconds(lineDelay);

        // Display the next line
        DisplayNextLine(index);
    }
}
