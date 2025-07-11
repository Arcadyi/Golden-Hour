using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "CustomAnim", menuName = "Scriptable Objects/CustomAnim")]
public class CustomAnim : ScriptableObject
{
    [SerializeField]
    public List<Sprite> sprites = new List<Sprite>();
    public float animationSpeed = 0.1f; // Speed of the animation
}
