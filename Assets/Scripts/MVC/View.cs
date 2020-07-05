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
    public Image textboxBack;
    public GameObject heartbeatDisplay;
    public Image[] evidenceDisplay;
    public Outline[] evidenceBackOutline;

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
    }

    public void ToggleCourtRecord()
    {
        courtRecordIsActive = !courtRecordIsActive;
        courtRecordDisplay.SetActive(courtRecordIsActive);
    }

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
        print("is this happening?");
        for (int i = 0; i <= 4; i++) //5 is the amount of slots in the thing
        {
            evidenceDisplay[i].sprite = model.evidenceRows[model.activeEvidenceRowNumber].evidenceInEvidenceRow[i].imageInCourtRecord;
        }
        print("yes it happened.");
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
            heartbeatDisplay.SetActive(true);
            textboxBack.gameObject.SetActive(true);
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
    public void DisplayShowSomethingOnEvidence(bool componentsAreSet)
    {
        
    }
    public void DisplayInvestigateItem(bool componentsAreSet)
    {
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
