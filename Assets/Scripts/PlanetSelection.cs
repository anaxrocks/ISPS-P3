using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlanetSelection : MonoBehaviour
{
    public List<Button> buttons; // List of buttons in the scene
    private Button currentSelectedButton; // Tracks the currently selected button

    // Update is called once per frame
    void Update()
    {
        // Check the currently selected object in the EventSystem
        GameObject selectedObject = EventSystem.current.currentSelectedGameObject;

        // If it's a button in our list
        if (selectedObject != null && buttons.Contains(selectedObject.GetComponent<Button>()))
        {
            Button selectedButton = selectedObject.GetComponent<Button>();

            // Check if the selection has changed
            if (currentSelectedButton != selectedButton)
            {
                SetButtonValue(selectedButton);

                if (currentSelectedButton != null)
                {
                    ResetButtonValue(currentSelectedButton);
                }
                currentSelectedButton = selectedButton;
                print(currentSelectedButton);
            }
            print(currentSelectedButton);
        }
        else if (currentSelectedButton != null) // If no button is selected
        {
            // Reset the value of the previously selected button
            ResetButtonValue(currentSelectedButton);
            currentSelectedButton = null;
            print(currentSelectedButton);
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
}
