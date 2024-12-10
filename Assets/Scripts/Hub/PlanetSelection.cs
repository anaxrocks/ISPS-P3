using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlanetSelection : MonoBehaviour
{
    public List<Button> buttons; // List of selectable buttons
    public List<GameObject> repBars; // List of selectable buttons
    public Button startButton; // Reference to the Start button
    private Button currentSelectedButton; // Tracks the currently selected button

    // Planet info when clicked
    public TextMeshProUGUI packageQuotaText;
    public TextMeshProUGUI fuelCostText;
    public TextMeshProUGUI shippingChargeText;
    public TextMeshProUGUI estimatedEarningsText;

    public static int selectedPlanet;
    public static int packageQuota;
    public static int fuelCost;
    public static float shippingCharge;
    private float estimatedEarnings;
    public GameObject planetCanvas;


    void Start()
    {
        // Disable the Start button at the beginning
        startButton.interactable = false;

        for (int i = Upgrades.researchCounter; i < 5; i++)
        {
            buttons[i].gameObject.SetActive(false);
            repBars[i].gameObject.SetActive(false);
        }
        for (int j = 0; j < Upgrades.researchCounter; j++)
        {
            buttons[j].gameObject.SetActive(true);
            repBars[j].gameObject.SetActive(true);
        }
    }

    void Update()
    {
        // Check the currently selected object in the EventSystem
        GameObject selectedObject = EventSystem.current.currentSelectedGameObject;

        // Ensure the selected object is a button and part of our valid list
        if (selectedObject != null && buttons.Contains(selectedObject.GetComponent<Button>()))
        {
            Button selectedButton = selectedObject.GetComponent<Button>();

            // Check if the selection has changed
            if (currentSelectedButton != selectedButton)
            {
                // Set value to the new selected button
                SetButtonValue(selectedButton);

                // Reset the previously selected button (if any)
                if (currentSelectedButton != null)
                {
                    ResetButtonValue(currentSelectedButton);
                }

                // Update the current selected button
                currentSelectedButton = selectedButton;

                // Enable the Start button
                startButton.interactable = Currency.money >= fuelCost;
            }
        }
        else if (selectedObject != startButton.gameObject) // Exclude Start button from the check
        {
            if (currentSelectedButton != null)
            {
                // Reset the value of the previously selected button
                ResetButtonValue(currentSelectedButton);
                currentSelectedButton = null;

                // packageQuotaText.text = "";
                // fuelCostText.text = "";
                // shippingChargeText.text = "";
                // estimatedEarningsText.text = "";
                planetCanvas.SetActive(false);

                // Disable the Start button
                startButton.interactable = false;
            }
        }
    }

    // Sets a value to the selected button
    private void SetButtonValue(Button button)
    {
        Text buttonText = button.GetComponentInChildren<Text>();
        if (buttonText != null)
        {
            buttonText.text = "Selected";
        }
    }

    // Resets the value of the deselected button
    private void ResetButtonValue(Button button)
    {
        Text buttonText = button.GetComponentInChildren<Text>();
        if (buttonText != null)
        {
            buttonText.text = "Not Selected";
        }
    }

    public void SetHomePlanet()
    {
        selectedPlanet = 0;
        if (Tutorial.tutorial == true)
        {
            packageQuota = 5;
        } else
        {
            packageQuota = 10;
        }
        fuelCost = 0;
        shippingCharge = 1 * Upgrades.moreMoneyPP;
        if (Currency.repHome == 5)
        {
            shippingCharge *= 2;
        }
        estimatedEarnings = (packageQuota * shippingCharge) - fuelCost;
        UpdateGoal();
    }

    public void SetPlanet1()
    {
        selectedPlanet = 1;
        packageQuota = 50;
        fuelCost = 200;
        shippingCharge = 5 * Upgrades.moreMoneyPP;
        if (Currency.rep1 == 5)
        {
            shippingCharge *= 2;
        }
        if (Currency.rep1 == 0)
        {
            shippingCharge /= 2;
        }
        estimatedEarnings = (packageQuota * shippingCharge) - fuelCost;
        UpdateGoal();
    }

    public void SetPlanet2()
    {
        selectedPlanet = 2;
        packageQuota = 100;
        fuelCost = 2000;
        shippingCharge = 50 * Upgrades.moreMoneyPP;
        if (Currency.rep2 == 5)
        {
            shippingCharge *= 2;
        }
        if (Currency.rep2 == 0)
        {
            shippingCharge /= 2;
        }
        estimatedEarnings = (packageQuota * shippingCharge) - fuelCost;
        UpdateGoal();
    }

    public void SetPlanet3()
    {
        selectedPlanet = 3; 
        packageQuota = 300;
        fuelCost = 10000;
        shippingCharge = 100 * Upgrades.moreMoneyPP;
        if (Currency.rep3 == 5)
        {
            shippingCharge *= 2;
        }
        if (Currency.rep3 == 0)
        {
            shippingCharge /= 2;
        }
        estimatedEarnings = (packageQuota * shippingCharge) - fuelCost;
        UpdateGoal();
    }

    public void SetPlanet4()
    {
        selectedPlanet = 4;
        packageQuota = 1000;
        fuelCost = 200000;
        shippingCharge = 500 * Upgrades.moreMoneyPP;
        if (Currency.rep4 == 5)
        {
            shippingCharge *= 2;
        }
        if (Currency.rep4 == 0)
        {
            shippingCharge /= 2;
        }
        estimatedEarnings = (packageQuota * shippingCharge) - fuelCost;
        UpdateGoal();
    }

    public void UpdateGoal()
    {
        startButton.interactable = Currency.money >= fuelCost;
        planetCanvas.SetActive(true);
        packageQuotaText.text = "Package Quota\n" + packageQuota.ToString();
        fuelCostText.text = "Fuel Cost\n$" + fuelCost.ToString();
        shippingChargeText.text = "$ per Package\n$" + shippingCharge.ToString();
        estimatedEarningsText.text = "Estimated Earnings\n$" + estimatedEarnings.ToString();
    }

    public void StartDay()
    {
        SceneManager.LoadScene("SortingPackagesMain");
    }
}
