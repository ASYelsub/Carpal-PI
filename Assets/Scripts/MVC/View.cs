﻿using System;
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
    public Image textboxBack;
    public GameObject heartbeatDisplay;
    public Image[] evidenceDisplay;
    public Outline[] evidenceBackOutline;
    
    [Header("UI Specifically for ExplainEvidence")]
    public Image showSomethingOnEvidenceImage;
    public Image showSomethingOnEvidenceClickable;
    public Button buttonForExplainEvidence;
    
    [Header ("GameStates")]
    public GameObject preCase;
    public GameObject duringCase;

    [Header("Other Scripts")] 
    public Model model;
    public Controller controller;
    public HeartbeatManager heartbeatManager;
    public TextTyper textTyper;

    public bool courtRecordIsActive;
    private void Awake()
    {
        duringCase.SetActive(false);
        preCase.SetActive(true);
        InCourtRecordDisplayEvidenceOutline(6);
        showSomethingOnEvidenceClickable.gameObject.SetActive(false);
        showSomethingOnEvidenceImage.gameObject.SetActive(false);
    }

    //this technically shouldn't be in view
    public void ToggleCourtRecord()
    {
        courtRecordIsActive = !courtRecordIsActive;
        courtRecordDisplay.SetActive(courtRecordIsActive);
        model.DisplayEvidenceCourtRecord();
    }

    public void ShowEvidenceCourtRecord(int evidenceID)
    {
        switch (evidenceID)
        {
            case 0:
                for (int i = 0; i < evidenceDisplay.Length; i++)
                {
                    evidenceDisplay[i].sprite = model.activeCase.activeSequence.evidenceInSequence1[i].imageInCourtRecord;
                }   
                break;
            case 1:
                for (int i = 0; i < evidenceDisplay.Length; i++)
                {
                    evidenceDisplay[i].sprite = model.activeCase.activeSequence.evidenceInSequence2[i].imageInCourtRecord;
                }   
                break;
            case 2:
                for (int i = 0; i < evidenceDisplay.Length; i++)
                {
                    evidenceDisplay[i].sprite = model.activeCase.activeSequence.evidenceInSequence3[i].imageInCourtRecord;
                }   
                break;
        }
        
    }
    
    
    ///////////    //Court record Functions//    ////////////
    public void InCourtRecordDisplayEvidenceOutline(int evidenceNumber)
    {
        for (int i = 0; i <= evidenceBackOutline.Length - 1; i++)
        {
            if (i == evidenceNumber)
            {
                evidenceBackOutline[i].enabled = true;
            }
            else
            {
                evidenceBackOutline[i].enabled = false;
            }
        }
    }
    public void DisplayEvidenceInCourtRecord()
    {
        
    }
    
    
    
    //////// //   //Sequence Display functions//  //  ///////
    public void DisplayBanter(bool componentsAreSet)
    { if (!componentsAreSet) {
            nameTextDisplay.gameObject.SetActive(true);
            activeCharDisplay.gameObject.SetActive(true);
            dialogueTextDisplay.gameObject.SetActive(true);
            backgroundImage.gameObject.SetActive(true);
            courtRecordDisplay.SetActive(false);
            backgroundImage.sprite = model.activeCase.activeSequence.sequenceLocation.locationBackgroundSprite[0];
            stopButton.SetActive(false);
            heartbeatDisplay.SetActive(true);
            textboxBack.gameObject.SetActive(true);
            showSomethingOnEvidenceImage.gameObject.SetActive(false);
            showSomethingOnEvidenceClickable.gameObject.SetActive(false);
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
    public void DisplayCrossExamine(bool componentsAreSet)
    {
        if (!componentsAreSet) {
            nameTextDisplay.gameObject.SetActive(true);
            activeCharDisplay.gameObject.SetActive(true);
            dialogueTextDisplay.gameObject.SetActive(true);
            courtRecordDisplay.SetActive(false);
            backgroundImage.gameObject.SetActive(true);
            backgroundImage.sprite = model.activeCase.activeSequence.sequenceLocation.locationBackgroundSprite[0];
            stopButton.SetActive(true);
            heartbeatDisplay.SetActive(true);
            textboxBack.gameObject.SetActive(true);
            showSomethingOnEvidenceImage.gameObject.SetActive(false);
            showSomethingOnEvidenceClickable.gameObject.SetActive(false);
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
    public void DisplayExplainEvidence(bool componentsAreSet)
    {
        if (!componentsAreSet)
        {
            nameTextDisplay.gameObject.SetActive(true);
            activeCharDisplay.gameObject.SetActive(false);
            dialogueTextDisplay.gameObject.SetActive(true);
            backgroundImage.gameObject.SetActive(true);
            courtRecordDisplay.SetActive(false);
            backgroundImage.sprite = model.activeCase.activeSequence.sequenceLocation.locationBackgroundSprite[0];
            stopButton.SetActive(false);
            heartbeatDisplay.SetActive(false);
            textboxBack.gameObject.SetActive(true);
            showSomethingOnEvidenceImage.gameObject.SetActive(true);
            showSomethingOnEvidenceClickable.gameObject.SetActive(true);
            print("components set");
        }   
        nameTextDisplay.text = 
            model.activeCase.activeSequence.dialogueBitsInSequence[model.activeCase.talkID].activeChar.charName;
        dialogueTextDisplay.text =
            model.activeCase.activeSequence.dialogueBitsInSequence[model.activeCase.talkID].dialouge;
        nameTextDisplay.color = 
            model.activeCase.activeSequence.dialogueBitsInSequence[model.activeCase.talkID].activeChar.charNameColor;
        textTyper.UpdateText(model.activeCase.activeSequence.dialogueBitsInSequence[model.activeCase.talkID].dialouge);
        showSomethingOnEvidenceImage.sprite = model.activeCase.activeSequence.minigameEvidenceBaseInSequence.bigImage;
        showSomethingOnEvidenceClickable.sprite = model.activeCase.activeSequence.minigameEvidenceBaseInSequence.smallImage;
        buttonForExplainEvidence.image.rectTransform.anchoredPosition =
            model.activeCase.activeSequence.minigameEvidenceBaseInSequence.buttonCoordinates;
        buttonForExplainEvidence.image.rectTransform.sizeDelta =
            model.activeCase.activeSequence.minigameEvidenceBaseInSequence.buttonSizing;
    }
    public void DisplayInvestigateItem(bool componentsAreSet)
    {
        //literally just the backgrown and like arrows to show one or another background are shown, also the evidence sort of sprinkled throughout is shown
        if (!componentsAreSet) {
            nameTextDisplay.gameObject.SetActive(false);
            activeCharDisplay.gameObject.SetActive(false);
            dialogueTextDisplay.gameObject.SetActive(false);
            courtRecordDisplay.SetActive(false);
            backgroundImage.gameObject.SetActive(true);
            backgroundImage.sprite = model.activeCase.activeSequence.sequenceLocation.locationBackgroundSprite[0];
            stopButton.SetActive(false);
            heartbeatDisplay.SetActive(false);
            textboxBack.gameObject.SetActive(false);
            showSomethingOnEvidenceImage.gameObject.SetActive(false);
            showSomethingOnEvidenceClickable.gameObject.SetActive(false);
            print("components set");
        }
    }
    public void DisplayInterrogateWitness(bool componentsAreSet)
    {
        if (!componentsAreSet) {
            nameTextDisplay.gameObject.SetActive(true);
            activeCharDisplay.gameObject.SetActive(true);
            dialogueTextDisplay.gameObject.SetActive(true);
            courtRecordDisplay.SetActive(false);
            backgroundImage.gameObject.SetActive(true);
            backgroundImage.sprite = model.activeCase.activeSequence.sequenceLocation.locationBackgroundSprite[0];
            stopButton.SetActive(false);
            heartbeatDisplay.SetActive(true);
            textboxBack.gameObject.SetActive(true);
            showSomethingOnEvidenceImage.gameObject.SetActive(false);
            showSomethingOnEvidenceClickable.gameObject.SetActive(false);
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
    public void DisplayReturn(bool componentsAreSet)
    {
        
    }
}
