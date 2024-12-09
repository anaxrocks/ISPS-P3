using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopupWindow : MonoBehaviour
{
    public TMP_Text popupText;

    private GameObject window;
    private Animator popupAnimator;

    private Queue<string> popupQueue; //make it different type for more detailed popups, you can add different types, titles, descriptions etc
    private Coroutine queueChecker;

    private void Start()
    {
        window = transform.GetChild(0).gameObject;
        popupAnimator = window.GetComponent<Animator>();
        window.SetActive(false);
        popupQueue = new Queue<string>();
    }

    public void AddToQueue(string text)
    {//parameter the same type as queue
        switch(text)
        {
            case "handLimit":
                text = "Hand limit has increased to " + Upgrades.handLimit.ToString();
                break;

            case "lessGarbage":
                text = "Garbage spawn rate has decreased to " + Upgrades.lessGarbage.ToString();
                break;

            case "shootingSpeed":
                text = "Shooting speed increased to " + Upgrades.increaseShootingSpeed.ToString();
                break;

            case "moreHealth":
                text = "Health increased to " + Upgrades.moreHealth.ToString();
                break;

            case "lasers":
                if (Upgrades.addLasers == 1)
                {
                    text = "Lasers added to your ship!";
                }
                else
                {
                    text = "Laser shooting speed increased to " + Upgrades.addLasers.ToString();
                }
                break;

            case "moneyPerPackage":
                text = "Profit multiplier increased to " + Upgrades.moreMoneyPP.ToString();
                break;

            case "morePackagesDelivered":
                text = "Delivered packages multiplier increased to " + Upgrades.morePackagesDelivered.ToString();
                break;
        }
        popupQueue.Enqueue(text);
        if (queueChecker == null)
            queueChecker = StartCoroutine(CheckQueue());
    }

    private void ShowPopup(string text)
    { //parameter the same type as queue
        window.SetActive(true);
        popupText.text = text;
        popupAnimator.Play("Popup Window");
    }

    private IEnumerator CheckQueue()
    {
        do
        {
            ShowPopup(popupQueue.Dequeue());
            do
            {
                yield return null;
            } while (!popupAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Idle"));

        } while (popupQueue.Count > 0);
        window.SetActive(false);
        queueChecker = null;
    }

}