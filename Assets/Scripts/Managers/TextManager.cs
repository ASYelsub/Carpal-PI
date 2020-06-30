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
    private int talkID;
    private int tempTalkID;
    public SceneTextBase currentScene;
    public Text activeDialogue;
    

    public LivesManager livesManager;
    public HeartbeatManager heartbeatManager;
    public TextTyper textTyper;

    private CanvasManager canvasManager;
    
    //dependent on where you are, if you've been there, if you have all the evidence
    public SceneTextBase[] sceneTextBases;
    
    private void Start()
    {
        canvasManager = GetComponent<CanvasManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && canvasManager.canvasInt == 2)
        {
            if (textTyper.IsTyping())
            {
                textTyper.QuickSkip();
            }
            else
            {
                if (talkID >= currentScene.dialogueBits.Length - 1)
                {
                    if(currentScene == sceneTextBases[1] || currentScene == sceneTextBases[2])
                    {
                        currentScene = sceneTextBases[0];
                        talkID = tempTalkID;
                        UpdateDialogue();
                    }
                    else
                    {
                        talkID = 0;
                        UpdateDialogue();
                    }
                }
                else
                {
                    talkID++;
                    UpdateDialogue();
                }

            }
        }
    }

    public void StopPressed() //THIS LOGIC NEEDS TO BE MELDED W SEQUENCES
    {
        if (currentScene.dialogueBits[talkID].interrogationTimeHappening)
        {
            if (!currentScene.dialogueBits[talkID].stopIsCorrect)
            {
                currentScene = sceneTextBases[1];
                tempTalkID = talkID; //saves the talkID of the original thing
                talkID = 0;
                livesManager.LoseOneLife();
                UpdateDialogue();
            }
            else if (currentScene.dialogueBits[talkID].stopIsCorrect)
            {
                currentScene = sceneTextBases[2];
                tempTalkID = talkID; //saves the talkID of the original thing
                talkID = 0;
                UpdateDialogue();
            }
        }
    }
    public void UpdateDialogue()
    {
        nameText.color = currentScene.dialogueBits[talkID].activeChar.charNameColor;
        nameText.text = currentScene.dialogueBits[talkID].activeChar.charName;
        activeChar.sprite = currentScene.dialogueBits[talkID].activeChar.charImage;
        activeDialogue.text = currentScene.dialogueBits[talkID].dialouge;
        heartbeatManager.ChangeHeartbeat(currentScene.dialogueBits[talkID].heartbeatFreq);
        textTyper.UpdateText(activeDialogue.text);
    }
    
    
    
    
    
    

}
