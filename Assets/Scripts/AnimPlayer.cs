using UnityEngine;

public class AnimPlayer : MonoBehaviour
{
    public Sprite defaultSprite; // Default sprite to be displayed when the animation is not playing
    public CustomAnim customAnim; // Reference to the CustomAnim scriptable object
    public bool playOnAwake = false; // Flag to determine if the animation should play on awake
    public bool loop = false; // Flag to determine if the animation should loop

    private SpriteRenderer _spriteRenderer; // Reference to the SpriteRenderer component
    private bool _isPlaying = false; // Track if the animation is currently playing
    private int _currentFrame = 0; // Current frame of the animation
    private float _timer = 0f; // Timer to track time between frames

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>(); // Get the SpriteRenderer component attached to this GameObject
        if (_spriteRenderer == null) // Check if the SpriteRenderer component is not found
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
        if (_isPlaying && customAnim && customAnim.sprites.Count > 0)
        {
            _timer += Time.deltaTime; // Increment the timer by the time elapsed since the last frame

            if (_timer >= customAnim.animationSpeed) // Check if it's time to move to the next frame
            {
                _timer = 0f; // Reset the timer
                _currentFrame++; // Move to the next frame

                if (_currentFrame >= customAnim.sprites.Count) // Check if the animation has reached the end
                {
                    if (loop) // If looping is enabled, reset to the first frame
                    {
                        _currentFrame = 0;
                    }
                    else // If not looping, stop the animation
                    {
                        StopAnimation();
                        return;
                    }
                }

                // Update the sprite to the current frame
                _spriteRenderer.sprite = customAnim.sprites[_currentFrame];
            }
        }
    }

    public void PlayAnimation()
    {
        if (customAnim != null && customAnim.sprites.Count > 0)
        {
            _isPlaying = true; // Set the animation to playing
            _currentFrame = 0; // Start from the first frame
            _timer = 0f; // Reset the timer
            _spriteRenderer.sprite = customAnim.sprites[_currentFrame]; // Immediately show the first frame
        }
        else
        {
            Debug.LogError("CustomAnim reference is not set or contains no sprites.");
        }
    }

    public void StopAnimation()
    {
        _isPlaying = false; // Stop the animation
        _currentFrame = 0; // Reset the frame index
        _timer = 0f; // Reset the timer

        if (_spriteRenderer != null)
        {
            _spriteRenderer.sprite = defaultSprite; // Set the sprite to the default sprite
        }
    }
}
