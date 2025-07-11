using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Ink.Runtime;

public class DialogueManager : MonoBehaviour
{
    [Header("UI")]
    public GameObject dialogueBox;
    public TextMeshProUGUI dialogueText;
    public GameObject dialogueBoxContainer;
    public GameObject buttonContainer;
    public DialogueButton buttonPrefab;
    
    [Header("Typewriter")]
    public float typingSpeed = 0.05f;
    private Coroutine typingCoroutine;
    private string dialogue;

    [Header("Characters")]
    public List<Character> characters;
    public SpriteRenderer characterImageL;
    public SpriteRenderer characterImageR;
    private Character currentCharacter = null;

    [Header("Audio")]
    private AudioSource audioSource;

    [Header("Ink")]
    public TextAsset gameStory;
    private Story story;
    public TextAsset papersPleaseAcceptedDialogue;
    public TextAsset papersPleaseDeniedDialogue;

    public GameManager gameManager;

    public bool looping;

    public string debugEntryString;
    [ContextMenu("Skip to Dialogue")]
    void DoSomething()
    {
        GoToPath(debugEntryString);
    }

    public static DialogueManager Instance { get; private set; }

    void Awake()
    {
        // Singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);

        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        EndDialogue();
    }

    /// <summary>
    /// Hook this method up to your hidden Continue/Skip button's OnClick.
    /// </summary>
    public void OnDialogueClick()
    {
        if (typingCoroutine != null)
        {
            // Still typing: finish instantly
            StopCoroutine(typingCoroutine);
            dialogueText.text = dialogue;
            audioSource.Stop();
            typingCoroutine = null;
        }
        else
        {
            // Already finished typing: go to next line or choices
            ContinueStory();
        }
    }

    public void GoToPath(string pathName)
    {
        if (story == null)
        {
            Debug.LogError("Story is not set. Cannot go to branch.");
            return;
        }
        story.ChoosePathString(pathName);
    }

    // Public API to start a story
    public void SetStory(TextAsset inkAsset)
    {
        story = new Story(inkAsset.text);
        story.BindExternalFunction("call_event", (string e) => CallEvent(e));
        currentCharacter = null;  // reset
        ContinueStory();
    }

    public bool IsDialogueInLoop()
    {
        return (bool)story.variablesState["looping"];
    }

    public void CallEvent(string eventName)
    {
        if (eventName.Equals("second_scene", StringComparison.OrdinalIgnoreCase))
            gameManager.SwitchScene(0.3f,2);
        else if (eventName.Equals("show_mute_button", StringComparison.OrdinalIgnoreCase))
            gameManager.ShowMuteButton(true);
        else if (eventName.Equals("hide_dialoguebox", StringComparison.OrdinalIgnoreCase))
            EndDialogue();
        else if (eventName.Equals("option_3_1_glitched_entity", StringComparison.OrdinalIgnoreCase))
            gameManager.ShowCrabCreature();
        else if (eventName.Equals("show_question_mark_silhouette", StringComparison.OrdinalIgnoreCase))
            gameManager.ShowQuestionMark();
        else if (eventName.Equals("hide_question_mark", StringComparison.OrdinalIgnoreCase))
            gameManager.HideQuestionMark();
        else
            Debug.LogWarning($"Unknown event: {eventName}");
    }

    public void ContinueStory()
    {
        ClearButtons();

        if (story.canContinue)
        {
            // Restore dialogue UI, hide choices
            dialogueBoxContainer.SetActive(true);
            buttonContainer.SetActive(false);
            characterImageL.gameObject.SetActive(true);
            characterImageR.gameObject.SetActive(true);

            // Get next line + tags
            string text = story.Continue();
            var tags = story.currentTags;

            // Display text
            SetDialogue(text);

            // Process tags
            HandleTags(tags);
        }
        else if (story.currentChoices.Count > 0)
        {
            ShowChoices();
        }
        else
        {
            EndDialogue();
        }
    }

    void HandleTags(List<string> tags)
    {
        // Character tag
        foreach (var a in tags)
        {
            var c = characters.Find(ch => ch.characterName.Equals(a, StringComparison.OrdinalIgnoreCase));
            if (c != null)
            {
                currentCharacter = c;
                break;
            }
        }

        // Emotion tag
        string emotion = null;
        foreach (var tag in tags)
        {
            if (tag.StartsWith("emotion_", StringComparison.OrdinalIgnoreCase))
            {
                emotion = tag.Substring("emotion_".Length);
                break;
            }
        }

        if (currentCharacter)
            UpdatePortrait(currentCharacter, emotion);
    }

    void UpdatePortrait(Character character, string emotion)
    {
        Sprite face = character.defaultPortrait;
        if (!string.IsNullOrEmpty(emotion))
        {
            switch (emotion.ToLower())
            {
                case "happy":     face = character.happy;     break;
                case "sad":       face = character.sad;       break;
                case "angry":     face = character.angry;     break;
                case "surprised": face = character.surprised; break;
                case "thinking":  face = character.thinking;  break;
                case "neutral":   face = character.defaultPortrait; break;
                default:
                    Debug.LogWarning($"Unknown emotion tag: {emotion}");
                    break;
            }
        }

        audioSource.clip = character.talkingSound;
        audioSource.Play();

        bool isLeft = character.portraitSide == Character.PortraitSide.Left;
        var show = isLeft ? characterImageL : characterImageR;
        var hide = isLeft ? characterImageR : characterImageL;

        show.sprite = face;
        show.enabled = true;
        hide.enabled = false;
    }

    void SetDialogue(string line)
    {
        dialogue = line.Trim();
        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);
        typingCoroutine = StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        dialogueText.text = "";
        dialogueBox.SetActive(true);
        foreach (var ch in dialogue)
        {
            dialogueText.text += ch;
            yield return new WaitForSeconds(typingSpeed);
        }
        audioSource.Stop();
        typingCoroutine = null;  // mark as finished
    }

    void ShowChoices()
    {
        dialogueBoxContainer.SetActive(false);
        buttonContainer.SetActive(true);

        for (int i = 0; i < story.currentChoices.Count; i++)
        {
            var choice = story.currentChoices[i];
            var btn = Instantiate(buttonPrefab, buttonContainer.transform);
            btn.SetButtonText(choice.text);
            int idx = i;
            btn.onClickEvent.AddListener(() =>
            {
                story.ChooseChoiceIndex(idx);
                ContinueStory();
            });
        }
    }

    void EndDialogue()
    {
        Debug.Log("End of story.");
        dialogueBox.SetActive(false);
        dialogueBoxContainer.SetActive(false);
        buttonContainer.SetActive(false);
        characterImageL.gameObject.SetActive(false);
        characterImageR.gameObject.SetActive(false);
        audioSource.Stop();
    }

    public void SetAcceptedArst() => SetStory(papersPleaseAcceptedDialogue);
    public void SetDeniedArst()   => SetStory(papersPleaseDeniedDialogue);

    public void EnableDialogue()
    {
        dialogueBox.SetActive(true);
        dialogueBoxContainer.SetActive(true);
        buttonContainer.SetActive(false);
        characterImageL.enabled = true;
        characterImageR.enabled = true;
    }

    public void ClearButtons()
    {
        foreach (Transform child in buttonContainer.transform)
            Destroy(child.gameObject);
    }
}
