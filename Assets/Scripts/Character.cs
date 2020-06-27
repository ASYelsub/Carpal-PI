using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Objects",menuName ="Objects/Characters",order = 0)]
public class Character : ScriptableObject
{
    public string name; //name, also the id that will be called during dialouge for portrait/sound
    public Sprite portrait; //
    public AudioClip talkSound; //sound that plays during their talking
}
