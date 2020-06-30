using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//SceneTexts are strings of characters talking, they can happen one after another
//an example would be:
//one scene text is bianca telling you to interrogate the witness
//another scene text is you cross-examining the witness
//another scene text is after going through the entire cross examination scene text, if you have not
//met the conditions to continue by getting all the information from them,
//bianca will give you a small hint, its own scene text,
//and then the cross examination scene text will replay


[CreateAssetMenu(fileName ="Objects",menuName ="Objects/SceneText",order = 0)]
public class SceneTextBase : ScriptableObject
{
   public string nameOfExchange;
   [System.Serializable]
   public class DialogueBit
   {
      public Character activeChar;
      public string dialouge;
      public float heartbeatFreq;
      public bool stopIsCorrect;                //you lose a life if you press stop and this is false
      public bool interrogationTimeHappening; //usually only true when witnesses are talking and you
   }                                          //are cross examining them
   
   public DialogueBit[] dialogueBits;

}


//I think there should probably be three or four different kinds of dialouge bits.
//1: Cross-examination time, has a stop button. Can change what scenetexts are in the sequence.
//2: Bianca's hint after the cross examination. ???Maybe pretty much the same as cross-examination?
//3: General Banter/Transition, has a specific before and after scene
//4: Interrogating people in the open world, unlocking questions after you ask them things to have new
      // interrogation scenetexts.


//This is sort of abstract but taking scenetext to another level:
//having analysis of objects or maps be a scenetext in the sequence