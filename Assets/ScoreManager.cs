using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour
{
    public Text microphoneValueText;

    public void UpdateMicrophoneLoudness(float loudness)
    {
        // Update the UI text to display the microphone loudness level.
        microphoneValueText.text = "Microphone Loudness: " + loudness.ToString("F2") + " dB"; // Display loudness with two decimal places and "dB" units.
    }

}
