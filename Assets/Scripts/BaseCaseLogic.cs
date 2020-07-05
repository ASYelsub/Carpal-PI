using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//handles maneuvering scenes and sequences in case 1
public class BaseCaseLogic : MonoBehaviour
{
    [HideInInspector]
    public SequenceBase activeSequence;

    //public SceneTextBase currentScene;
    public SequenceBase[] sequencesInCase;
    [HideInInspector] public int talkID;
    [HideInInspector] public int tempTalkID;
    public int activeSequenceNumber;
    public int evidenceCollectedNumber; //check hasBeenPickedUp in all evidence...
                                        //amount of evidence that has been collected,
                                        //to progress the sequence it must match the
                                        //activeSequence.evidenceProgressionReq
                         
                                        
    //activesequence.evidenceProgressionReq = activeSequence.evidenceInSequence.Length - 1;
    public int evidenceProgressionReq; //this number changes from sequence to sequence,
                                        //the player must collect all the evidence
                                        //in this sequence to proceed, it's like finite
                                        
    public int testimonyProgressionReq;
    
    public void ActivateCase()
    {
        activeSequenceNumber = 0; //starting in Bianca's house
        activeSequence = sequencesInCase[0];
        talkID = 0;
        evidenceCollectedNumber = 0;
    }



}
