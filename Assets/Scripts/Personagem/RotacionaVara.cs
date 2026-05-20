using UnityEngine;

public class RotacionaVara : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    void FixedUpdate()
    {
        transform.rotation = cameraTransform.rotation * Quaternion.Euler(0, 95, -20);
    }
}
