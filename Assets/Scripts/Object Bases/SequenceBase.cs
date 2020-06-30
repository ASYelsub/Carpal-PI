using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Sequences are a bunch of scenetexts together.
//They play when you go to a location, they are the entirety of what happens at that location.
//The scenetexts there or the order of the scenetexts changes as the player goes through the dialouge.
//These scenetexts will be ticked with "player has read."
[CreateAssetMenu(fileName ="Objects",menuName ="Objects/Sequence",order = 0)]
public class SequenceBase : MonoBehaviour
{
   [SerializeField]
   private SceneTextBase[] sceneTextsInSequence;
   
}
