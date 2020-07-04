using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class View : MonoBehaviour
{
    [Header ("UI On Screen")]
    public Text nameTextDisplay;
    public Image activeCharDisplay;
    public Text dialogueTextDisplay;
    public GameObject courtRecordDisplay;
    public Image backgroundImage;
    public GameObject stopButton;
    public Image[] evidenceDisplay;
    

    [Header("Other Scripts")] 
    public Model model;
    public Controller controller;
    public HeartbeatManager heartbeatManager;
    public TextTyper textTyper;

    private void Awake()
    {
        nameTextDisplay.gameObject.SetActive(false);
        activeCharDisplay.gameObject.SetActive(false);
        dialogueTextDisplay.gameObject.SetActive(false);
        backgroundImage.gameObject.SetActive(false);
        courtRecordDisplay.SetActive(false);
        backgroundImage.gameObject.SetActive(false);
        stopButton.SetActive(false);
    }

    public void DisplayBanter(bool componentsAreSet)
    { if (!componentsAreSet) {
            nameTextDisplay.gameObject.SetActive(true);
            activeCharDisplay.gameObject.SetActive(true);
            dialogueTextDisplay.gameObject.SetActive(true);
            backgroundImage.gameObject.SetActive(true);
            courtRecordDisplay.SetActive(false);
            backgroundImage.gameObject.SetActive(true);
            backgroundImage.sprite = model.activeCase.activeSequence.sequenceLocation.locationBackgroundSprite[0];
            stopButton.SetActive(false);
            print("components set");
        }
        nameTextDisplay.text = 
            model.activeCase.activeSequence.dialogueBitsInSequence[model.activeCase.talkID].activeChar.charName;
        dialogueTextDisplay.text =
            model.activeCase.activeSequence.dialogueBitsInSequence[model.activeCase.talkID].dialouge;
        nameTextDisplay.color = 
            model.activeCase.activeSequence.dialogueBitsInSequence[model.activeCase.talkID].activeChar.charNameColor;
        activeCharDisplay.sprite = 
            model.activeCase.activeSequence.dialogueBitsInSequence[model.activeCase.talkID].activeChar.charImage;
        heartbeatManager.ChangeHeartbeat(model.activeCase.activeSequence.dialogueBitsInSequence[model.activeCase.talkID]
            .heartbeatFreq);
        textTyper.UpdateText(model.activeCase.activeSequence.dialogueBitsInSequence[model.activeCase.talkID].dialouge);
    }
    public void DisplayCrossExamine(bool isSettingComponents)
    {
        
    }
    public void DisplayShowSomethingOnEvidence(bool isSettingComponents)
    {
        
    }
    public void DisplayInvestigateItem(bool isSettingComponents)
    {
        
    }
    public void DisplayInterrogateWitness(bool componentsAreSet)
    {
        if (!componentsAreSet) {
            nameTextDisplay.gameObject.SetActive(true);
            activeCharDisplay.gameObject.SetActive(true);
            dialogueTextDisplay.gameObject.SetActive(true);
            backgroundImage.gameObject.SetActive(true);
            courtRecordDisplay.SetActive(false);
            backgroundImage.gameObject.SetActive(true);
            backgroundImage.sprite = model.activeCase.activeSequence.sequenceLocation.locationBackgroundSprite[0];
            stopButton.SetActive(true);
            print("components set");
        }
        nameTextDisplay.text = 
            model.activeCase.activeSequence.dialogueBitsInSequence[model.activeCase.talkID].activeChar.charName;
        dialogueTextDisplay.text =
            model.activeCase.activeSequence.dialogueBitsInSequence[model.activeCase.talkID].dialouge;
        nameTextDisplay.color = 
            model.activeCase.activeSequence.dialogueBitsInSequence[model.activeCase.talkID].activeChar.charNameColor;
        activeCharDisplay.sprite = 
            model.activeCase.activeSequence.dialogueBitsInSequence[model.activeCase.talkID].activeChar.charImage;
        heartbeatManager.ChangeHeartbeat(model.activeCase.activeSequence.dialogueBitsInSequence[model.activeCase.talkID]
            .heartbeatFreq);
        textTyper.UpdateText(model.activeCase.activeSequence.dialogueBitsInSequence[model.activeCase.talkID].dialouge);

    }
    public void DisplayReturn(bool isSettingComponents)
    {
        
    }
}
