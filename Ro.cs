using UnityEngine;

public class SpinObject : MonoBehaviour
{
    // Speed of rotation in degrees per second
    public float rotationSpeed = 100.0f;

    void Update()
    {
        // Rotate the object around its Y-axis
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
