using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocationManager : MonoBehaviour
{
    private Image activeBackground;

    [System.Serializable]
    public class MapIcon
    {
        public Button buttonOnMap;
        public Text buttonText;
        public LocationBase locationInfoOfIcon;
    }

    [SerializeField]
    private MapIcon[] mapIcons;

    private void Start()
    {
        for (int i = 0; i < mapIcons.Length; i++)
        {
            mapIcons[i].buttonText = mapIcons[i].buttonOnMap.GetComponentInChildren<Text>();
            mapIcons[i].buttonText.text = mapIcons[i].locationInfoOfIcon.name;
        }        
    }
}
