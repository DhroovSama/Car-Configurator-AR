using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.InputSystem;

[RequireComponent(typeof(ARRaycastManager))]
public class PlaceOnPlane : MonoBehaviour
{
    [SerializeField]
    private SelectCars selectCars;

    [SerializeField]
    private ARPlaneManagerDisable aRPlaneManagerDisable;

    [SerializeField]
    private MaterialsChanger materialsChanger;

    [SerializeField] 
    private CarComponentsAssigner carComponentsAssigner;

    [SerializeField]
    GameObject placedPrefab;

    [SerializeField]
    private ARPlaneManager planeManager;

    GameObject spawnedObject;

    TouchControls controls;

    bool isPressed;
    bool isPlaced = false;
    public bool IsPlaced { get { return isPlaced; } }

    ARRaycastManager aRRaycastManager;
    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private void Awake()
    {
        aRRaycastManager = GetComponent<ARRaycastManager>();

        controls = new TouchControls();

        controls.control.touch.performed += _ => isPressed = true;
        controls.control.touch.canceled += _ => isPressed = false;
    }

    private void Start()
    {
        if (!isPlaced)
        {
            placedPrefab = FindObjectOfType<FindCarByScript>().gameObject;
            FindObjectOfType<FindCarByScript>().gameObject.SetActive(false);
        }
        else { Debug.Log("placed prefab is assigned"); }
    }

    void Update()
    {
        if (Pointer.current == null || isPressed == false || isPlaced)
            return;

        var touchPosition = Pointer.current.position.ReadValue();

        if (aRRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;

            if (!IsPlaced)
            {
                placedPrefab.SetActive(true);

                aRPlaneManagerDisable.DisableARPlaneManager();

                placedPrefab.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);

                Vector3 planeNormal = Vector3.up;
                float yOffset = Vector3.Dot(hitPose.position - hitPose.position, planeNormal) + hitPose.position.y;
                placedPrefab.transform.position = new Vector3(hitPose.position.x, yOffset, hitPose.position.z);

                isPlaced = true;
            }
            else
            {
                spawnedObject.transform.position = hitPose.position;
                spawnedObject.transform.rotation = hitPose.rotation;
            }
        }
    }


    private void AssignNewComponents()
    {
        carComponentsAssigner.AssignComponentsForAR(spawnedObject);
        materialsChanger.AssignCarPartsMaterials(); 
    }


    private void OnEnable()
    {
        controls.control.Enable();
    }

    private void OnDisable()
    {
        controls.control.Disable();
    }
}
