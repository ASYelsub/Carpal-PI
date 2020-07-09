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
      ExplainEvidence,
      InvestigateItem,
      InterrogateWitness,
      Return
   };

   public MinigameEvidenceBase minigameEvidenceBaseInSequence;
   public LocationBase sequenceLocation; //sometimes there is evidence in the background
   //sometimes there is not and it is just behind the stuff

   //Banter : Talking in or outside court, does not loop, cannot lose health/health not shown
   //CrossExamine : Loops, have the ability to press "STOP,"
   //                  is done looping when everything is learned from testimony, can lose health
   //ExplainEvidence : Someone talks, a little mini-game pops up to look for something in an image, can lose health
   //InvestigateItem : Outside court at crime scene, happens when you click on an item in a crime scene, can unlock more options in InterrogateWitness
   //                  Way to add to CourtRecord
   //InterrogateWitness : Talking to someone at crime scene, questions unlock the more you listen to them. Other locations unlock as well.
   //                     Way to add to CourtRecord
   //Return : This is what plays if you go to a location where you've gotten everything.
  
   [Header("Cursed Index For Court Record")]
   public Evidence[] evidenceInSequence1;
   public Evidence[] evidenceInSequence2;
   public Evidence[] evidenceInSequence3;
   [System.Serializable]
   public class DialogueBit
   {
      [Header("General Properties")]
      public bool interrogationTimeHappening; //usually only true when witnesses are talking and you are cross examining them
      public bool lastBitInSequence; //once you fulfill the requirement of ending the dialougeBit it goes onto the next sequence
      
      [Header("Everything But SSOE")]
      public float heartbeatFreq;
      public Character activeChar;
      public string dialouge;
      
      [Header("CrossExamine Only")]
      public bool stopIsCorrect; //you lose a life if you press stop and this is false

      [Header("Inv Item Only")]
      public Image investigateItemPic; //picture that shows up after you click on an item
                                       ////number the player is expected to fill to continue 
      
      [Header("Inv Item and Interrogate")]
      public Evidence evidenceFromBit; //evidence that gets added to the courtRecord when this bit is cycled through
   }
   [Header("Dialogue Bit Time")]
   public DialogueBit[] dialogueBitsInSequence;
   

}
