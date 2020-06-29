using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour
{
    public Image[] livesImages;
    private int lifeCount;
    public Text loseText;

    private void Start()
    {
        lifeCount = 4;
        loseText.enabled = false;
    }
    public void LoseOneLife()
    { 
        print(lifeCount);
        if (lifeCount >= 2)
        {
            lifeCount--;
            DisplayLives();
        }
        else
        {
            print("ITS HAPPENING");
            loseText.enabled = true;
            lifeCount--;
            DisplayLives();
        }
    }
    public void DisplayLives()
    {
        for (int i = 0; i < livesImages.Length; i++)
        {
            livesImages[i].enabled = false;
        }
        for (int j = 0; j < lifeCount; j++)
        {
            livesImages[j].enabled = true;
        }
    }
}
