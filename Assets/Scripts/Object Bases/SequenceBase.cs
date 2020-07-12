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
      Return,
      Map
   };

   [System.Serializable]
   public class Map
   {
      public Sprite mapImage;
      public LocationBase[] locationsInMap;
      public Vector2[] locationCoordinats;
   }
   
   
   public MinigameEvidenceBase minigameEvidenceBaseInSequence;
   public LocationBase sequenceLocation; //sometimes there is evidence in the background
   //sometimes there is not and it is just behind the stuff

   //DONE //Banter : Talking in or outside court, does not loop, cannot lose health/health not shown
   //CrossExamine : Loops, have the ability to press "STOP,"
   //                  is done looping when everything is learned from testimony, can lose health, can go back and forth, if stop is pressed during the wrong time lose life,
                        //if "stop" is correct it may open some options to click on or whatever or just continue to the next banter, if it is incorrect, a dialogue bit of it being proved wrong is shown
                        //apparently you should be able to present when someone is talking in their testimony.
                        //Should maybe have its own special holder for dialoguebits that can be like picked from? 
   
                        
   //DONE //ExplainEvidence : Someone talks, a little mini-game pops up to look for something in an image, can lose health
   //InvestigateItem : Outside court at crime scene, happens when you click on an item in a crime scene, can unlock more options in InterrogateWitness
   //                  Way to add to CourtRecord
   //InterrogateWitness : Talking to someone at crime scene, questions unlock the more you listen to them. Other locations unlock as well.
   //                     Way to add to CourtRecord
   //Return : This is what plays if you go to a location where you've gotten everything.
   //Map: Displays the map on the screen, all the other UI is turned off, LocationOnMap is displayed.

   //How the evidence works:
   //you will see the map, you are expected to go to one of the locations displayed. in the evidence window is the list of all the evidence. evidence will have "gotten" or "not gotten," if they are
   //"not gotten" they will show up as ??? ??????? in the evidence window with no image displayed when the player hovers over it. The player cannot leave the location until all the evidence from that
   //area has been "gotten."
  
   [Header("Cursed Index For Court Record")]
   public Evidence[] evidenceInSequence1;
   public Evidence[] evidenceInSequence2;
   public Evidence[] evidenceInSequence3;
   [System.Serializable]
   public class DialogueBit
   {
      [Header("General Properties")]
      //public bool interrogationTimeHappening; //usually only true when witnesses are talking and you are cross examining them
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

   [Header("Map Time")] 
   public Map mapInSequence;

}
