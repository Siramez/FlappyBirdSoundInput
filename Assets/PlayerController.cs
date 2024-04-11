using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float pitchThreshold = 1000f; // Adjust this value based on microphone sensitivity.
    public float flapForce = 5f; // Adjust the force for upward movement.
    public float forwardSpeed = 2f; // Adjust the forward movement speed.
    public float gravityScale = 1f; // Adjust the gravity scale.
    public scoreManager scoreManager; // Reference to the ScoreManager script that handles UI updates.

    private Rigidbody2D rb;
    private AudioSource audioSource;
    private int sampleCount = 1024;
    private float[] samplesBuffer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        InitializeMicrophone();

        // Initialize the samples buffer
        samplesBuffer = new float[sampleCount];
    }

    void InitializeMicrophone()
    {
        if (Microphone.devices.Length > 0)
        {
            audioSource.clip = Microphone.Start(null, true, 1, AudioSettings.outputSampleRate);
            audioSource.loop = true;
            while (!(Microphone.GetPosition(null) > 0)) { }
            audioSource.Play();
        }
        else
        {
            Debug.LogError("No microphone found!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Adjust player's flight based on pitch
        float pitch = GetMicrophonePitch();
        if (pitch > pitchThreshold)
        {
            Flap();
        }

        // Apply gravity
        rb.gravityScale = gravityScale;

        // Apply forward movement
        rb.velocity = new Vector2(forwardSpeed, rb.velocity.y);

        float loudness = GetMicrophoneLoudness();
        scoreManager.UpdateMicrophoneLoudness(loudness);
    }

    float GetMicrophoneLoudness()
    {
        float sum = 0;
        foreach (float sample in samplesBuffer)
        {
            sum += sample * sample;
        }

        float rms = Mathf.Sqrt(sum / samplesBuffer.Length);
        float loudness = 20 * Mathf.Log10(rms);

        return loudness;
    }

    float GetMicrophonePitch()
    {
        audioSource.GetOutputData(samplesBuffer, 0);

        float pitchSum = 0;
        for (int i = 0; i < sampleCount; i++)
        {
            pitchSum += Mathf.Abs(samplesBuffer[i]);
        }

        return pitchSum;
    }

    void Flap()
    {
        // Apply an upward force to the player when the pitch exceeds the threshold.
        rb.velocity = new Vector2(rb.velocity.x, flapForce);
    }
}
