using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class TextManager : MonoBehaviour
{ 
    [Header ("UI On Screen")]
    public Text nameTextDisplay;
    public Image activeCharDisplay;
    public Text dialogueTextDisplay;
    
    [Header ("Other Scripts")]
    public TextTyper textTyper;
    public BaseCaseLogic activeCaseLogic;
    
    //Other Managers
    private LivesManager livesManager;
    private HeartbeatManager heartbeatManager;
    private GameManager gameManager;
    //dependent on where you are, if you've been there, if you have all the evidence
    private void Awake()
    {
        gameManager = GetComponent<GameManager>();
        livesManager = GetComponent<LivesManager>();
        heartbeatManager = GetComponent<HeartbeatManager>();
    }

    

    /*private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
                 {
                     if (textTyper.IsTyping())
                     {
                         textTyper.QuickSkip();
                     }
                     else
                     {
                         activeCaseLogic.AdvanceDialogueBit();
                         print(activeCaseLogic.activeSequenceNumber);
                     }
                 }
    }*/

   /* public void UpdateCase()
    {
        activeCaseLogic = gameManager.activeCase;
    }
    public void UpdateDialogue()
    {
        dialogueTextDisplay.text = activeCaseLogic.activeSequence.dialogueBitsInSequence[activeCaseLogic.talkID].dialouge;
        nameTextDisplay.text = activeCaseLogic.activeSequence.dialogueBitsInSequence[activeCaseLogic.talkID].activeChar.charName;
        nameTextDisplay.color = activeCaseLogic.activeSequence.dialogueBitsInSequence[activeCaseLogic.talkID].activeChar.charNameColor;
        activeCharDisplay.sprite = activeCaseLogic.activeSequence.dialogueBitsInSequence[activeCaseLogic.talkID].activeChar.charImage;
        heartbeatManager.ChangeHeartbeat(activeCaseLogic.activeSequence.dialogueBitsInSequence[activeCaseLogic.talkID].heartbeatFreq);
        textTyper.UpdateText(activeCaseLogic.activeSequence.dialogueBitsInSequence[activeCaseLogic.talkID].dialouge);
    }*/


    /*public void StopPressed() //THIS LOGIC NEEDS TO BE MELDED W SEQUENCES
    {
        if (currentScene.dialogueBits[currentScene.talkID].interrogationTimeHappening)
        {
            if (!currentScene.dialogueBits[currentScene.talkID].stopIsCorrect)
            {
                currentScene = Case1Logic.activeSequence.sceneTextsInSequence[1];
                currentScene.tempTalkID = currentScene.talkID; //saves the talkID of the original thing
                currentScene.talkID = 0;
                livesManager.LoseOneLife();
                UpdateDialogue();
            }
            else if (currentScene.dialogueBits[currentScene.talkID].stopIsCorrect)
            {
                currentScene = Case1Logic.activeSequence.sceneTextsInSequence[2];
                currentScene.tempTalkID = currentScene.talkID; //saves the talkID of the original thing
                currentScene.talkID = 0;
                UpdateDialogue();
            }
        }
    }*/



    
    /*if (case1Logic.activeSequence..talkID <= case1Logic.currentScene.dialogueBits.Length)
    {
        case1Logic.currentScene.talkID++;
    }
    else
    {
        case1Logic.activeSequenceNumber++;
        case1Logic.currentScene.talkID = 0;
    }
    print(case1Logic.currentScene.talkID);
    //UpdateDialogue();
    //}
    */

}
