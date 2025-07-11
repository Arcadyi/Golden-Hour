using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public MainMenuManager mainMenuManager;

    public GameObject mainMenuObjects;
    public GameObject firstSceneObjects;

    public GameObject secondSceneObjects;
    public GameObject muteBtn;

    public GameObject crabCreature;
    public GameObject questionMark;

    public GameObject fancyLoadScreen;
    public GameObject fancyLoadScreenBlocker;
    
    public Material fsShaderMaterial; // Reference to the shader material
    
    public float transitionSpeed = 0.5f; // Speed of the scene transition in seconds

    // Awake is called when the script instance is being loaded
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Make this object persistent
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Initialize the game manager and start the intro sequence
        if (mainMenuManager != null)
        {
            mainMenuManager.StartIntro(); // Start the intro sequence in the main menu manager
        }
        else
        {
            Debug.LogError("MainMenuManager reference is not set in GameManager.");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SwitchScene(float delay, int sceneIndex, bool useFancy = false)
    {
        if  (useFancy)
            StartCoroutine(SceneTransitionFancy(delay, sceneIndex));
        else
        {
            StartCoroutine(SceneTransition(delay, sceneIndex));
        }
    }

    public void ShowMuteButton(bool show)
    {
        if (muteBtn)
        {
            muteBtn.SetActive(show);
        }
        else
        {
            Debug.LogError("Mute button reference is not set in GameManager.");
        }
    }

    public void ShowCrabCreature()
    {
        if (crabCreature)
        {
            crabCreature.SetActive(true);
        }
        else
        {
            Debug.LogError("Crab creature reference is not set in GameManager.");
        }
    }
    public void ShowQuestionMark()
    {
        if (questionMark != null)
        {
            questionMark.SetActive(true);
        }
        else
        {
            Debug.LogError("Question mark reference is not set in GameManager.");
        }
    }
    public void HideQuestionMark()
    {
        if (questionMark)
        {
            questionMark.SetActive(false);
        }
        else
        {
            Debug.LogError("Question mark reference is not set in GameManager.");
        }
    }
    
    public IEnumerator PlayTransitionAnimation(float delay)
    {
        yield return new WaitForSeconds(delay);
        
        if (fsShaderMaterial)
        {
            float strengthStart = 0f;
            float strengthEnd = 1f;
            
            float progress = 0f;
            while (progress < 1f)
            {
                progress += Time.deltaTime / transitionSpeed; // Increment progress based on time and speed
                float strength = Mathf.Lerp(strengthStart, strengthEnd, progress);
                
                fsShaderMaterial.SetFloat("_Glitch_Strength", strength);
                
                yield return null; // Wait for the next frame
            }
        }
        else
        {
            Debug.LogError("FS Shader Material reference is not set in GameManager.");
        }
    }
    
    public IEnumerator ReturnTransitionAnimationDefault(float delay)
    {
        yield return new WaitForSeconds(delay);
        
        if (fsShaderMaterial)
        {
            float strengthStart = 1;
            float strengthEnd = 0f;
            
            float progress = 0f;
            while (progress < 1f)
            {
                progress += Time.deltaTime / transitionSpeed; // Increment progress based on time and speed
                float strength = Mathf.Lerp(strengthStart, strengthEnd, progress);
                
                fsShaderMaterial.SetFloat("_Glitch_Strength", strength);
                
                yield return null; // Wait for the next frame
            }
        }
        else
        {
            Debug.LogError("FS Shader Material reference is not set in GameManager.");
        }
    }
    
    public IEnumerator SceneTransition(float delay, int scene)
    {
        // Play the transition animation
        yield return StartCoroutine(PlayTransitionAnimation(delay/3f));
        // Wait until the transition animation is done
        yield return new WaitForSeconds(delay/3);
        // Return the shader to its default state
        yield return StartCoroutine(ReturnTransitionAnimationDefault(delay/3f));
        mainMenuObjects.SetActive(scene == 0);
        firstSceneObjects.SetActive(scene == 1);
        secondSceneObjects.SetActive(scene == 2);
    }

    public IEnumerator SceneTransitionFancy(float delay, int scene)
    {
        fancyLoadScreenBlocker.SetActive(true);
        fancyLoadScreen.SetActive(true);
        mainMenuObjects.SetActive(scene == 0);
        firstSceneObjects.SetActive(scene == 1);
        secondSceneObjects.SetActive(scene == 2);
        yield return new WaitForSeconds(delay);
        fancyLoadScreen.SetActive(false);
        fancyLoadScreenBlocker.SetActive(false);
    }
}
