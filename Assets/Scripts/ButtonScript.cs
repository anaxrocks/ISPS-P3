using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public void PlayButtonSound()
    {
        SoundManager.Instance.PlaySound2D("Button");
    }
}
