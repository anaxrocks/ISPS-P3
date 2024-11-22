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

    public void TriggerDialogue()
    {
        hasPlayed = true;
        DialogueManager.Instance.StartDialogue(dialogue);
    }

    private void Update()
    {
        if (isAutomatic && !DialogueManager.Instance.isDialogueActive && !hasPlayed)
        {
            Debug.Log("Triggering automatic dialogue");
            TriggerDialogue();
        }

        // colliding but haven't pressed E yet
        // else if (isPlayerInTrigger && !Input.GetKeyDown(KeyCode.E) && !isAutomatic){
        //     if (attentionIcon != null){
        //         attentionIcon.GetComponent<SpriteRenderer>().enabled = true;
        //     }
        //         // attentionIcon.SetActive(true);
        //     // GetComponent<LineRenderer>().enabled = true;
        // }

        else if (DialogueManager.Instance.isDialogueActive && hasPlayed && (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space"))) {
            DialogueManager.Instance.DisplayNextDialogueLine();
        }

        else if (!hasPlayed && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Pressed E");
            Debug.Log(transform.position);
            //SoundManager.Instance.PlaySound3D("Interact", transform.position);
            TriggerDialogue();
        }
    }
}