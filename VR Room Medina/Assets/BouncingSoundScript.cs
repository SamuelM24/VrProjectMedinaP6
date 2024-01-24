using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingSoundScript : MonoBehaviour
{
    public AudioClip bounceSound;
    public float volumeMultiplier = 1.0f;

    private AudioSource audioSource;
    private Rigidbody rigidbody;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rigidbody = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the ground or any surface you want to trigger the sound
        if (collision.gameObject.CompareTag("Ground"))
        {
            // Calculate volume based on the ball's velocity
            float volume = Mathf.Clamp01(rigidbody.velocity.magnitude * volumeMultiplier);

            // Play the bounce sound with calculated volume
            audioSource.PlayOneShot(bounceSound, volume);
        }
    }
}

