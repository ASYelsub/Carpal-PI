using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//handles maneuvering scenes and sequences in case 1
public class BaseCaseLogic : MonoBehaviour
{
    public int activeSequenceNumber;
    public int revolvingSequenceNumber;

    [HideInInspector]
    public SequenceBase activeSequence;

    //public SceneTextBase currentScene;
    public SequenceBase[] sequencesInCase; //linear, the spine of the game, may take a break from these when you get to one of them and load the other types of sequence lists

    public LocationBase[] locationsInCase; //utilized by CourtRecordDisplay headers
    
    public int evidenceCollectedNumber; //check hasBeenPickedUp in all evidence...
    //amount of evidence that has been collected,
    //to progress the sequence it must match the
    //activeSequence.evidenceProgressionReq
    
    
    //these ones need to be fanoodled or whatever with special code voodoo, insert themselves
    //during the map but don't change activesequenceNumber so the game can continue being linear
    //after the expectations of these are fulfilled
    [System.Serializable]
    public class sequencesWhileGatheringEvidenceUsingMap
    {
        public bool canProgressFromEvidenceGathering; //bool that is flicked when all of the bools on evidence in this class have been flicked
      //  public Evidence[] evidenceCollectedInThisArea; //
        public LocationBase activeLocation;
        public SequenceBase[] entranceSeqencesAtLocation;
        public SequenceBase[] evidenceSequencesAtLocation;
    }

    
    public sequencesWhileGatheringEvidenceUsingMap[] EvidenceGatheringSequences;
                                                                    
                                                                    
    [HideInInspector] public int talkID;
    [HideInInspector] public int tempTalkID;

    //activesequence.evidenceProgressionReq = activeSequence.evidenceInSequence.Length - 1;
    //public int evidenceProgressionReq; //this number changes from sequence to sequence,
                                        //the player must collect all the evidence
                                        //in this sequence to proceed, it's like finite
                                        
   // public int testimonyProgressionReq;
    
    public void ActivateCase()
    {
        activeSequenceNumber = 0; //starting in Bianca's house
        activeSequence = sequencesInCase[0];
        talkID = 0;
        evidenceCollectedNumber = 0;
    }



}
