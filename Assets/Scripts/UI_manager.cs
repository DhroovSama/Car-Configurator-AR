using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UI_manager : MonoBehaviour
{
    [SerializeField]
    private TMP_Dropdown Selector, Dropdown_carOption, Dropdown_calliperOption;

    [SerializeField]
    private GameObject carOptions, wheelOptions, MainBody, PinStripes, Rims, BrakeCallipers;

    private void Start()
    {
        Selector.onValueChanged.AddListener(OnOptionChangedMainDropDown);

        Dropdown_carOption.onValueChanged.AddListener(OnOptionChangedCarOptionsDropDown);

        Dropdown_calliperOption.onValueChanged.AddListener(OnOptionChangedWheelOptionsDropDown);
    }

    private void OnOptionChangedMainDropDown(int selectedIndex)
    {
        switch (selectedIndex)
        {
            case 0:
                wheelOptions.SetActive(false);
                carOptions.SetActive(true);
                break;
            case 1:
                carOptions.SetActive(false);
                wheelOptions.SetActive(true);
                break;
            default:
                carOptions.SetActive(false);
                wheelOptions.SetActive(false);
                break;
        }
    }

    private void OnOptionChangedCarOptionsDropDown(int selectedIndex)
    {
        switch (selectedIndex)
        {
            case 0:
                PinStripes.SetActive(false);
                MainBody.SetActive(true);
                break;
            case 1:
                MainBody.SetActive(false);
                PinStripes.SetActive(true);
                break;
            default:
                MainBody.SetActive(false);
                PinStripes.SetActive(false);
                break;
        }
    }
    private void OnOptionChangedWheelOptionsDropDown(int selectedIndex)
    {
        switch (selectedIndex)
        {
            case 0:
                BrakeCallipers.SetActive(false);
                Rims.SetActive(true);
                break;
            case 1:
                Rims.SetActive(false);
                BrakeCallipers.SetActive(true);
                break;
            default:
                BrakeCallipers.SetActive(false);
                Rims.SetActive(false);
                break;
        }
    }
}
