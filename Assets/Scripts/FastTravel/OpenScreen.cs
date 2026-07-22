using UnityEngine;
using UnityEngine.InputSystem;

public class OpenScreen : MonoBehaviour
{
    [SerializeField] GameObject presetMap;
    [SerializeField] Transform playerTransform;
    [SerializeField] Transform TravelPoint1;
    [SerializeField] Transform TravelPoint2;
    [SerializeField] Transform TravelPoint3;
    [SerializeField] Transform TravelPoint4;
    private bool isOpen = false;

    void Update()
    {
        OpenMap();
    }
    private void OpenMap()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (!isOpen)
            {
                presetMap.SetActive(true);
                isOpen = true;

                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                presetMap.SetActive(false);
                isOpen = false;

                Cursor.lockState = CursorLockMode.Locked;
            }

        }
    }
    public void Point1()
    {
        playerTransform.position = TravelPoint1.position;
        presetMap.SetActive(false);
        isOpen = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void Point2()
    {
        playerTransform.position = TravelPoint2.position;
        presetMap.SetActive(false);
        isOpen = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void Point3()
    {
        playerTransform.position = TravelPoint3.position;
        presetMap.SetActive(false);
        isOpen = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void Point4()
    {
        playerTransform.position = TravelPoint4.position;
        presetMap.SetActive(false);
        isOpen = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
