using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "Scriptable Objects/Character")]
public class Character : ScriptableObject
{
    public Sprite defaultPortrait;
    public string characterName;
    public Sprite[] talkingPortraits;
    public Sprite happy;
    public Sprite sad;
    public Sprite angry;
    public Sprite surprised;
    public Sprite shocked;
    public Sprite neutral;
    public Sprite thinking;
    public enum PortraitSide
    {
        Left,
        Right
    }
    public PortraitSide portraitSide = PortraitSide.Left;

    public AudioClip talkingSound;
}
