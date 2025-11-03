using UnityEngine;

public class TriggerActivator : MonoBehaviour
{
    [Header("Tag Settings")]
    [Tooltip("The tag of the object that should trigger activation.")]
    public string targetTag = "Player";

    [Header("Objects to Activate")]
    public GameObject[] activateOnEnter;

    [Header("Objects to Deactivate")]
    public GameObject[] deactivateOnEnter;

    [Header("Optional Exit Behavior")]
    [Tooltip("If true, will revert activation/deactivation on exit.")]
    public bool revertOnExit = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            foreach (GameObject obj in activateOnEnter)
                if (obj != null) obj.SetActive(true);

            foreach (GameObject obj in deactivateOnEnter)
                if (obj != null) obj.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (revertOnExit && other.CompareTag(targetTag))
        {
            foreach (GameObject obj in activateOnEnter)
                if (obj != null) obj.SetActive(false);

            foreach (GameObject obj in deactivateOnEnter)
                if (obj != null) obj.SetActive(true);
        }
    }
}
