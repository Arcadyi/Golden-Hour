using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static readonly int GlitchStrength = Shader.PropertyToID("_Glitch_Strength");
    public static GameManager Instance { get; private set; }
    public MainMenuManager mainMenuManager;
    public DialogueManager dialogueManager;

    public GameObject mainMenuObjects;
    public GameObject firstSceneObjects;

    public GameObject secondSceneObjects;
    public GameObject muteBtn;

    public GameObject crabCreature;
    public GameObject questionMark;

    public GameObject fancyLoadScreen;
    public GameObject fancyLoadScreenBlocker;

    public AudioSource loopingOst;
    public AudioSource waves;

    public AudioSource glitch;
    
    public Material fsShaderMaterial; // Reference to the shader material
    
    public float transitionSpeed = 0.5f; // Speed of the scene transition in seconds
    
    public Effect_Jitter effectJitter;
    
        /* -------------  NEW  ------------- */
    [Header("Global Glitch Flicker")]
    public bool enableGlitchFlicker = false;   // turn on/off in Inspector or via script
    public Vector2 flickerIntervalRange = new Vector2(0.1f, 1.5f); // min / max seconds between flips
    [Tooltip("How long the glitch stays ON each flicker")]
    public Vector2 glitchDurationRange = new Vector2(0.02f, 0.08f);
    [Tooltip("How long the glitch stays OFF between flickers")]
    public Vector2 pauseDurationRange  = new Vector2(0.3f, 1.2f);
    private Coroutine glitchFlickerRoutine;

    /* -------------  END NEW  ------------- */

    void OnEnable()  { if (enableGlitchFlicker) StartGlitchFlicker(); }
    void OnDisable() { StopGlitchFlicker(); }

    /* -------------  NEW METHODS ------------- */
    public void SetGlitchFlicker(bool active)
    {
        enableGlitchFlicker = active;
        if (active) StartGlitchFlicker();
        else        StopGlitchFlicker();
    }

    private void StartGlitchFlicker()
    {
        if (glitchFlickerRoutine == null)
            glitchFlickerRoutine = StartCoroutine(GlitchFlickerLoop());
    }

    private void StopGlitchFlicker()
    {
        if (glitchFlickerRoutine != null)
        {
            StopCoroutine(glitchFlickerRoutine);
            glitchFlickerRoutine = null;
        }
        // restore clean state
        if (fsShaderMaterial) fsShaderMaterial.SetFloat(GlitchStrength, 0f);
        if (effectJitter)     effectJitter.jitterStrength = 0f;
        if (loopingOst)       loopingOst.volume = 1f;
    }

    private IEnumerator GlitchFlickerLoop()
    {
        while (enableGlitchFlicker)
        {
            /* ---- GLITCH ON ---- */
            float glitchTime = Random.Range(glitchDurationRange.x, glitchDurationRange.y);

            if (fsShaderMaterial)
                fsShaderMaterial.SetFloat(GlitchStrength, 1f);
            if (effectJitter)
                effectJitter.jitterStrength = 1f;
            if (loopingOst)
                loopingOst.volume = 0f;
            if (glitch)
                glitch.volume = 0.25f;

            yield return new WaitForSecondsRealtime(glitchTime);

            /* ---- GLITCH OFF ---- */
            float pauseTime = Random.Range(pauseDurationRange.x, pauseDurationRange.y);

            if (fsShaderMaterial)
                fsShaderMaterial.SetFloat(GlitchStrength, 0f);
            if (effectJitter)
                effectJitter.jitterStrength = 0f;
            if (loopingOst)
                loopingOst.volume = 1f;
            if (glitch) glitch.volume = 0f;

            yield return new WaitForSecondsRealtime(pauseTime);
        }
    }

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
            //float strengthStart = 0f;
            //float strengthEnd = 1f;
            
            float progress = 0f;
            while (progress < 1f)
            {
                progress += Time.deltaTime / transitionSpeed; // Increment progress based on time and speed
                //float strength = Mathf.Lerp(strengthStart, strengthEnd, progress);
                
                
                fsShaderMaterial.SetFloat(GlitchStrength, 1f);
                effectJitter.jitterStrength = 1;
                loopingOst.volume = 0;
                glitch.volume = 1;
                
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
            //float strengthStart = 1;
            //float strengthEnd = 0f;
            
            float progress = 0f;
            while (progress < 1f)
            {
                progress += Time.deltaTime / transitionSpeed; // Increment progress based on time and speed
                //float strength = Mathf.Lerp(strengthStart, strengthEnd, progress);
                
                fsShaderMaterial.SetFloat(GlitchStrength, 0f);
                effectJitter.jitterStrength = 0;
                loopingOst.volume = 1;
                glitch.volume = 0;
                
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
        dialogueManager.DisableDialogue();
        // Play the transition animation
        yield return StartCoroutine(PlayTransitionAnimation(delay/3f));
        // Wait until the transition animation is done
        yield return new WaitForSeconds(delay/3);
        mainMenuObjects.SetActive(scene == 0);
        firstSceneObjects.SetActive(scene == 1);
        secondSceneObjects.SetActive(scene == 2);
        // Return the shader to its default state
        yield return StartCoroutine(ReturnTransitionAnimationDefault(delay/3f));
        dialogueManager.EnableDialogue();

        if (scene > 1)
        {
            SetGlitchFlicker(true);
        }
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
