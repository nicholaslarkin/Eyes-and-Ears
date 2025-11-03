using UnityEngine;

public class KeepLocalRotationZero : MonoBehaviour
{
    void LateUpdate()
    {
        transform.localRotation = Quaternion.identity;
    }
}
