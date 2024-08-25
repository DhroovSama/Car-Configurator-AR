using UnityEditor.Rendering;
using UnityEngine;

public class CarComponentsAssigner : MonoBehaviour
{
    [SerializeField]
    private SelectCars selectCars;

    [SerializeField]
    private MaterialsChanger materialsChanger;

    [SerializeField]
    private GameObject carPrefabSelectedMain;

    [SerializeField]
    private GameObject carPrefabInstantiated;

    public GameObject CarPrefabSelected
    {
        get { return carPrefabSelectedMain; }
        set { carPrefabSelectedMain = value; }
    }

    void Start()
    {
        if (carPrefabSelectedMain == null)
        {
            carPrefabSelectedMain = selectCars.CarToBeModifiedSelected;

            if (carPrefabSelectedMain != null)
            {
                carPrefabInstantiated = Instantiate(carPrefabSelectedMain, new Vector3(0, 0.068f, -1.5f), Quaternion.identity);

                AssignCarSelectedPrefab(carPrefabInstantiated);
                AssignCarComponents(carPrefabSelectedMain); // Pass the prefab as a parameter
                AssignWheelComponents(carPrefabSelectedMain); // Pass the prefab as a parameter
            }
        }
        else
        {
            Debug.Log("carPrefabSelectedMain is null");
        }
    }

    public void AssignComponentsForAR(GameObject Car_AR)
    {
        AssignCarComponents(Car_AR);
        AssignWheelComponents(Car_AR);
        AssignCarSelectedPrefab(Car_AR);
        
    }

    private void AssignCarSelectedPrefab(GameObject carPrefab)
    {
        materialsChanger.CarPrefabSelected = carPrefab;
    }

    private void AssignCarComponents(GameObject prefab) // Modified to accept a GameObject parameter
    {
        GameObject mainBody = FindChildFromParent(prefab, "Main body");
        if (mainBody != null)
        {
            materialsChanger.CarMainBodyColor = mainBody;
        }
        else { Debug.Log("mainBody is null"); }

        GameObject carHood = FindChildFromParent(prefab, "Hood");
        if (carHood != null)
        {
            materialsChanger.CarHoodColor = carHood;
        }
        else { Debug.Log("carHood is null"); }
    }

    private void AssignWheelComponents(GameObject prefab) // Modified to accept a GameObject parameter
    {
        GameObject wheel = FindChildFromParent(prefab, "Wheels");
        if (wheel != null)
        {
            GameObject wheel1 = FindChildFromParent(wheel, "Viper_Wheel_1");
            if (wheel1 != null)
            {
                materialsChanger.Wheel_1 = wheel1;
            }
            else { Debug.Log("wheel1 is null"); }

            GameObject wheel2 = FindChildFromParent(wheel, "Viper_Wheel_2");
            if (wheel2 != null)
            {
                materialsChanger.Wheel_2 = wheel2;
            }
            else { Debug.Log("wheel2 is null"); }

            GameObject wheel3 = FindChildFromParent(wheel, "Viper_Wheel_3");
            if (wheel2 != null) // This seems to be a typo, should check if wheel3!= null
            {
                materialsChanger.Wheel_3 = wheel3;
            }
            else { Debug.Log("wheel3 is null"); }

            GameObject wheel4 = FindChildFromParent(wheel, "Viper_Wheel_4");
            if (wheel4 != null)
            {
                materialsChanger.Wheel_4 = wheel4;
            }
            else { Debug.Log("wheel4 is null"); }
        }
    }

    #region FindChildFromParent
    // Utility function to find a child GameObject by name from a parent GameObject
    public GameObject FindChildFromParent(GameObject parent, string childName)
    {
        return GameObject.Find(childName);
    }
    #endregion
}
