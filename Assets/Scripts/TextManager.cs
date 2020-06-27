using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public Character[] characters;

    public Text nameText;
    public Image activeChar;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            nameText.text = characters[0].name;
            activeChar.sprite = characters[0].portrait;
        }
        if (Input.GetKey(KeyCode.Return))
        {
            nameText.text = characters[1].name;
            activeChar.sprite = characters[1].portrait;
        }
    }
}
