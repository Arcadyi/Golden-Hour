using System.Collections;
using UnityEngine;

public class JimboManager : Minigame
{
    private enum JimboState
    {
        Idle,
        Delayed,
        Entering,
        LookingAround,
        SayingTheLine,
        Exiting
    }

    [Header("Positions")]
    public Vector2 startLocation;   // Initial position of the sprite
    public Vector2 leavingLocation;  // Starting position of the sprite
    public Vector2 enteringLocation; // Ending position of the sprite

    [Header("Settings")]
    public float speed = 1.0f;             // Movement speed
    [SerializeField] private float triggerDelay = 1.0f; // Delay before Jimbo starts moving

    [Header("References")]
    public AnimPlayer theLine;       // Reference to the line animation
    public AnimPlayer jimboAnimPlayer; // Reference to Jimbo's walk animation

    private SpriteRenderer spriteRenderer;
    private JimboState currentState = JimboState.Idle;
    private float stateTimer = 0f;

    public override void OnAwake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
            Debug.LogError("SpriteRenderer not found!");

        if (theLine == null || jimboAnimPlayer == null)
            Debug.LogError("AnimPlayer references are not set!");
    }

    public override void OnUpdate()
    {
        switch (currentState)
        {
            case JimboState.Idle:
                // Do nothing until TriggerJimbo is called
                break;

            case JimboState.Delayed:
                HandleDelay();
                break;

            case JimboState.Entering:
                HandleMovement(enteringLocation, JimboState.LookingAround);
                break;

            case JimboState.LookingAround:
                HandleLookAround();
                break;

            case JimboState.SayingTheLine:
                HandleSayingTheLine();
                break;

            case JimboState.Exiting:
                HandleMovement(leavingLocation, JimboState.Idle);
                OnCompleted?.Invoke(); // Invoke the OnCompleted event if assigned
                break;
        }
    }

    public override void Trigger()
    {
        if (currentState == JimboState.Idle)
        {
            OnTriggered?.Invoke(); // Invoke the OnTriggered event if assigned
            stateTimer = 0f; 
            currentState = JimboState.Delayed;
        }
    }

    private void HandleDelay()
    {
        stateTimer += Time.deltaTime;
        if (stateTimer >= triggerDelay)
        {
            spriteRenderer.flipX = false; 
            jimboAnimPlayer.PlayAnimation();
            currentState = JimboState.Entering;
            // no need to reset timer here since we don't use it in Entering
        }
    }

    private void HandleMovement(Vector2 target, JimboState nextState)
    {
        Vector2 currentPos = transform.position;
        transform.position = Vector2.MoveTowards(currentPos, target, speed * Time.deltaTime);

        if (Vector2.Distance(currentPos, target) < 0.01f)
        {
            transform.position = target;
            jimboAnimPlayer.StopAnimation();

            // Reset the timer if transitioning to LookingAround
            if (nextState == JimboState.LookingAround)
            {
                stateTimer = 0f;
            }

            // If Jimbo is exiting and transitioning to Idle, reset his position
            if (nextState == JimboState.Idle)
            {
                spriteRenderer.flipX = false; // Reset flip for next time
                transform.position = startLocation; // Reset position to startLocation
            }

            currentState = nextState;
        }
    }

    private void HandleLookAround()
    {
        stateTimer += Time.deltaTime;

        if (stateTimer < 1f)
        {
            spriteRenderer.flipX = true;   // look left
        }
        else if (stateTimer < 2f)
        {
            spriteRenderer.flipX = false;  // look right
        }
        else if (stateTimer < 3f)
        {
            spriteRenderer.flipX = true;   // look left again
        }
        else
        {
            // finished looking around
            stateTimer = 0f;
            currentState = JimboState.SayingTheLine;
        }
    }

    private void HandleSayingTheLine()
    {
        if (stateTimer == 0f)
        {
            theLine.gameObject.SetActive(true);
            theLine.PlayAnimation();
        }

        stateTimer += Time.deltaTime;

        if (stateTimer >= 4f) // duration of line animation
        {
            theLine.StopAnimation();
            theLine.gameObject.SetActive(false);

            stateTimer = 0f;
            jimboAnimPlayer.PlayAnimation(); // prepare for exit walk
            currentState = JimboState.Exiting;
        }
    }
}
