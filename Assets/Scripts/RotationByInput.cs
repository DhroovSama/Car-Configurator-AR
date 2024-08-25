using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 100f;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        transform.Rotate(0, horizontalInput * rotationSpeed * Time.deltaTime, 0);
    }
}
