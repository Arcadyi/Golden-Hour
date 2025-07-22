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
    private Coroutine _typingCoroutine;
    private string _dialogue;

    [Header("Characters")]
    public List<Character> characters;
    public SpriteRenderer characterImageL;
    public SpriteRenderer characterImageR;
    private Character _currentCharacter;

    [Header("Audio")]
    private AudioSource _audioSource;

    [Header("Ink")]
    public TextAsset gameStory;
    private Story _story;
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

        _audioSource = GetComponent<AudioSource>();
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
        if (_typingCoroutine != null)
        {
            // Still typing: finish instantly
            StopCoroutine(_typingCoroutine);
            dialogueText.text = _dialogue;
            _audioSource.Stop();
            _typingCoroutine = null;
        }
        else
        {
            // Already finished typing: go to next line or choices
            ContinueStory();
        }
    }

    public void GoToPath(string pathName)
    {
        if (_story == null)
        {
            Debug.LogError("Story is not set. Cannot go to branch.");
            return;
        }
        _story.ChoosePathString(pathName);
    }

    // Public API to start a story
    public void SetStory(TextAsset inkAsset)
    {
        _story = new Story(inkAsset.text);
        _story.BindExternalFunction("call_event", (string e) => CallEvent(e));
        _currentCharacter = null;  // reset
        ContinueStory();
    }

    public bool IsDialogueInLoop()
    {
        return (bool)_story.variablesState["looping"];
    }

    public void CallEvent(string eventName)
    {
        if (eventName.Equals("second_scene", StringComparison.OrdinalIgnoreCase))
            gameManager.SwitchScene(2.0f,2);
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

        if (_story.canContinue)
        {
            // Restore dialogue UI, hide choices
            dialogueBoxContainer.SetActive(true);
            buttonContainer.SetActive(false);
            characterImageL.gameObject.SetActive(true);
            characterImageR.gameObject.SetActive(true);

            // Get next line + tags
            string text = _story.Continue();
            var tags = _story.currentTags;

            // Display text
            SetDialogue(text);

            // Process tags
            HandleTags(tags);
        }
        else if (_story.currentChoices.Count > 0)
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
                _currentCharacter = c;
                break;
            }
        }

        // Emotion tag
        string emotion = null;
        foreach (var currentTag in tags)
        {
            if (currentTag.StartsWith("emotion_", StringComparison.OrdinalIgnoreCase))
            {
                emotion = currentTag.Substring("emotion_".Length);
                break;
            }
        }

        if (_currentCharacter)
            UpdatePortrait(_currentCharacter, emotion);
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
                case "shocked": face = character.shocked; break;
                case "thinking":  face = character.thinking;  break;
                case "neutral":   face = character.defaultPortrait; break;
                default:
                    Debug.LogWarning($"Unknown emotion tag: {emotion}");
                    break;
            }
        }

        _audioSource.clip = character.talkingSound;
        _audioSource.Play();

        bool isLeft = character.portraitSide == Character.PortraitSide.Left;
        var show = isLeft ? characterImageL : characterImageR;
        var hide = isLeft ? characterImageR : characterImageL;

        show.sprite = face;
        show.enabled = true;
        hide.enabled = false;
    }

    void SetDialogue(string line)
    {
        _dialogue = line.Trim();
        if (_typingCoroutine != null)
            StopCoroutine(_typingCoroutine);
        _typingCoroutine = StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        dialogueText.text = "";
        dialogueBox.SetActive(true);
        foreach (var ch in _dialogue)
        {
            dialogueText.text += ch;
            yield return new WaitForSeconds(typingSpeed);
        }
        _audioSource.Stop();
        _typingCoroutine = null;  // mark as finished
    }

    void ShowChoices()
    {
        dialogueBoxContainer.SetActive(false);
        buttonContainer.SetActive(true);

        for (int i = 0; i < _story.currentChoices.Count; i++)
        {
            var choice = _story.currentChoices[i];
            var btn = Instantiate(buttonPrefab, buttonContainer.transform);
            btn.SetButtonText(choice.text);
            int idx = i;
            btn.onClickEvent.AddListener(() =>
            {
                _story.ChooseChoiceIndex(idx);
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
        _audioSource.Stop();
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

    public void DisableDialogue()
    {
        dialogueBox.SetActive(false);
        dialogueBoxContainer.SetActive(false);
        buttonContainer.SetActive(false);
        characterImageL.enabled = false;
        characterImageR.enabled = false;
    }

    public void ClearButtons()
    {
        foreach (Transform child in buttonContainer.transform)
            Destroy(child.gameObject);
    }
}
