using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Summary : MonoBehaviour
{
    // UI Text elements
    public TextMeshProUGUI moneyMade; 
    public TextMeshProUGUI packagesSorted; 
    public TextMeshProUGUI packagesDelivered; 
    public TextMeshProUGUI laborCosts; 
    public TextMeshProUGUI fuelCosts; 
    public TextMeshProUGUI profit;
    private int earnings;
    private int totalprofit;

    // Start is called before the first frame update
    void Start()
    {
        earnings = Currency.pDelivered * PlanetSelection.shippingCharge;
        totalprofit = (Currency.pDelivered * PlanetSelection.shippingCharge) - PlanetSelection.fuelCost;
        Currency.money += totalprofit;

        // Update all the UI elements
        if (moneyMade != null)
            moneyMade.text = "Money Earned: $" + Currency.pDelivered.ToString();

        if (packagesSorted != null)
            packagesSorted.text = "Packages Sorted: " + Currency.pSorted.ToString();

        if (packagesDelivered != null)
            packagesDelivered.text = "Packages Delivered: " + Currency.pDelivered.ToString();

        if (laborCosts != null)
            laborCosts.text = "Labor costs: $0";

        if (fuelCosts != null)
            fuelCosts.text = "Fuel costs: $" + PlanetSelection.fuelCost.ToString();

        if (profit != null)
            profit.text = "Profit: $" + totalprofit.ToString();
    }

    public void GoToUpgrades()
    {
        SceneManager.LoadScene("Upgrades");
    }
}
