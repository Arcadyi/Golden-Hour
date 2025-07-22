using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Events; // Importing TextMeshPro namespace for text rendering

public class MainMenuManager : MonoBehaviour
{
    public TextMeshProUGUI introText; // Reference to the TextMeshProUGUI component for displaying text
    public Canvas introTextCanvas; // Reference to the CanvasGroup for controlling the intro text visibility
    public float introTextSpeed = 0.1f; // Speed of the text typing effect
    public MenuSpriteText menuSpriteText; // Reference to the MenuSpriteText component for sprite animation
    public UnityEvent onStartGame; // UnityEvent to trigger when the game starts
    public GameManager gameManager; // Reference to the GameManager for managing game state
    public DialogueManager dialogueManager; // Reference to the DialogueManager for managing dialogues
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame

    public void StartIntro()
    {
        // Start a coroutine to handle the sequence of coroutines
        StartCoroutine(StartIntroSequence());
    }

    private IEnumerator StartIntroSequence()
    {
        // Wait for the TypeText coroutine to complete
        yield return StartCoroutine(TypeText("<color=#ebac4d>CD</color><color=#ece6df>\\\\\\</color>"));
        yield return StartCoroutine(AddText("<color=#ebac4d>CD</color> <color=#ece6df>C:\\\\\\golden_hour</color>", introTextSpeed));
        yield return StartCoroutine(AddText("<color=#ebac4d>dir</color>", introTextSpeed));
        // Wait for the AddText coroutine to complete
        yield return StartCoroutine(AddText("\n<color=#c68d80>27.04.2025 3:01 5.84</color><color=#ece6df>MB golden_hour.exe</color>", 0.0f));
        yield return StartCoroutine(AddText("<color=#c68d80>27.04.2025 3:01 218.3</color><color=#ece6df>MB data.dat</color>", 0.0f));
        yield return StartCoroutine(AddText("<color=#c68d80>27.04.2025 3:01 32.2</color><color=#ece6df>KB config.cfg</color>", 0.0f));
        yield return StartCoroutine(AddText("<color=#c68d80>27.04.2025 3:01 59.4</color><color=#ece6df>KB readme.txt</color>", 0.0f));
        yield return StartCoroutine(AddText("<color=#c68d80>27.04.2025 3:01 136.8</color><color=#ece6df>GB vo.dat</color>", 0.0f));

        yield return StartCoroutine(AddText("\n<color=#ebac4d>cmd</color> <color=#ece6df>C:\\\\\\golden_hour\\\\\\golden_hour.exe</color>", introTextSpeed));
        yield return StartCoroutine(AddText("<color=#ece6df>RUNNING</color>", 0.0f));
        yield return StartCoroutine(AddText("<color=#ece6df>RUNNING</color>", 0.0f));
        yield return StartCoroutine(AddText("<color=#ece6df>RUNNING</color>", 0.0f));
        yield return StartCoroutine(AddText("<color=#ece6df>RUNNING</color>", 0.0f));
        // destroy the intro text canvas after a delay
        yield return new WaitForSeconds(0.5f); // Wait for 1 second before destroying the canvas
        introTextCanvas.gameObject.SetActive(false); // Deactivate the intro text canvas
    }

    // coroutine to type out the text letter by letter
    public IEnumerator TypeText(string text)
    {
        introText.text = ""; // Clear the text field
        bool isTag = false; // Track if we're inside a rich text tag
        foreach (char letter in text)
        {
            if (letter == '<') isTag = true; // Start of a rich text tag
            if (letter == '>') isTag = false; // End of a rich text tag

            introText.text += letter; // Append each letter to the text field
            if (!isTag) // Only wait if not inside a rich text tag
            {
                yield return new WaitForSeconds(introTextSpeed); // Wait for the specified speed
            }
        }
    }

    // coroutine to add text letter by letter
    public IEnumerator AddText(string text, float speed)
    {
        introText.text += "\n"; // Add a new line to the text field
        bool isTag = false; // Track if we're inside a rich text tag
        foreach (char letter in text)
        {
            if (letter == '<') isTag = true; // Start of a rich text tag
            if (letter == '>') isTag = false; // End of a rich text tag

            introText.text += letter; // Append each letter to the text field
            if (!isTag) // Only wait if not inside a rich text tag
            {
                yield return new WaitForSeconds(speed); // Wait for the specified speed
            }
        }
    }

    public void StartGame()
    {
        gameManager.SwitchScene(3f,1, true); // Activate the first scene objects
        StartCoroutine(EnableDialogueAfterDelay(3f)); // Start the coroutine to enable dialogue after a delay
    }
    
    private IEnumerator EnableDialogueAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for the specified delay
        dialogueManager.EnableDialogue(); // Enable the dialogue manager
        dialogueManager.SetStory(dialogueManager.gameStory); // Set the story for the dialogue manager
    }

    public void ExitGame()
    {
        // Logic to exit the game goes here
        Debug.Log("Exiting Game!"); // Placeholder for exit logic
        StartCoroutine(ExitCoroutine()); // Start the exit coroutine
    }

    public void Settings()
    {
        // Logic to open settings menu goes here
        Debug.Log("Settings Menu Opened!"); // Placeholder for settings menu logic
    }

    public void Credits()
    {
        // Logic to open credits menu goes here
        Debug.Log("Credits Menu Opened!"); // Placeholder for credits menu logic
    }

    // exit coroutine
    public IEnumerator ExitCoroutine()
    {
        // Logic to handle exit animation or transition goes here
        yield return new WaitForSeconds(0.5f); // Placeholder for exit animation duration
        Application.Quit(); // Quit the application
    }
}
