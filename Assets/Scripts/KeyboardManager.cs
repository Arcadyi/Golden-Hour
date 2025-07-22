using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

// Import the TextMeshPro namespace for text rendering

public enum EffectState {
    Idle,
    Aaa,
    Wee,
    Jimbo,
    Arstotzka,
}
public class KeyboardManager : MonoBehaviour
{
    public EffectState effectState = EffectState.Idle; // Enum to define different effect states
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public string inputString = ""; // String to hold the input from the keyboard
    public float inputResetTime = 3.0f; // Time in seconds to reset the input string if no key is pressed
    public float timeSinceLastKeyPress; // Time since the last key press
    public bool keyboardEnabled = true; // Flag to enable or disable keyboard input

    public TextMeshProUGUI inputText; // Reference to the TextMeshProUGUI component for displaying text

    [FormerlySerializedAs("effect_AAAAA")] public Effect_AAAAA effectAaaaa; // Reference to the Effect_AAAAA script for triggering effects
    [FormerlySerializedAs("effect_Wee")] public Effect_Wee effectWee; // Reference to the Effect_Wee script for triggering effects

    public JimboManager jimboManager; // Reference to the JimboManager script for managing game state
    [FormerlySerializedAs("effect_Arstotzka")] public Effect_Arstotzka effectArstotzka; // Reference to the Effect_Arstotzka script for triggering effects

    // Update is called once per frame
    void Update()
    {
        timeSinceLastKeyPress += Time.deltaTime; // Increment the time since the last key press
        // Check if the input string is not empty and reset it after a specified time
        if (timeSinceLastKeyPress >= inputResetTime)
        {
            ResetInputString(); // Call the method to reset the input string
        }
        CheckInputString(); // Call the method to check the input string

        // Update the displayed text with the current input string
        inputText.text = inputString; // Update the TextMeshProUGUI component with the current input string
    }
    // Method to reset the input string after a specified time
    public void ResetInputString()
    {
        inputString = ""; // Clear the input string
    }

    public void KeyStroke(string key)
    {
        if (!keyboardEnabled) return; // If keyboard input is disabled, return
        timeSinceLastKeyPress = 0.0f; // Reset the time since the last key press
        inputString += key; // Append the pressed key to the input string
    }

    public void CheckInputString(){
        if (inputString.Length <= 0) // Check if the input string is not empty
        {
            return; // If empty, return
        }
        if (effectState != EffectState.Idle) // Check if the effect state is not None
        {
            return; // If not None, return
        }
        // Check if the input string includes a specific command
        if (inputString.Contains("exit")) // Check if the input string contains the command "exit"
        {
            Debug.Log("Exiting the game..."); // Log the exit message
            Application.Quit(); // Quit the application
        } else if (inputString.Contains("aaaaa")){
            Debug.Log("GOING CRAZY");
            effectAaaaa.Trigger(); // Call the method to play the effect
            ResetInputString(); // Clear the input string
        } else if (inputString.Contains("weeee") || inputString.Contains("woooo")) {
            Debug.Log("GOING WEEEEE");
            effectWee.Trigger(); // Call the method to play the effect
            ResetInputString(); // Clear the input string
        } else if (inputString.Contains("card") || inputString.Contains("ace")) {
            Debug.Log("CARD TRIGGERED");
            jimboManager.Trigger(); // Call the method to trigger the Jimbo effect
        } else if (inputString.Contains("arst")) {
            Debug.Log("PASSPORT TRIGGERED");
            effectArstotzka.Trigger(); // Call the method to trigger the Arstotzka effect
        }
    }

    public void ChangeEffectState(string newState)
    {
        switch (newState)
        {
            case "idle":
                effectState = EffectState.Idle; // Set the effect state to Idle
                break;
            case "aaaaa":
                effectState = EffectState.Aaa; // Set the effect state to AAA
                break;
            case "wee":
                effectState = EffectState.Wee; // Set the effect state to WEE
                break;
            case "jimbo":
                effectState = EffectState.Jimbo; // Set the effect state to Jimbo
                break;
            case "arstotzka":
                effectState = EffectState.Arstotzka; // Set the effect state to Arstotzka
                break;
            default:
                Debug.LogError("Invalid effect state: " + newState); // Log an error for invalid state
                break;
        }
    }
}
