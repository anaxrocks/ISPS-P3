using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueCharacter
{
    public string name;
    public Sprite icon;
}

[System.Serializable]
public class DialogueLine
{
    public DialogueCharacter character;
    [TextArea(3, 10)]
    public string line;
}

[System.Serializable]
public class Dialogue
{
    public List<DialogueLine> dialogueLines = new List<DialogueLine>();
}

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public bool isAutomatic = false;
    private bool hasPlayed = false;
    public bool isTutorial = false;

    public void TriggerDialogue()
    {
        if (!hasPlayed)
        {
            if (Tutorial.tutorial == false && isTutorial == true)
            {

            } else
            {
                hasPlayed = true;
                DialogueManager.Instance.StartDialogue(dialogue);
            }
        }
    }

    private void Update()
    {
        if (isAutomatic && !DialogueManager.Instance.isDialogueActive && !hasPlayed)
        {
            Debug.Log("Triggering automatic dialogue");
            TriggerDialogue();
        }

        else if (DialogueManager.Instance.isDialogueActive && hasPlayed && (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space"))) {
            DialogueManager.Instance.DisplayNextDialogueLine();
        }

        else if (!hasPlayed && Tutorial.tutorial == true)
        {
            //SoundManager.Instance.PlaySound3D("Interact", transform.position);
            TriggerDialogue();
        }
    }
}