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
    public SceneTextBase currentScene;
    public Text activeDialogue;

    public HeartbeatManager heartbeatManager;
    private void Start()
    {
        UpdateDialogue();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            talkID++;
            UpdateDialogue();
        }
    }

    public void StopPressed()
    {
        if (currentScene.dialogueBits[talkID].stopIsCorrect == false)
        {
            print("YOU FUCKED UP");
        }

        if (currentScene.dialogueBits[talkID].stopIsCorrect == true)
        {
            print("good deductive skills!");
        }
        
    }
    void UpdateDialogue()
    {
        nameText.text = currentScene.dialogueBits[talkID].charName;
        activeChar.sprite = currentScene.dialogueBits[talkID].charImage;
        activeDialogue.text = currentScene.dialogueBits[talkID].dialouge;
        heartbeatManager.changeHeartbeat(currentScene.dialogueBits[talkID].heartbeatFreq);
    }
}
