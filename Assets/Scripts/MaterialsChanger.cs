using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialsChanger : MonoBehaviour
{
    [SerializeField] private GameObject carPrefabSelected;

    [Header("Car")]
    [Space]
    [SerializeField] private GameObject carMainBodyColor;
    [SerializeField] private GameObject carHoodColor;

    [Header("Wheels")]
    [Space]
    [SerializeField] private GameObject wheel_1;
    [SerializeField] private GameObject wheel_2;
    [SerializeField] private GameObject wheel_3;
    [SerializeField] private GameObject wheel_4;

    #region Getter & Setter Methods
    public GameObject CarPrefabSelected { get { return carPrefabSelected; } set { carPrefabSelected = value; } }
    public GameObject CarMainBodyColor { get { return carMainBodyColor; } set { carMainBodyColor = value; } }
    public GameObject CarHoodColor { get { return carHoodColor; } set { carHoodColor = value; } }

    public GameObject Wheel_1 { get { return wheel_1; } set { wheel_1 = value; } }
    public GameObject Wheel_2 { get { return wheel_2; } set { wheel_2 = value; } }
    public GameObject Wheel_3 { get { return wheel_3; } set { wheel_3 = value; } }
    public GameObject Wheel_4 { get { return wheel_4; } set { wheel_4 = value; } }
    #endregion

    [Header("Main Body Materials")]
    [SerializeField] private Material[] mainBodyColor;
    [SerializeField] private Button[] mainBodyColorButtons;

    [Header("Pin Stripe Materials")]
    [SerializeField] private Material[] pinStripeColor;
    [SerializeField] private Button[] pinStripeButtons;

    [Header("Wheel Rims Materials")]
    [SerializeField] private Material[] WheelRimsColor;
    [SerializeField] private Button[] WheelRimsButtons;

    [Header("Brake Callipers Materials")]
    [SerializeField] private Material[] WheelCalliperColor;
    [SerializeField] private Button[] WheelCalliperButtons;

    void Start()
    {
        AssignCarPartsMaterials();
    }

    public void AssignCarPartsMaterials()
    {
        Main_Body();
        Pin_Stripes();
        Wheel_Rims();
        Wheel_BrakeCallipers();
    }

    #region Main Body Color Assignment
    public void Main_Body()
    {
        for (int i = 0; i < mainBodyColorButtons.Length; i++)
        {
            int index = i;
            mainBodyColorButtons[i].onClick.AddListener(() => MainBodyMaterial(index));
        }
    }

    private void MainBodyMaterial(int materialIndex)
    {
        MainBodyColorChange_OnBody(materialIndex);
        MainBodyColorChange_OnHood(materialIndex);
    }
    private void MainBodyColorChange_OnBody(int materialIndex)
    {
        MeshRenderer carMainBodyRenderer_OnBody = carMainBodyColor.GetComponent<MeshRenderer>();

        if (carMainBodyRenderer_OnBody.materials.Length >= 5)
        {
            Material[] newMaterials = new Material[carMainBodyRenderer_OnBody.materials.Length];

            for (int i = 0; i < carMainBodyRenderer_OnBody.materials.Length; i++)
            {
                newMaterials[i] = carMainBodyRenderer_OnBody.materials[i];
            }

            newMaterials[1] = mainBodyColor[materialIndex];

            carMainBodyRenderer_OnBody.materials = newMaterials;
        }
        else
        {
            Debug.LogError("The Car does not have enough materials to change the material");
        }
    }
    private void MainBodyColorChange_OnHood(int materialIndex)
    {
        MeshRenderer carMainBodyRenderer_OnHood = carHoodColor.GetComponent<MeshRenderer>();

        if (carMainBodyRenderer_OnHood.materials.Length >= 2)
        {
            Material[] newMaterials = new Material[carMainBodyRenderer_OnHood.materials.Length];

            for (int i = 0; i < carMainBodyRenderer_OnHood.materials.Length; i++)
            {
                newMaterials[i] = carMainBodyRenderer_OnHood.materials[i];
            }

            newMaterials[0] = mainBodyColor[materialIndex];

            carMainBodyRenderer_OnHood.materials = newMaterials;
        }
        else
        {
            Debug.LogError("The Car does not have enough materials to change the material");
        }
    }
    #endregion

    #region Pin Stripes Color Assignment
    public void Pin_Stripes()
    {
        for (int i = 0; i < pinStripeButtons.Length; i++)
        {
            int index = i;
            pinStripeButtons[i].onClick.AddListener(() => PinStripeMaterial(index));
        }
    }

    private void PinStripeMaterial(int materialIndex)
    {
        PinStripeChange_OnBody(materialIndex);
        PinStripe_OnHood(materialIndex);
    }
    private void PinStripeChange_OnBody(int materialIndex)
    {
        MeshRenderer PinStripeRenderer_OnBody = carMainBodyColor.GetComponent<MeshRenderer>();

        if (PinStripeRenderer_OnBody.materials.Length >= 5)
        {
            Material[] newMaterials = new Material[PinStripeRenderer_OnBody.materials.Length];

            for (int i = 0; i < PinStripeRenderer_OnBody.materials.Length; i++)
            {
                newMaterials[i] = PinStripeRenderer_OnBody.materials[i];
            }

            newMaterials[2] = pinStripeColor[materialIndex];

            PinStripeRenderer_OnBody.materials = newMaterials;
        }
        else
        {
            Debug.LogError("The Car does not have enough materials to change the material");
        }
    }
    private void PinStripe_OnHood(int materialIndex)
    {
        MeshRenderer PinStripeRenderer_OnHood = carHoodColor.GetComponent<MeshRenderer>();

        if (PinStripeRenderer_OnHood.materials.Length >= 2)
        {
            Material[] newMaterials = new Material[PinStripeRenderer_OnHood.materials.Length];

            for (int i = 0; i < PinStripeRenderer_OnHood.materials.Length; i++)
            {
                newMaterials[i] = PinStripeRenderer_OnHood.materials[i];
            }

            newMaterials[1] = pinStripeColor[materialIndex];

            PinStripeRenderer_OnHood.materials = newMaterials;
        }
        else
        {
            Debug.LogError("The Car does not have enough materials to change the material");
        }
    }
    #endregion

    #region Wheel Rims Color Assignment
    public void Wheel_Rims()
    {
        for (int i = 0; i < WheelRimsButtons.Length; i++)
        {
            int index = i;
            WheelRimsButtons[i].onClick.AddListener(() => WheelRimsMaterial(index));
        }
    }

    private void WheelRimsMaterial(int materialIndex)
    {
        WheelRimsColorChange(materialIndex);
    }
    private void WheelRimsColorChange(int materialIndex)
    {
        Wheel_1_RimsColorChange(materialIndex);
        Wheel_2_RimsColorChange(materialIndex);
        Wheel_3_RimsColorChange(materialIndex);
        Wheel_4_RimsColorChange(materialIndex);

    }

    private void Wheel_1_RimsColorChange(int materialIndex)
    {
        MeshRenderer Wheel_1_RimsRenderer = wheel_1.GetComponent<MeshRenderer>();

        if (Wheel_1_RimsRenderer.materials.Length >= 4)
        {
            Material[] newMaterials = new Material[Wheel_1_RimsRenderer.materials.Length];

            for (int i = 0; i < Wheel_1_RimsRenderer.materials.Length; i++)
            {
                newMaterials[i] = Wheel_1_RimsRenderer.materials[i];
            }

            newMaterials[0] = WheelRimsColor[materialIndex];

            Wheel_1_RimsRenderer.materials = newMaterials;
        }
        else
        {
            Debug.LogError("The Wheel does not have enough materials to change the material");
        }
    }
    private void Wheel_2_RimsColorChange(int materialIndex)
    {
        MeshRenderer Wheel_2_RimsRenderer = wheel_2.GetComponent<MeshRenderer>();

        if (Wheel_2_RimsRenderer.materials.Length >= 4)
        {
            Material[] newMaterials = new Material[Wheel_2_RimsRenderer.materials.Length];

            for (int i = 0; i < Wheel_2_RimsRenderer.materials.Length; i++)
            {
                newMaterials[i] = Wheel_2_RimsRenderer.materials[i];
            }

            newMaterials[0] = WheelRimsColor[materialIndex];

            Wheel_2_RimsRenderer.materials = newMaterials;
        }
        else
        {
            Debug.LogError("The Wheel does not have enough materials to change the material");
        }
    }
    private void Wheel_3_RimsColorChange(int materialIndex)
    {
        MeshRenderer Wheel_3_RimsRenderer = wheel_3.GetComponent<MeshRenderer>();

        if (Wheel_3_RimsRenderer.materials.Length >= 4)
        {
            Material[] newMaterials = new Material[Wheel_3_RimsRenderer.materials.Length];

            for (int i = 0; i < Wheel_3_RimsRenderer.materials.Length; i++)
            {
                newMaterials[i] = Wheel_3_RimsRenderer.materials[i];
            }

            newMaterials[0] = WheelRimsColor[materialIndex];

            Wheel_3_RimsRenderer.materials = newMaterials;
        }
        else
        {
            Debug.LogError("The Wheel does not have enough materials to change the material");
        }
    }
    private void Wheel_4_RimsColorChange(int materialIndex)
    {
        MeshRenderer Wheel_4_RimsRenderer = wheel_4.GetComponent<MeshRenderer>();

        if (Wheel_4_RimsRenderer.materials.Length >= 4)
        {
            Material[] newMaterials = new Material[Wheel_4_RimsRenderer.materials.Length];

            for (int i = 0; i < Wheel_4_RimsRenderer.materials.Length; i++)
            {
                newMaterials[i] = Wheel_4_RimsRenderer.materials[i];
            }

            newMaterials[0] = WheelRimsColor[materialIndex];

            Wheel_4_RimsRenderer.materials = newMaterials;
        }
        else
        {
            Debug.LogError("The Wheel does not have enough materials to change the material");
        }
    }

    #endregion

    #region Wheel Calliper Color Assignment
    public void Wheel_BrakeCallipers()
    {
        for (int i = 0; i < WheelCalliperButtons.Length; i++)
        {
            int index = i;
            WheelCalliperButtons[i].onClick.AddListener(() => WheelCalliperMaterial(index));
        }
    }

    private void WheelCalliperMaterial(int materialIndex)
    {
        WheelCalliperChange(materialIndex);
    }
    private void WheelCalliperChange(int materialIndex)
    {
        Wheel_1_CalliperColorChange(materialIndex);
        Wheel_2_CalliperColorChange(materialIndex);
        Wheel_3_CalliperColorChange(materialIndex);
        Wheel_4_CalliperColorChange(materialIndex);

    }

    private void Wheel_1_CalliperColorChange(int materialIndex)
    {
        MeshRenderer Wheel_1_CalliperRenderer = wheel_1.GetComponent<MeshRenderer>();

        if (Wheel_1_CalliperRenderer.materials.Length >= 4)
        {
            Material[] newMaterials = new Material[Wheel_1_CalliperRenderer.materials.Length];

            for (int i = 0; i < Wheel_1_CalliperRenderer.materials.Length; i++)
            {
                newMaterials[i] = Wheel_1_CalliperRenderer.materials[i];
            }

            newMaterials[3] = WheelRimsColor[materialIndex];

            Wheel_1_CalliperRenderer.materials = newMaterials;
        }
        else
        {
            Debug.LogError("The Wheel does not have enough materials to change the material");
        }
    }
    private void Wheel_2_CalliperColorChange(int materialIndex)
    {
        MeshRenderer Wheel_2_CalliperRenderer = wheel_2.GetComponent<MeshRenderer>();

        if (Wheel_2_CalliperRenderer.materials.Length >= 4)
        {
            Material[] newMaterials = new Material[Wheel_2_CalliperRenderer.materials.Length];

            for (int i = 0; i < Wheel_2_CalliperRenderer.materials.Length; i++)
            {
                newMaterials[i] = Wheel_2_CalliperRenderer.materials[i];
            }

            newMaterials[3] = WheelRimsColor[materialIndex];

            Wheel_2_CalliperRenderer.materials = newMaterials;
        }
        else
        {
            Debug.LogError("The Wheel does not have enough materials to change the material");
        }
    }
    private void Wheel_3_CalliperColorChange(int materialIndex)
    {
        MeshRenderer Wheel_3_CalliperRenderer = wheel_3.GetComponent<MeshRenderer>();

        if (Wheel_3_CalliperRenderer.materials.Length >= 4)
        {
            Material[] newMaterials = new Material[Wheel_3_CalliperRenderer.materials.Length];

            for (int i = 0; i < Wheel_3_CalliperRenderer.materials.Length; i++)
            {
                newMaterials[i] = Wheel_3_CalliperRenderer.materials[i];
            }

            newMaterials[3] = WheelRimsColor[materialIndex];

            Wheel_3_CalliperRenderer.materials = newMaterials;
        }
        else
        {
            Debug.LogError("The Wheel does not have enough materials to change the material");
        }
    }
    private void Wheel_4_CalliperColorChange(int materialIndex)
    {
        MeshRenderer Wheel_4_CalliperRenderer = wheel_4.GetComponent<MeshRenderer>();

        if (Wheel_4_CalliperRenderer.materials.Length >= 4)
        {
            Material[] newMaterials = new Material[Wheel_4_CalliperRenderer.materials.Length];

            for (int i = 0; i < Wheel_4_CalliperRenderer.materials.Length; i++)
            {
                newMaterials[i] = Wheel_4_CalliperRenderer.materials[i];
            }

            newMaterials[3] = WheelRimsColor[materialIndex];

            Wheel_4_CalliperRenderer.materials = newMaterials;
        }
        else
        {
            Debug.LogError("The Wheel does not have enough materials to change the material");
        }
    }

    #endregion

}
