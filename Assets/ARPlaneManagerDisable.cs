using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARPlaneManagerDisable : MonoBehaviour
{
    [SerializeField]
    private ARPlaneManager aRPlaneManager;

    private void Start()
    {
        aRPlaneManager = GetComponent<ARPlaneManager>();
    }

    public void DisableARPlaneManager()
    {
        foreach (var plane in aRPlaneManager.trackables)
        {
            plane.gameObject.SetActive(false);
        }

        aRPlaneManager.enabled = false;
    }
}
