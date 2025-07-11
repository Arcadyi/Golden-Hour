using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class QuestionMark : MonoBehaviour
{

    public Animator animator;
    public float timeSinceActivated;
    // on click, play the animation
    public UnityEvent onClick;
    public UnityEvent onClickTwice; // This will be invoked only once when clicked
    public UnityEvent onFirstThresholdReached;
    public UnityEvent onSecondThresholdReached;
    public UnityEvent onThirdThresholdReached;

    bool clickedOnce = false;

    public float firstThresholdSeconds = 5f;
    private bool isFirstThresholdReached = false;
    public float secondThresholdSeconds = 10f;
    private bool isSecondThresholdReached = false;
    public float thirdThresholdSeconds = 15f;
    private bool isThirdThresholdReached = false;
    
    public DialogueManager dialogueManager;
    void OnMouseDown()
    {
        if (animator)
        {
            animator.SetTrigger("disappear");
        }
        else
        {
            Debug.LogWarning("Animator is not assigned in QuestionMark script.");
        }

        // Start the coroutine to wait for the animation to end
        if (!clickedOnce)
        {
            clickedOnce = true;
            onClick.Invoke(); // Invoke the click event only once
        }
        else
        {
            StartCoroutine(WaitForAnimationToEnd());
            onClickTwice.Invoke(); // Invoke the click event only once
        }
        
    }

    public IEnumerator WaitForAnimationToEnd()
    {
        if (animator)
        {
            // Wait for the animation to finish
            yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        }
        // Destroy the GameObject after the animation ends
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (!dialogueManager.IsDialogueInLoop())
        {
            timeSinceActivated = 0;
            return;
        }
        timeSinceActivated += Time.deltaTime;

        if (timeSinceActivated >= firstThresholdSeconds && timeSinceActivated < secondThresholdSeconds)
        {
            if (!isFirstThresholdReached)
            {
                isFirstThresholdReached = true;
                // Trigger the first threshold event
                onFirstThresholdReached.Invoke();
                // Reset the timer after the first threshold is reached
                timeSinceActivated = 0f;
            }
        }
        else if (timeSinceActivated >= secondThresholdSeconds && timeSinceActivated < thirdThresholdSeconds)
        {
            if (!isSecondThresholdReached)
            {
                isSecondThresholdReached = true;
                // Trigger the second threshold event
                onSecondThresholdReached.Invoke();
                timeSinceActivated = 0f; // Reset the timer after the second threshold is reached
            }
        }
        else if (timeSinceActivated >= thirdThresholdSeconds)
        {
            if (!isThirdThresholdReached)
            {
                isThirdThresholdReached = true;
                // Trigger the third threshold event
                onThirdThresholdReached.Invoke();
                timeSinceActivated = 0f; // Reset the timer after the third threshold is reached
            }
        }
    }
}
