using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class TravelPoints : MonoBehaviour
{
    [SerializeField]Transform playerTransform;
    [SerializeField]Transform TravelPoint1;
    [SerializeField]Transform TravelPoint2;
    [SerializeField]Transform TravelPoint3;
    [SerializeField]Transform TravelPoint4;
    public void Point1()
    {
        playerTransform.position = TravelPoint1.position;
    }
    public void Point2()
    {
        playerTransform.position = TravelPoint2.position;
    }
    public void Point3()
    {
        playerTransform.position = TravelPoint3.position;
    }
    public void Point4()
    {
        playerTransform.position = TravelPoint4.position;
    }
}
