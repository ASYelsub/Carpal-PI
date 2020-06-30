using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//THIS SCRIPT IS NOT UPDATED TO USE SEQUENCES
public class TextManager : MonoBehaviour
{ 
    public Text nameText;
    public Image activeChar;
  //  private int talkID; //talk ID is connected to the current scenetext
  //  private int tempTalkID;
    
    public Text activeDialogue;

    public LivesManager livesManager;
    public HeartbeatManager heartbeatManager;
    public TextTyper textTyper;

    private CanvasManager canvasManager;

    public Case1Logic case1Logic;
    //dependent on where you are, if you've been there, if you have all the evidence
    private void Start()
    {
        
        canvasManager = GetComponent<CanvasManager>();
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
                if (case1Logic.currentScene.talkID >= case1Logic.currentScene.dialogueBits.Length - 1)
                {
                    case1Logic.currentScene.talkID = 0;
                    UpdateDialogue();
                }
                else
                {
                    case1Logic.currentScene.talkID++;
                    UpdateDialogue();
                }
            }
        }
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
    public void UpdateDialogue()
    {
        nameText.color = case1Logic.currentScene.dialogueBits[case1Logic.currentScene.talkID].activeChar.charNameColor;
        nameText.text = case1Logic.currentScene.dialogueBits[case1Logic.currentScene.talkID].activeChar.charName;
        activeChar.sprite = case1Logic.currentScene.dialogueBits[case1Logic.currentScene.talkID].activeChar.charImage;
        activeDialogue.text = case1Logic.currentScene.dialogueBits[case1Logic.currentScene.talkID].dialouge;
        heartbeatManager.ChangeHeartbeat(case1Logic.currentScene.dialogueBits[case1Logic.currentScene.talkID].heartbeatFreq);
        textTyper.UpdateText(activeDialogue.text);
        print(case1Logic.currentScene.talkID);
    }
    
    
    
    
    
    

}
