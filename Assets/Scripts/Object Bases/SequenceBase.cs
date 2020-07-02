using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="Objects",menuName ="Objects/Sequence",order = 0)]
public class SequenceBase : ScriptableObject
{
   public string sequenceDescription;
   public SequenceType mySequenceType;
   public enum SequenceType
   {
      Banter,
      CrossExamine,
      ShowSomethingOnEvidence,
      InvestigateItem,
      InterrogateWitness,
      Return
   };
   //Banter : Talking in or outside court, does not loop, cannot lose health/health not shown
   //CrossExamine : Loops, have the ability to press "STOP,"
   //                  is done looping when everything is learned from testimony, can lose health
   //ShowSomethingOnEvidence : Someone talks, a little mini-game pops up to look for something in an image, can lose health
   //InvestigateItem : Outside court at crime scene, happens when you click on an item in a crime scene, can unlock more options in InterrogateWitness
   //                  Way to add to CourtRecord
   //InterrogateWitness : Talking to someone at crime scene, questions unlock the more you listen to them. Other locations unlock as well.
   //                     Way to add to CourtRecord
   //Return : This is what plays if you go to a location where you've gotten everything.
   [System.Serializable]
   public class DialogueBit
   {
      [Header("General Properties")]
      public bool interrogationTimeHappening; //usually only true when witnesses are talking and you are cross examining them
      public bool lastBitInSequence; //once you fulfill the requirement of ending the dialougeBit it goes onto the next sequence
      public Image sequenceBackground; //sometimes there is evidence in the background
                                       //sometimes there is not and it is just behind the stuff
      [Header("Everything But SSOE")]
      public float heartbeatFreq;
      public Character activeChar;
      public string dialouge;
      
      [Header("CrossExamine Only")]
      public bool stopIsCorrect; //you lose a life if you press stop and this is false

      [Header("Inv Item Only")]
      public Image investigateItemPic; //picture that shows up after you click on an item
      
      [Header("Inv Item and Interrogate")]
      public Evidence evidenceFromBit; //evidence that gets added to the courtRecord when this bit is cycled through
   }                                         
   public DialogueBit[] dialogueBitsInSequence;
   public Evidence[] evidenceInSequence; //this number changes from sequence to sequence,
                                    //the player must collect all the evidence
                                    //in this sequence to proceed, it's like finite

}
