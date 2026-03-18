using UnityEngine;

public class WheelRotation : MonoBehaviour
{
    public CarMovement car;
    public float wheelRadius = 0.5f;

    void Update()
    {
        float rotationSpeed = (car.speed / wheelRadius) * Mathf.Rad2Deg;
        transform.Rotate(0f, 0f, -rotationSpeed * Time.deltaTime);
    }
}