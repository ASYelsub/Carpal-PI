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
      public Color charNameColor; 
      public string charName;
      public Sprite charImage;
      public string dialouge;
      public float heartbeatFreq;
      public bool stopIsCorrect;                //you lose a life if you press stop and this is false
      public bool interrogationTimeHappening; //usually only true when witnesses are talking and you
   }                                          //are cross examining them
   
   public DialogueBit[] dialogueBits;

}
