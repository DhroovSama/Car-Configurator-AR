using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Rotatable : MonoBehaviour
{
    [SerializeField]
    private PinchDetection pinchDetection;

    [SerializeField]
    private InputAction pressed, axis;

    [SerializeField]
    private float speed;

    private bool isRotateAllowed;

    private Vector2 rotation;

    private void Awake()
    {
        pinchDetection = FindObjectOfType<PinchDetection>();

        pressed.Enable();
        axis.Enable();

        pressed.performed += _ => { StartCoroutine(Rotate()); };
        pressed.canceled += _ => { isRotateAllowed = false; };

        axis.performed += context => { rotation = context.ReadValue<Vector2>(); };
    }

    private IEnumerator Rotate()
    {
        isRotateAllowed = true;

        while (isRotateAllowed && pinchDetection.TouchCount !=2)
        {
            rotation *= speed;

            transform.Rotate(-Vector3.up, rotation.x, Space.World);

            yield return null;
        }
    }
}
