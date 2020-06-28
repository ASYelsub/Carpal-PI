using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{ 
    public Text nameText;
    public Image activeChar;
    private int talkID;
    private int tempTalkID;
    public SceneTextBase currentScene;
    public Text activeDialogue;
    public SceneTextBase[] sceneTextBases;

    public LivesManager livesManager;
    public HeartbeatManager heartbeatManager;
    public TextTyper textTyper;
    
    private void Start()
    {
        UpdateDialogue();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
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

    public void StopPressed()
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
    void UpdateDialogue()
    {
        nameText.color = currentScene.dialogueBits[talkID].charNameColor;
        nameText.text = currentScene.dialogueBits[talkID].charName;
        activeChar.sprite = currentScene.dialogueBits[talkID].charImage;
        activeDialogue.text = currentScene.dialogueBits[talkID].dialouge;
        heartbeatManager.ChangeHeartbeat(currentScene.dialogueBits[talkID].heartbeatFreq);
        textTyper.UpdateText(activeDialogue.text);
    }
    
    
    
    
    
    

}
