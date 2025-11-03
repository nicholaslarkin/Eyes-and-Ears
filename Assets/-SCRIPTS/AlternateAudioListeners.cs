using UnityEngine;

public class AlternateAudioListeners : MonoBehaviour
{
    public AudioListener listenerA;
    public AudioListener listenerB;

    private bool useA = true;

    void FixedUpdate()
    {
        // Toggle each frame
        useA = !useA;

        if (listenerA != null && listenerB != null)
        {
            listenerA.enabled = useA;
            listenerB.enabled = !useA;
        }
    }
}
