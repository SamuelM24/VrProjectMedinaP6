using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class AutoPlayMessages : MonoBehaviour
{
    [Tooltip("The text mesh the message is output to")]
    public TextMeshProUGUI messageOutput = null;

    [Tooltip("The duration to display each message")]
    public float messageDuration = 1.5f;

    // What happens once the list is completed
    public UnityEvent OnComplete = new UnityEvent();

    [Tooltip("The list of messages that are shown")]
    [TextArea] public List<string> messages = new List<string>();

    private int index = 0;
    private Coroutine messageCoroutine;

    private void OnEnable()
    {
        StartPlayingMessages();
    }

    private void StartPlayingMessages()
    {
        if (messageCoroutine != null)
            StopCoroutine(messageCoroutine);

        messageCoroutine = StartCoroutine(ShowMessagesRoutine());
    }

    private IEnumerator ShowMessagesRoutine()
    {
        while (index < messages.Count)
        {
            ShowMessage(messages[index]);
            yield return new WaitForSeconds(messageDuration);
            NextMessage();
        }

        OnComplete.Invoke();
    }

    private void ShowMessage(string message)
    {
        messageOutput.text = message;
    }

    private void NextMessage()
    {
        index++;
    }

    public void PreviousMessage()
    {
        index--;
        if (index < 0)
            index = 0;
    }

    public void ShowMessageAtIndex(int value)
    {
        index = Mathf.Clamp(value, 0, messages.Count - 1);
    }
}
