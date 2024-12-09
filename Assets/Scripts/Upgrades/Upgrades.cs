using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Upgrades : MonoBehaviour
{
    // Money counter top left
    public TextMeshProUGUI moneyText;

    /* Any upgrades with counter at the end means it is num of upgrades
     * purchased. Use the normal variable name without counter for updating values
     */

    // Sorting Upgrades
    public static int handLimit = 1;
    public static int handLimitCounter;
    public static float lessGarbage = 2.0f;
    public static int lessGarbageCounter;

    // Delivery Upgrades
    public static int increaseShootingSpeed = 1;
    public static int increaseShootingSpeedCounter;
    public static int moreHealth = 1;
    public static int moreHealthCounter;
    public static int addLasers;
    public static int addLasersCounter;

    // Route Upgrades
    public static float moreMoneyPP = 1; // more $ per package
    public static int moreMoneyPPCounter;
    public static int morePackagesDelivered = 1;
    public static int morePackagesDeliveredCounter;

    // Research upgrade
    public static int research; // might not need this, use researchCounter instead?
    public static int researchCounter = 1;
    public static int researchTries;
    public static int researchPieces;

    // UI References
    public Image handLimitUpgradeBar;
    public Image lessGarbageUpgradeBar;
    public Image increaseShootingSpeedUpgradeBar;
    public Image moreHealthUpgradeBar;
    public Image addLasersUpgradeBar;
    public Image moreMoneyPPUpgradeBar;
    public Image morePackagesDeliveredUpgradeBar;
    public Image researchUpgradeBar;
    public Sprite[] upgradeSprites; // Drag upgrade sprites in ascending order
    public Sprite maxButton;
    public Image[] buyButtons; 

    // Costs for upgrades
    public static int handLimitCost = 5;
    public TextMeshProUGUI handLimitCostText;
    public static int lessGarbageCost = 5;
    public TextMeshProUGUI lessGarbageCostText;
    public static int increaseShootingSpeedCost = 5;
    public TextMeshProUGUI increaseShootingSpeedCostText;
    public static int moreHealthCost = 5;
    public TextMeshProUGUI moreHealthCostText;
    public static int addLasersCost = 5;
    public TextMeshProUGUI addLasersCostText;
    public static int moreMoneyPPCost = 5;
    public TextMeshProUGUI moreMoneyPPCostText;
    public static int morePackagesDeliveredCost = 5;
    public TextMeshProUGUI morePackagesDeliveredCostText;
    public static int researchCost = 5;
    public TextMeshProUGUI researchCostText;

    void Start()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        moneyText.text = "$" + Currency.money.ToString();

        // Update upgrade bar sprites and costs
        UpdateUpgradeUI(handLimitUpgradeBar, handLimitCounter, handLimitCost, handLimitCostText, buyButtons[0]);
        UpdateUpgradeUI(lessGarbageUpgradeBar, lessGarbageCounter, lessGarbageCost, lessGarbageCostText, buyButtons[1]);
        UpdateUpgradeUI(increaseShootingSpeedUpgradeBar, increaseShootingSpeedCounter, increaseShootingSpeedCost, increaseShootingSpeedCostText, buyButtons[2]);
        UpdateUpgradeUI(moreHealthUpgradeBar, moreHealthCounter, moreHealthCost, moreHealthCostText, buyButtons[3]);
        UpdateUpgradeUI(addLasersUpgradeBar, addLasersCounter, addLasersCost, addLasersCostText, buyButtons[4]);
        UpdateUpgradeUI(moreMoneyPPUpgradeBar, moreMoneyPPCounter, moreMoneyPPCost, moreMoneyPPCostText, buyButtons[5]);
        UpdateUpgradeUI(morePackagesDeliveredUpgradeBar, morePackagesDeliveredCounter, morePackagesDeliveredCost, morePackagesDeliveredCostText, buyButtons[6]);
        UpdateUpgradeUI(researchUpgradeBar, researchCounter, researchCost, researchCostText, buyButtons[7]);
    }

    void UpdateUpgradeUI(Image upgradeBar, int counter, int cost, TextMeshProUGUI costText, Image buyButton)
    {
        upgradeBar.sprite = upgradeSprites[counter];

        if (counter == upgradeSprites.Length - 1) // Max upgrade
        {
            costText.text = "";
            buyButton.sprite = maxButton;
            buyButton.GetComponent<Button>().interactable = false;
        }
        else
        {
            costText.text = "$" + cost.ToString();
            buyButton.GetComponent<Button>().interactable = Currency.money >= cost;
        }
    }


    public void BuyHandLimitUpgrade()
    {
        if (Currency.money >= handLimitCost && handLimitCounter < upgradeSprites.Length - 1)
        {
            Currency.money -= handLimitCost;
            handLimitCost *= 2;
            handLimitCounter++;
            handLimit++;
            UpdateUI();
            SoundManager.Instance.PlaySound2D("Cha ching");
        }
    }

    public void BuyLessGarbageUpgrade()
    {
        if (Currency.money >= lessGarbageCost && lessGarbageCounter < upgradeSprites.Length - 1)
        {
            Currency.money -= lessGarbageCost;
            lessGarbageCost *= 2;
            lessGarbageCounter++;
            lessGarbage -= 0.4f;
            lessGarbage = Mathf.Round(lessGarbage * 10.0f) * 0.1f;
            UpdateUI();
            SoundManager.Instance.PlaySound2D("Cha ching");
        }
    }

    public void BuyIncreaseShootingSpeedUpgrade()
    {
        if (Currency.money >= increaseShootingSpeedCost && increaseShootingSpeedCounter < upgradeSprites.Length - 1)
        {
            Currency.money -= increaseShootingSpeedCost;
            increaseShootingSpeedCost *= 2;
            increaseShootingSpeedCounter++;
            increaseShootingSpeed++;
            UpdateUI();
            SoundManager.Instance.PlaySound2D("Cha ching");
        }
    }

    public void BuyMoreHealthUpgrade()
    {
        if (Currency.money >= moreHealthCost && moreHealthCounter < upgradeSprites.Length - 1)
        {
            Currency.money -= moreHealthCost;
            moreHealthCost *= 2;
            moreHealthCounter++;
            // Change moreHealth value
            moreHealth++;
            UpdateUI();
            SoundManager.Instance.PlaySound2D("Cha ching");
        }
    }

    public void BuyAddLasersUpgrade()
    {
        if (Currency.money >= addLasersCost && addLasersCounter < upgradeSprites.Length - 1)
        {
            Currency.money -= addLasersCost;
            addLasersCost *= 2;
            addLasers++;
            addLasersCounter++;
            // Change addlasers value
            UpdateUI();
            SoundManager.Instance.PlaySound2D("Cha ching");
        }
    }

    public void BuyMoreMoneyPPUpgrade()
    {
        if (Currency.money >= moreMoneyPPCost && moreMoneyPPCounter < upgradeSprites.Length - 1)
        {
            Currency.money -= moreMoneyPPCost;
            moreMoneyPPCost *= 2;
            moreMoneyPPCounter++;
            // MoreMoneyPP is used as a small multiplier. 
            moreMoneyPP += 0.2f;
            UpdateUI();
            SoundManager.Instance.PlaySound2D("Cha ching");
        }
    }

    public void BuyMorePackagesDeliveredUpgrade()
    {
        if (Currency.money >= morePackagesDeliveredCost && morePackagesDeliveredCounter < upgradeSprites.Length - 1)
        {
            Currency.money -= morePackagesDeliveredCost;
            morePackagesDeliveredCost *= 2;
            morePackagesDeliveredCounter++;
            morePackagesDelivered++;
            // Change morepackagesdelivered value
            UpdateUI();
            SoundManager.Instance.PlaySound2D("Cha ching");
        }
    }

    public void BuyResearchUpgrade()
    {
        if (Currency.money >= researchCost && researchCounter < upgradeSprites.Length - 1)
        {
            Currency.money -= researchCost;
            UpdateUI();
            SoundManager.Instance.PlaySound2D("Whoosh");

            // 25% chance to unlock piece of planet
            if (Random.Range(0, 4) == 1)
            {
                researchTries = 0;
                researchCounter++;
                researchCost *= 2;
                print("planet unlocked");
                // change research value
                UpdateUI();
                StartCoroutine(PlayAudioWithDelay("Success", 2f));
                Research.instance.playSuccess();
                print("1");
            }
            else
            {
                print("0");
                researchTries++;
                if (researchTries < 4)
                {
                    StartCoroutine(PlayAudioWithDelay("Lose", 2f));
                    Research.instance.playFail();
                }
            }
            // 3 failed tries = 1 success
            if (researchTries == 4)
            {
                researchTries = 0;
                researchCounter++;
                researchCost *= 2;
                print("planet unlocked");
                // change research value
                UpdateUI();
                Research.instance.playSuccess();
                StartCoroutine(PlayAudioWithDelay("Success", 2f));
            }
        }
    }

    IEnumerator PlayAudioWithDelay(string audioName, float delay)
    { 
        yield return new WaitForSeconds(delay); // Wait for the specified delay
        SoundManager.Instance.PlaySound2D(audioName); // Play the audio clip after the delay
    }

    public void GoToHub()
    {
        SceneManager.LoadScene("Hub");
    }
}