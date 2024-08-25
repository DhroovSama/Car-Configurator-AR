using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectCars : MonoBehaviour
{
    [SerializeField]
    private GameObject carToBeModifiedSelected;

    [SerializeField]
    private Button leftButton;
    [SerializeField]
    private Button rightButton;

    [SerializeField]
    private GameObject[] carObjects;

    [SerializeField]
    private GameObject[] carObjects_BasePrefabs;

    [SerializeField]
    private int currentIndex = 0;

    public GameObject CarToBeModifiedSelected
    {
        get { return carToBeModifiedSelected; }
        set { carToBeModifiedSelected = value; }
    }

    public void AssignCurrentCarToModify()
    {
        if (currentIndex >= 0 && currentIndex < carObjects.Length)
        {
            carToBeModifiedSelected = carObjects_BasePrefabs[currentIndex];
            Debug.Log($"Assigned: {carToBeModifiedSelected.name} to be modified");
        }
        else
        {
            Debug.Log("Invalid index. Cannot assign car to be modified.");
        }
    }

    public void SceneChangeToCustomize()
    {
        StartCoroutine(LoadScene1());
    }

    private IEnumerator LoadScene1()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(1);
    }

    public void OnRightButtonClick()
    {
        Debug.Log("Right button clicked");
        Debug.Log($"Current Index: {currentIndex}");

        if (currentIndex < carObjects.Length)
        {
            Debug.Log($"Deactivating: {carObjects[currentIndex].name}");
            carObjects[currentIndex].SetActive(false);

            currentIndex++;
            if (currentIndex < carObjects.Length)
            {
                Debug.Log($"Activating: {carObjects[currentIndex].name}");
                carObjects[currentIndex].SetActive(true);
                Debug.Log($"Activated: {carObjects[currentIndex].name}");
            }
            else
            {
                Debug.Log("Reached the last index. Resetting currentIndex.");
                currentIndex = 0;
                carObjects[currentIndex].SetActive(true);
                Debug.Log($"Looped back to: {carObjects[currentIndex].name}");
            }
        }
        else
        {
            Debug.Log("Reached the last index. Resetting currentIndex.");
            currentIndex = 0;
            carObjects[currentIndex].SetActive(true);
            Debug.Log($"Looped back to: {carObjects[currentIndex].name}");
        }
    }

    public void OnLeftButtonClick()
    {
        Debug.Log("Left button clicked");
        Debug.Log($"Current Index: {currentIndex}");

        if (currentIndex > 0)
        {
            Debug.Log($"Deactivating: {carObjects[currentIndex].name}");
            carObjects[currentIndex].SetActive(false);

            currentIndex--;
            if (currentIndex >= 0)
            {
                Debug.Log($"Activating: {carObjects[currentIndex].name}");
                carObjects[currentIndex].SetActive(true);
                Debug.Log($"Activated: {carObjects[currentIndex].name}");
            }
            else
            {
                Debug.Log("Reached the first index. Resetting currentIndex.");
                // Deactivate the current GameObject before resetting currentIndex
                carObjects[currentIndex].SetActive(false);
                currentIndex = carObjects.Length - 1;
                // Activate the last GameObject after resetting currentIndex
                carObjects[currentIndex].SetActive(true);
                Debug.Log($"Looped back to: {carObjects[currentIndex].name}");
            }
        }
        else
        {
            Debug.Log("Reached the first index. Resetting currentIndex.");
            // Deactivate the current GameObject before resetting currentIndex
            carObjects[currentIndex].SetActive(false);
            currentIndex = carObjects.Length - 1;
            // Activate the last GameObject after resetting currentIndex
            carObjects[currentIndex].SetActive(true);
            Debug.Log($"Looped back to: {carObjects[currentIndex].name}");
        }
    }
}
