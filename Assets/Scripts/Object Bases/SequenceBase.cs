using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Objects",menuName ="Objects/Sequence",order = 0)]
public class SequenceBase : ScriptableObject
{
   public SequenceType mySequenceType;
   public SceneTextBase[] sceneTextsInSequence;
   
   /* So the question is... what kind of sceneTexts would go into the sequence? Why not just use sceneTexts alone? */
   /* This is less of an answer and more a sanity check for myself. */
   /* An example of four sceneTexts in an InterrogateWitness sceneText: the dialouge the witness goes through first, then a blank dialogue box with questions to ask them, then you click on one question... */
   /* listen to them answer, then the same blank dialouge box appears with the questions but the question you asked is grayed out. You can ask again.*/
   
   public Evidence[] evidenceInSequence;
   
   public enum SequenceType
   {
      Banter,
      CrossExamine,
      ExplainEvidence,
      InvestigateItem,
      InterrogateWitness,
      Return
   };
   //Banter : Talking in or outside court, does not loop, cannot lose health/health not shown
   //CrossExamine : Loops, have the ability to press "STOP,"
   //                  is done looping when everything is learned from testimony, can lose health
   //ExplainEvidence : Someone talks, a little mini-game pops up to look for something in an image, can lose health
   //InvestigateItem : Outside court at crime scene, happens when you click on an item in a crime scene, can unlock more options in InterrogateWitness
   //                  Way to add to CourtRecord
   //InterrogateWitness : Talking to someone at crime scene, questions unlock the more you listen to them. Other locations unlock as well.
   //                     Way to add to CourtRecord
   //Return : This is what plays if you go to a location where you've gotten everything.
}
