using UnityEngine;
using UnityEngine.Audio;

public class VirtualEarsAudio : MonoBehaviour
{
    public AudioMixer mixer;
    public Transform earLeft;
    public Transform earRight;
    public Transform soundSource;

    void Update()
    {
        // Distance to each ear
        float distLeft = Vector3.Distance(earLeft.position, soundSource.position);
        float distRight = Vector3.Distance(earRight.position, soundSource.position);

        // Inverse falloff curve (simple linear example)
        float leftVol = Mathf.Clamp01(1f - distLeft / 10f);
        float rightVol = Mathf.Clamp01(1f - distRight / 10f);

        // Convert to decibels (Unity Mixer works in dB)
        float leftDB = Mathf.Lerp(-80f, 0f, leftVol);
        float rightDB = Mathf.Lerp(-80f, 0f, rightVol);

        // Push values into Audio Mixer
        mixer.SetFloat("EarLeftVolume", leftDB);
        mixer.SetFloat("EarRightVolume", rightDB);
    }
}
