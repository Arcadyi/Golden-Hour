using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class ClickableButton : MonoBehaviour
{
    public Sprite normalSprite; // Normal sprite for the button
    public Sprite hoverSprite; // Sprite for the button when hovered over
    public Sprite clickSprite; // Sprite for the button when clicked
    public Sprite heldSprite; // Sprite for the button when held down
    public List<Sprite> clickSprites; // List of sprites for the button

    private SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer component
    public PolygonCollider2D polygonCollider2D; // Reference to the PolygonCollider2D component

    public bool isPlaying; // Track if the click animation is currently playing

    private AudioSource audioSource; // Reference to the AudioSource component

    public UnityEvent onClick; // UnityEvent to trigger when the button is clicked
    public UnityEvent onHover; // UnityEvent to trigger when the mouse is over the button
    public UnityEvent onExit; // UnityEvent to trigger when the mouse exits the button

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get the SpriteRenderer component attached to this GameObject
        spriteRenderer.sprite = normalSprite; // Set the initial sprite to the normal sprite
        polygonCollider2D = GetComponent<PolygonCollider2D>(); // Get the PolygonCollider2D component attached to this GameObject
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component attached to this GameObject
    }

    // Method to handle mouse over event
    private void OnMouseOver()
    {
        onHover?.Invoke(); // Invoke the onHover event if assigned
        if (!isPlaying) // Only change to hover sprite if not held
        {
            spriteRenderer.sprite = hoverSprite;
        }
    }

    // Method to handle mouse exit event
    private void OnMouseExit()
    {
        onExit?.Invoke(); // Invoke the onExit event if assigned
        if (!isPlaying) // Only change to normal sprite if not held
        {
            spriteRenderer.sprite = normalSprite;
        }
    }

    // Method to handle mouse down event
    private void OnMouseDown()
    {
        onClick?.Invoke(); // Invoke the onClick event if assigned
        if (isPlaying) return; // If the animation is already playing, exit the method
        spriteRenderer.sprite = heldSprite; // Change to the held sprite
        PlayClickAnimation(); // Play the click animation
    }

    // Method to handle mouse up event
    private void OnMouseUp()
    {
        if (isPlaying) return; // If the animation is already playing, exit the method
        spriteRenderer.sprite = hoverSprite; // Change back to the hover sprite
    }

    // Coroutine to play the click animation
    public void PlayClickAnimation()
    {
        StartCoroutine(ClickAnimationCoroutine()); // Start the click animation coroutine
    }

    private System.Collections.IEnumerator ClickAnimationCoroutine()
    {
        if (audioSource != null)
        {
            audioSource.Play(); // Play the click sound
        }
        isPlaying = true; // Set the playing state to true

        if (clickSprites == null || clickSprites.Count == 0)
        {
            isPlaying = false; // Set the playing state to false
            yield break; // Exit the coroutine if there are no sprites to animate
        }

        for (int i = 0; i < clickSprites.Count; i++)
        {
            spriteRenderer.sprite = clickSprites[i]; // Set the sprite to the current click sprite
            yield return new WaitForSeconds(0.07f); // Wait for a short duration before moving to the next sprite
        }
        isPlaying = false; // Set the playing state to false
    }
}
