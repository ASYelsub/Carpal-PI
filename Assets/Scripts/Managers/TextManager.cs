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
    public Case1Logic case1Logic;
    
    //Other Managers
    private LivesManager livesManager;
    private HeartbeatManager heartbeatManager;
    private CanvasManager canvasManager;

    //dependent on where you are, if you've been there, if you have all the evidence
    private void Start()
    {
        canvasManager = GetComponent<CanvasManager>();
        livesManager = GetComponent<LivesManager>();
        heartbeatManager = GetComponent<HeartbeatManager>();
        UpdateDialogue();
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && canvasManager.canvasInt == 1)
        {
            if (textTyper.IsTyping())
            {
                textTyper.QuickSkip();
            }
            else
            {
                case1Logic.AdvanceDialogueBit();
            }
        }
    }

    public void UpdateDialogue()
    {
        dialogueTextDisplay.text = case1Logic.activeSceneText.dialogueBits[case1Logic.talkID].dialouge;
        nameTextDisplay.text = case1Logic.activeSceneText.dialogueBits[case1Logic.talkID].activeChar.charName;
        nameTextDisplay.color = case1Logic.activeSceneText.dialogueBits[case1Logic.talkID].activeChar.charNameColor;
        activeCharDisplay.sprite = case1Logic.activeSceneText.dialogueBits[case1Logic.talkID].activeChar.charImage;
        heartbeatManager.ChangeHeartbeat(case1Logic.activeSceneText.dialogueBits[case1Logic.talkID].heartbeatFreq);
        textTyper.UpdateText(case1Logic.activeSceneText.dialogueBits[case1Logic.talkID].dialouge);
    }
    
    
    
    
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
