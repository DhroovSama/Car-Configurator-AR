using UnityEngine;

[CreateAssetMenu(fileName = "CarSelectionData", menuName = "ScriptableObjects/CarSelectionData")]
public class CarSelectionData : ScriptableObject
{
    [SerializeField]
    public GameObject selectedCar;

    public static CarSelectionData Instance;

    private void OnEnable()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
}
