using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] canvas;
    
    [HideInInspector]
    public int canvasInt;
    
    private TextManager textManager;
    private void Start()
    {
        textManager = gameObject.GetComponent<TextManager>();
        canvasInt = 0;
        canvas[0].SetActive(true);
        canvas[1].SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (canvasInt >= 1)
            {
                canvasInt = 0;
            }
            else
            {
                canvasInt++;   
            }
            ChangeCanvas(canvasInt);
        }
    }

    public void ChangeCanvas(int theInteger)
    {
        for (int i = 0; i < canvas.Length; i++)
        {
            if (i == theInteger)
            {
                canvas[i].SetActive(true);
            }
            else
            {
                canvas[i].SetActive(false);
            }
        }
        if (theInteger == canvas.Length -1)
        {
            textManager.UpdateDialogue();
        }
    }
}
