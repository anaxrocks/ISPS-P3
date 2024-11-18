using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonSelectionManager : MonoBehaviour
{
    public List<Button> buttons; // List of selectable buttons
    public Button startButton; // Reference to the Start button
    private Button currentSelectedButton; // Tracks the currently selected button

    void Start()
    {
        // Disable the Start button at the beginning
        startButton.interactable = false;
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
                startButton.interactable = true;
            }
        }
        else if (selectedObject != startButton.gameObject) // Exclude Start button from the check
        {
            if (currentSelectedButton != null)
            {
                // Reset the value of the previously selected button
                ResetButtonValue(currentSelectedButton);
                currentSelectedButton = null;

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

    public void StartDay()
    {
        SceneManager.LoadScene("SortingPackagesMain");
    }
}
