using UnityEngine;

public class TriggerToggle : MonoBehaviour
{
    [Header("Tag Settings")]
    [Tooltip("The tag that triggers the toggle.")]
    public string targetTag = "Player";

    [Header("Objects to Toggle Between")]
    [Tooltip("Each time the trigger is entered, the next object in this list will activate and the others will deactivate.")]
    public GameObject[] toggleObjects;

    [Header("Settings")]
    [Tooltip("If true, the toggle can happen multiple times on repeated entries.")]
    public bool allowRepeatToggle = true;

    private int currentIndex = -1;
    private bool hasToggled = false;

    private void Start()
    {
        // Initialize: only first active object stays active if any
        for (int i = 0; i < toggleObjects.Length; i++)
        {
            if (toggleObjects[i] != null)
                toggleObjects[i].SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(targetTag))
            return;

        if (!allowRepeatToggle && hasToggled)
            return;

        hasToggled = true;

        // Move to next index in the list (loop back to 0)
        currentIndex = (currentIndex + 1) % toggleObjects.Length;

        // Update active states
        for (int i = 0; i < toggleObjects.Length; i++)
        {
            if (toggleObjects[i] != null)
                toggleObjects[i].SetActive(i == currentIndex);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Reset flag so it can toggle again next time (if repeat allowed)
        if (allowRepeatToggle && other.CompareTag(targetTag))
        {
            hasToggled = false;
        }
    }
}
