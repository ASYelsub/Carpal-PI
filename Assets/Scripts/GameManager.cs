using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This script is used to load whatever case the player is on and reset all values to 0.
public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] activeImages; //0 is beginning screen, 1 is the case

    [Header("Included Scripts")]
    [SerializeField]
    private TextTyper textTyper;
    [SerializeField]
    private TextManager textManager;
    [HideInInspector] 
    public BaseCaseLogic activeCase;
    [SerializeField]
    private BaseCaseLogic[] cases;
    private void Awake()
    {
        activeImages[0].SetActive(true);
        activeImages[1].SetActive(false);
    }
    
    ////////////////////////////////////////////////////////////
    public void LoadCase(int caseNumber)
    {
        activeImages[0].SetActive(false);
        activeImages[1].SetActive(true);
        switch (caseNumber)
        {
            case 1 : 
                //this order is so important let me tell you
                activeCase = cases[0]; 
                print("the active case is:" + activeCase);
                textManager.UpdateCase();
                cases[0].ActivateCase();
                break;
            case 2: 
                activeCase = cases[1]; 
                print("the active case is:" + activeCase);
                textManager.UpdateCase();
                cases[1].ActivateCase();
                break;
        }
        
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
}
