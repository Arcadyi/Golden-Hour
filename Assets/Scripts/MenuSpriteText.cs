using UnityEngine;

public class MenuSpriteText : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer; // Reference to the SpriteRenderer component
    public Sprite[] sprites; // Array of sprites to be used for the animation
    private bool _isHovering = false; // Flag to track if the mouse is hovering over the button
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>(); // Get the SpriteRenderer component attached to this GameObject
        if (_spriteRenderer == null) // Check if the SpriteRenderer component is not found
        {
            Debug.LogError("SpriteRenderer component not found on this GameObject.");
        }
    }

    public void SwitchSprite(int index)
    {
        if (index >= 0 && index < sprites.Length) // Check if the index is within the bounds of the sprites array
        {
            _spriteRenderer.sprite = sprites[index]; // Set the sprite of the SpriteRenderer to the sprite at the specified index
        }
        else
        {
            Debug.LogError("Index out of bounds for sprites array.");
        }
    }

    public void SetHovering(bool hovering)
    {
        _isHovering = hovering; // Set the isHovering flag to the specified value
        if (hovering) // If the mouse is hovering over the button
        {
            // enable the game object
            gameObject.SetActive(true); // Enable the GameObject
        }
        else // If the mouse is not hovering over the button
        {
            // disable the game object
            gameObject.SetActive(false); // Disable the GameObject
        }
    }
}
