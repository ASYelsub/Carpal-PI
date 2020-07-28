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
    public Image backgroundImage; //also what the map slots into
    public Image[] mapLocations;
    public GameObject stopButton;
    public Image textboxBack;
    public GameObject heartbeatDisplay;
    public GameObject healthHolder;
    public GameObject courtRecordButton;
    
    [System.Serializable]
    public class EvidenceUnderHeader
    {
        public Image evidneceThumbnail;
        public Outline evidenceBackOutline;
    }
    
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
    public CrimeSceneManager crimeSceneManager;

    public bool courtRecordIsActive;
    private void Awake()
    {
        duringCase.SetActive(false);
        preCase.SetActive(true);
        showSomethingOnEvidenceClickable.gameObject.SetActive(false);
        showSomethingOnEvidenceImage.gameObject.SetActive(false);
    }

    //this technically shouldn't be in view
    public void ToggleCourtRecord()
    {
        courtRecordIsActive = !courtRecordIsActive;
        courtRecordDisplay.SetActive(courtRecordIsActive);
    }

    
    //////// //   //SEQUENCE DISPLAY FUNCTIONS//  //  ///////
    public void DisplayMap(bool componentsAreSet)
    {
        
        if (!componentsAreSet)
        {
            for (int i = 0; i < mapLocations.Length; i++)
            {
                mapLocations[i].gameObject.SetActive(true);
            }
            nameTextDisplay.gameObject.SetActive(false);
            activeCharDisplay.gameObject.SetActive(false);
            dialogueTextDisplay.gameObject.SetActive(false);
            backgroundImage.gameObject.SetActive(true);
            courtRecordDisplay.SetActive(false);
            stopButton.SetActive(false);
            heartbeatDisplay.SetActive(false);
            textboxBack.gameObject.SetActive(false);
            showSomethingOnEvidenceImage.gameObject.SetActive(false);
            showSomethingOnEvidenceClickable.gameObject.SetActive(false);
            courtRecordButton.SetActive(true);
            healthHolder.SetActive(false);
            print("components set");
            //gotta set active the clickables on the map, usually there are 3
        }
        backgroundImage.sprite = model.activeCase.activeSequence.mapInSequence.mapImage;
        for (int i = 0; i < mapLocations.Length; i++)
        {
            mapLocations[i].sprite = model.activeCase.activeSequence.mapInSequence.locationsInMap[i].mapSprite;
        }

        for (int i = 0; i < mapLocations.Length; i++)
        {
            mapLocations[i].rectTransform.anchoredPosition =
                model.activeCase.activeSequence.mapInSequence.locationCoordinats[i];
        }
        //gotta set the images of the clickables on the map dependent on activesequence.activebase.location.mapsprite
        //and do the same thing with the locations of those clickables dependent on activesequence.activebase.mapsprite.locationcoordinates
    }
    public void DisplayBanter(bool componentsAreSet, int loadLocationNumber)
    { if (!componentsAreSet) {
            for (int i = 0; i < mapLocations.Length; i++)
            {
                mapLocations[i].gameObject.SetActive(false);
            }
            nameTextDisplay.gameObject.SetActive(true);
            activeCharDisplay.gameObject.SetActive(true);
            dialogueTextDisplay.gameObject.SetActive(true);
            backgroundImage.gameObject.SetActive(true);
            courtRecordDisplay.SetActive(false);
            stopButton.SetActive(false);
            heartbeatDisplay.SetActive(true);
            textboxBack.gameObject.SetActive(true);
            showSomethingOnEvidenceImage.gameObject.SetActive(false);
            showSomethingOnEvidenceClickable.gameObject.SetActive(false);
            courtRecordButton.SetActive(true);
            healthHolder.SetActive(false);
            print("components set");
        }
            nameTextDisplay.text = 
                model.activeCase.activeSequence.dialogueBitsInSequence[model.activeCase.talkID].activeChar.charName;
            backgroundImage.sprite = model.activeCase.activeSequence.sequenceLocation.locationBackgroundSprite[0];
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
            for (int i = 0; i < mapLocations.Length; i++)
            {
                mapLocations[i].gameObject.SetActive(false);
            }
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
            courtRecordButton.SetActive(true);
            healthHolder.SetActive(true);
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
    
    public void DisplaySurveyCrimeScene(bool componentsAreSet, int displayWhichScene)
    {
        if (!componentsAreSet) {
            nameTextDisplay.gameObject.SetActive(false);
            activeCharDisplay.gameObject.SetActive(false);
            dialogueTextDisplay.gameObject.SetActive(false);
            backgroundImage.gameObject.SetActive(true);
            courtRecordDisplay.SetActive(false);
            stopButton.SetActive(false);
            heartbeatDisplay.SetActive(false);
            textboxBack.gameObject.SetActive(false);
            showSomethingOnEvidenceImage.gameObject.SetActive(false);
            showSomethingOnEvidenceClickable.gameObject.SetActive(false);
            courtRecordButton.SetActive(true);
            healthHolder.SetActive(false);
            print("components set");
            crimeSceneManager.DisplayEvidenceAtLocation();
        }
        backgroundImage.sprite = model.activeCase.activeSequence.sequenceLocation.locationBackgroundSprite[0];
    }

    //UNFINISHED FUNCTIONS AND SHIT//
    public void DisplayInvestigateItem(bool componentsAreSet)
    {
        if (!componentsAreSet) {
            for (int i = 0; i < mapLocations.Length; i++)
            {
                mapLocations[i].gameObject.SetActive(false);
            }
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
    public void DisplayCrossExamine(bool componentsAreSet)
    {
        if (!componentsAreSet) {
            for (int i = 0; i < mapLocations.Length; i++)
            {
                mapLocations[i].gameObject.SetActive(false);
            }
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
    
    
    //only difference between this and investigate item is you can present evidence to the witness
    public void DisplayInterrogateWitness(bool componentsAreSet)
    {
        if (!componentsAreSet) {
            for (int i = 0; i < mapLocations.Length; i++)
            {
                mapLocations[i].gameObject.SetActive(false);
            }
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
