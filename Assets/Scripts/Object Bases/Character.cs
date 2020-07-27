using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Objects",menuName ="Objects/Character",order = 0)]
public class Character : ScriptableObject
{
    public Color charNameColor; 
    public string charName;
    public Sprite charImage;
    public AudioClip charVoice;
}
