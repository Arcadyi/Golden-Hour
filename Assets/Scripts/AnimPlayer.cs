using UnityEngine;

public class AnimPlayer : MonoBehaviour
{
    public Sprite defaultSprite; // Default sprite to be displayed when the animation is not playing
    public CustomAnim customAnim; // Reference to the CustomAnim scriptable object
    public bool playOnAwake = false; // Flag to determine if the animation should play on awake
    public bool loop = false; // Flag to determine if the animation should loop

    private SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer component
    private bool isPlaying = false; // Track if the animation is currently playing
    private int currentFrame = 0; // Current frame of the animation
    private float timer = 0f; // Timer to track time between frames

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get the SpriteRenderer component attached to this GameObject
        if (spriteRenderer == null) // Check if the SpriteRenderer component is not found
        {
            Debug.LogError("SpriteRenderer component not found on this GameObject.");
        }
    }

    void Start()
    {
        if (playOnAwake) // Check if the animation should play on awake
        {
            PlayAnimation(); // Call the method to play the animation
        }
    }

    void Update()
    {
        if (isPlaying && customAnim && customAnim.sprites.Count > 0)
        {
            timer += Time.deltaTime; // Increment the timer by the time elapsed since the last frame

            if (timer >= customAnim.animationSpeed) // Check if it's time to move to the next frame
            {
                timer = 0f; // Reset the timer
                currentFrame++; // Move to the next frame

                if (currentFrame >= customAnim.sprites.Count) // Check if the animation has reached the end
                {
                    if (loop) // If looping is enabled, reset to the first frame
                    {
                        currentFrame = 0;
                    }
                    else // If not looping, stop the animation
                    {
                        StopAnimation();
                        return;
                    }
                }

                // Update the sprite to the current frame
                spriteRenderer.sprite = customAnim.sprites[currentFrame];
            }
        }
    }

    public void PlayAnimation()
    {
        if (customAnim != null && customAnim.sprites.Count > 0)
        {
            isPlaying = true; // Set the animation to playing
            currentFrame = 0; // Start from the first frame
            timer = 0f; // Reset the timer
            spriteRenderer.sprite = customAnim.sprites[currentFrame]; // Immediately show the first frame
        }
        else
        {
            Debug.LogError("CustomAnim reference is not set or contains no sprites.");
        }
    }

    public void StopAnimation()
    {
        isPlaying = false; // Stop the animation
        currentFrame = 0; // Reset the frame index
        timer = 0f; // Reset the timer

        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = defaultSprite; // Set the sprite to the default sprite
        }
    }
}
