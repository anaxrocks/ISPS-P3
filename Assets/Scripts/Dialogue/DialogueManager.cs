using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    public Image characterIcon;
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI dialogueArea;
    public GameObject dialogueUI;
    public GameObject startButton;

    private Queue<DialogueLine> lines;

    public bool isDialogueActive = false;

    public float typingSpeed = 0.01f;

    private void Start()
    {
        if (Instance == null)
            Instance = this;

        lines = new Queue<DialogueLine>();
        dialogueUI.SetActive(false); // Ensure the dialogue UI starts hidden.
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Start Dialogue!");
        isDialogueActive = true;

        dialogueUI.SetActive(true);

        lines.Clear();

        foreach (DialogueLine dialogueLine in dialogue.dialogueLines)
        {
            lines.Enqueue(dialogueLine);
        }

        DisplayNextDialogueLine();
    }

    public void DisplayNextDialogueLine()
    {
        Debug.Log("Display next dialogue line");
        if (lines.Count == 0)
        {
            EndDialogue();
            return;
        }

        DialogueLine currentLine = lines.Dequeue();

        characterIcon.sprite = currentLine.character.icon;
        characterName.text = currentLine.character.name;

        StopAllCoroutines();

        StartCoroutine(TypeSentence(currentLine));
    }

    IEnumerator TypeSentence(DialogueLine dialogueLine)
    {
        dialogueArea.text = "";
        foreach (char letter in dialogueLine.line.ToCharArray())
        {
            dialogueArea.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    void EndDialogue()
    {
        isDialogueActive = false;
        dialogueUI.SetActive(false);
        Debug.Log("End dialogue");

        if (SceneManager.GetActiveScene().name == "IntroNarrative") {
            SceneManager.LoadScene("Hub");
        }

        if((SceneManager.GetActiveScene().name == "SortingPackagesMain" || SceneManager.GetActiveScene().name == "DeliveryGame") && Tutorial.tutorial == true)
        {
            startButton.SetActive(true);
        }
    }
}