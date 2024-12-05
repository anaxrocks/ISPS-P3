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
    public TextMeshProUGUI feedbackMsg;

    private int earnings;
    private int totalprofit;

    // Start is called before the first frame update
    void Start()
    {
        //MIGHT NEED TO CHANGE moreMoneyPP value. Right now it acts as a multiplier. 
        earnings = Currency.pDelivered * PlanetSelection.shippingCharge * Upgrades.moreMoneyPP;
        if (Currency.repHome == 5){
            earnings = earnings * 2;
        }
        totalprofit = earnings - PlanetSelection.fuelCost;
        Currency.money += totalprofit;

        // Update all the UI elements
        if (moneyMade != null){
            moneyMade.text = "Money Earned: $" + earnings.ToString();}

        if (packagesSorted != null){
            packagesSorted.text = "Packages Sorted: " + Currency.pSorted.ToString();}

        if (packagesDelivered != null){
            packagesDelivered.text = "Packages Delivered: " + Currency.pDelivered.ToString();}

        if (laborCosts != null){
            laborCosts.text = "Labor costs: $0";}

        if (fuelCosts != null){
            fuelCosts.text = "Fuel costs: $" + PlanetSelection.fuelCost.ToString();}

        if (profit != null){
            profit.text = "Profit: $" + totalprofit.ToString();}

        if (Currency.pDelivered >= PlanetSelection.packageQuota){
            feedbackMsg.text = "Well done! You've completed your quota!";
            feedbackMsg.color = Color.green;
            if (PlanetSelection.selectedPlanet == 0 && Currency.repHome < 5){
                Currency.repHome += 1;
                Debug.Log("repHome: " + Currency.repHome);
            }

            if(PlanetSelection.selectedPlanet == 1 && Currency.rep1 < 5){
                Currency.rep1 += 1;
            }

            if(PlanetSelection.selectedPlanet == 2 && Currency.rep2 < 5){
                Currency.rep2 += 1;
            }

            if(PlanetSelection.selectedPlanet == 3 && Currency.rep3 < 5){
                Currency.rep3 += 1;
            }

            if(PlanetSelection.selectedPlanet == 4 && Currency.rep4 < 5){
                Currency.rep4 += 1;
            }
        }

        if (Currency.pDelivered < PlanetSelection.packageQuota){
            feedbackMsg.text = "You didn't make the quota this time.. Try again!";
            feedbackMsg.color = Color.red;
            if (PlanetSelection.selectedPlanet == 0 && Currency.repHome > 3){
                Currency.repHome -= 1;
            }

            if(PlanetSelection.selectedPlanet == 1 && Currency.rep1 > 0){
                Currency.rep1 -= 1;
            }

            if(PlanetSelection.selectedPlanet == 2 && Currency.rep2 > 0){
                Currency.rep2 -= 1;
            }

            if(PlanetSelection.selectedPlanet == 3 && Currency.rep3 > 0){
                Currency.rep3 -= 1;
            }

            if(PlanetSelection.selectedPlanet == 4 && Currency.rep4 > 0){
                Currency.rep4 -= 1;
            }
        }

    }

    public void GoToUpgrades()
    {
        SceneManager.LoadScene("Upgrades");
    }
}
