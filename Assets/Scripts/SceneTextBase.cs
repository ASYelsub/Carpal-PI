using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="Objects",menuName ="Objects/SceneText",order = 0)]
public class SceneTextBase : ScriptableObject
{
   [System.Serializable]
   public class DialogueBit
   {
      public string charName;
      public Sprite charImage;
      public string dialouge;
      public float heartbeatFreq;
   }

   public DialogueBit[] dialogueBits;

}
