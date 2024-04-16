using UnityEngine;
using UnityEngine.Video;
using TMPro;

public class ClosedCaptionController : MonoBehaviour
{
    public TMP_Text closedCaptionText; // TextMeshPro component for displaying closed captions
    public VideoPlayer videoPlayer; // VideoPlayer component for playing the video
    public string[] captions = new string[]
    {
        "0.0:With the 26th pick in the 2020 NFL Draft",
        "1.5:The Green Bay Packers select Jordan Love",
        "3.0:Jordan Love, Quarterback",
        "5.0:Here we stand",
        "8.0:Worlds apart, hearts broken in two, two, two",
        "12.0:Sleepless nights",
        "15.0:Losing ground, I'm reaching for you, you, you",
        "18.0:No!",
        "19.5:No!",
        "21.0:Someday love will find you",
        "23.0:True love won't desert you",
        "25.0:You know I still love you",
        "28.0:Though we touched and went our separate ways",
        "30.0:No!"
    }; // Array of closed captions corresponding to video segments

    private void Start()
    {
        // Find the TextMeshPro component in children
        closedCaptionText = GetComponentInChildren<TMP_Text>();

        // Ensure the TextMeshPro component is found
        if (closedCaptionText == null)
        {
            Debug.LogError("TextMeshPro component not found!");
            return;
        }

        // Initialize closed caption text
        closedCaptionText.text = "";

        // Subscribe to video player events
        videoPlayer.loopPointReached += OnVideoEnd;
        videoPlayer.prepareCompleted += OnVideoPrepared;
    }

    private void OnVideoPrepared(VideoPlayer source)
    {
        // Video prepared, start playing
        videoPlayer.Play();
    }

    private void OnVideoEnd(VideoPlayer source)
    {
        // Video playback ended, reset closed captions
        closedCaptionText.text = "";
    }

    private void Update()
    {
        // Update closed captions based on current video time
        foreach (var caption in captions)
        {
            // Split caption string into time and text
            string[] captionParts = caption.Split(':');
            float captionTime = float.Parse(captionParts[0]);
            string captionText = captionParts[1];

            // Check if the current video time matches the caption time
            if (videoPlayer.time >= captionTime)
            {
                // Display the caption text
                closedCaptionText.text = captionText;
            }
        }
    }
}
