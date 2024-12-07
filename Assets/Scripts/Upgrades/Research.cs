using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Research : MonoBehaviour
{
    //Research animations
    public static Research instance;
    public GameObject failAnimation;
    public TextMeshProUGUI notif;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }

    void Update()
    {
        if(notif.gameObject.activeSelf == true && 
        (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
        {
            notif.gameObject.SetActive(false);
            failAnimation.SetActive(false);
        }
    }
    public void playSuccess()
    {
        failAnimation.SetActive(true);
        failAnimation.GetComponent<Animator>().Play("successful");
        notif.text = "Research successful! Check out the hub!";
        notif.color = Color.black;

        AnimationClip clip = GetAnimationClip("fail");
        float animationLength = clip.length;
        StartCoroutine(WaitForAnimation(animationLength));
    }

    public void playFail()
    {
        failAnimation.SetActive(true);
        failAnimation.GetComponent<Animator>().Play("fail");
        notif.text = "Research unsuccessful. Try again next time!";
        notif.color = Color.white;

        AnimationClip clip = GetAnimationClip("fail");
        float animationLength = clip.length;
        StartCoroutine(WaitForAnimation(animationLength));
    }

    private IEnumerator WaitForAnimation(float duration)
    {
        yield return new WaitForSeconds(duration);
        notif.gameObject.SetActive(true);
    }

    private AnimationClip GetAnimationClip(string animationName)
    {
        foreach (AnimationClip clip in failAnimation.GetComponent<Animator>().runtimeAnimatorController.animationClips)
        {
            if (clip.name == animationName)
            {
                return clip; // Return the animation clip if its name matches
            }
        }
        return null; // Return null if no clip matches
    }
}
