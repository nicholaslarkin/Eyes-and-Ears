using UnityEngine;
using UnityEngine.InputSystem;

public class VRStickMovement : MonoBehaviour
{
    [Header("References")]
    public Transform headTransform; // Your XR camera (inside XR Origin)
    public CharacterController controller;

    [Header("Settings")]
    public float moveSpeed = 2f;

    [Header("Input Action")]
    public InputActionProperty moveAction; // Left thumbstick (Vector2)

    void Update()
    {
        // Get stick input
        Vector2 input = moveAction.action.ReadValue<Vector2>();

        // Move in the direction the head is facing (ignoring vertical tilt)
        Vector3 forward = new Vector3(headTransform.forward.x, 0, headTransform.forward.z).normalized;
        Vector3 right = new Vector3(headTransform.right.x, 0, headTransform.right.z).normalized;

        Vector3 move = (forward * input.y + right * input.x) * moveSpeed * Time.deltaTime;

        controller.Move(move);
    }
}
