using UnityEngine;

public class BrushSound : MonoBehaviour
{
    public AudioSource continuousSoundPlayer;
    private bool paintbrushInUse = false;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize your AudioSource if not already done
        if (continuousSoundPlayer == null)
        {
            continuousSoundPlayer = GetComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Example: Check if paintbrush is in use and play continuous sound
        if (paintbrushInUse)
        {
            // Check if the sound is not already playing to avoid overlapping
            if (!continuousSoundPlayer.isPlaying)
            {
                continuousSoundPlayer.Play();
            }
        }
    }

    // Call this function when the paintbrush is activated
    public void OnPaintbrushActivation()
    {
        paintbrushInUse = true;

        // Your existing paintbrush activation logic
    }

    // Call this function when the paintbrush is deactivated
    public void OnPaintbrushDeactivation()
    {
        paintbrushInUse = false;

        // Your existing paintbrush deactivation logic
    }
}
