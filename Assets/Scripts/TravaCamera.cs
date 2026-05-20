using UnityEngine;

public class TravaCamera : MonoBehaviour
{
    [Header("Configurações de Sensibilidade")]
    public float mouseSensitivity = 400f;
    float rotationX = 0f;
    [SerializeField]Transform playerBody;
    void Start()
    {
        playerBody = transform.parent;
        travaCamera();
    }
    void Update()
    {
        MoveCamera();
    }
    private void travaCamera()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void MoveCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);
        transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);
    }
}