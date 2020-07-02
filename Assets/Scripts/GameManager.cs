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
    private UIDisplay uiDisplay;
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
                uiDisplay.UpdateCase();
                cases[0].ActivateCase();
                break;
            case 2: 
                activeCase = cases[1]; 
                print("the active case is:" + activeCase);
                uiDisplay.UpdateCase();
                cases[1].ActivateCase();
                break;
        }
        
    }
    }
