using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [Header("Other Scripts")] 
    public Model model;
    public View view;

    
    

    //This function gets an integer from one of the two start buttons to set the activeCase.
    //1 is the first case. 2 is the second case.
    public void GetActiveCase(int caseNumber)
    {
        model.SetActiveCase(caseNumber);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            //
        }
    }
}
