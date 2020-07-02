using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIDisplay : MonoBehaviour
{
    [Header ("UI On Screen")]
    public Text nameTextDisplay;
    public Image activeCharDisplay;
    public Text dialogueTextDisplay;
    public GameObject courtRecordDisplay;
    public Image[] evidenceDisplay;

    [Header("Other Scripts")] 
    public Case1Logic case1Logic;
    public GameManager gameManager;
    public TextTyper textTyper;
    public HeartbeatManager heartbeatManager;
    public LivesManager livesManager;
    
    [Header("Active Things")]
    public SequenceBase activeSequenceBase;
    public BaseCaseLogic activeCaseLogic;

    private bool courtRecordIsOpen;
    private void Awake()
    {
        gameManager = GetComponent<GameManager>();
        livesManager = GetComponent<LivesManager>();
        heartbeatManager = GetComponent<HeartbeatManager>();
        courtRecordIsOpen = false;
        courtRecordDisplay.SetActive(courtRecordIsOpen);
        
    }

    public void LoadText()
    {
        UpdateDialogue();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            switch (activeSequenceBase.mySequenceType)
            {
                case SequenceBase.SequenceType.Banter :
                    print("banter advance");
                    AdvanceBanter();
                    break;
                case SequenceBase.SequenceType.CrossExamine :
                    break;
                case SequenceBase.SequenceType.ShowSomethingOnEvidence :
                    break;
                case SequenceBase.SequenceType.InvestigateItem :
                    break;
                case SequenceBase.SequenceType.InterrogateWitness :
                    break;
                case SequenceBase.SequenceType.Return :
                    break;
            }
        }

    }
    public void UpdateCase()
    {
        activeCaseLogic = gameManager.activeCase;
        activeSequenceBase = activeCaseLogic.activeSequence;
    }
    public void UpdateDialogue()
    {
        activeSequenceBase = activeCaseLogic.activeSequence;
        dialogueTextDisplay.text = activeCaseLogic.activeSequence.dialogueBitsInSequence[activeCaseLogic.talkID].dialouge;
        nameTextDisplay.text = activeCaseLogic.activeSequence.dialogueBitsInSequence[activeCaseLogic.talkID].activeChar.charName;
        nameTextDisplay.color = activeCaseLogic.activeSequence.dialogueBitsInSequence[activeCaseLogic.talkID].activeChar.charNameColor;
        activeCharDisplay.sprite = activeCaseLogic.activeSequence.dialogueBitsInSequence[activeCaseLogic.talkID].activeChar.charImage;
        heartbeatManager.ChangeHeartbeat(activeCaseLogic.activeSequence.dialogueBitsInSequence[activeCaseLogic.talkID].heartbeatFreq);
        textTyper.UpdateText(activeCaseLogic.activeSequence.dialogueBitsInSequence[activeCaseLogic.talkID].dialouge);
    }
    public void UpdateCourtRecordState()
    {
        courtRecordIsOpen = !courtRecordIsOpen;
        courtRecordDisplay.SetActive(courtRecordIsOpen);
    }
    ////////////////////////////////////////////////////////////
    /* The functions to initiate different kinds of Sequences */
    public void InitiateBanter()
    {
        
    }
    public void InitiateCrossExamine()
    {
        
    }
    public void InitiateShowSomethingOnEvidence()
    {
        
    }
    public void InitiateInvestigateItem()
    {
        
    }
    public void InitiateInterrogateWitness()
    {
        
    }
    public void InitiateReturn()
    {
        
    }
    ////////////////////////////////////////////////////////////
    /* The functions to advance different kinds of Sequences */
    public void AdvanceBanter()
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
    public void AdvanceCrossExamine()
    {
        
    }
    public void AdvanceShowSomethingOnEvidence()
    {
        
    }
    public void AdvanceInvestigateItem()
    {
        
    }
    public void AdvanceInterrogateWitness()
    {
        
    }
    public void AdvanceReturn()
    {
        
    }
    ////////////////////////////////////////////////////////////

    public void DisplayCourtRecord()
    {
        
    }
}
