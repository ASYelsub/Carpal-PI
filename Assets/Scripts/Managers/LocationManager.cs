using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocationManager : MonoBehaviour
{
    private CanvasManager canvasManager;
    
    [SerializeField]
    private Image activeBackground;
    [SerializeField]
    private MapIcon[] mapIcons;
    
    [System.Serializable]
    public class MapIcon
    {
        public Button buttonOnMap;
        public Text buttonText;
        public LocationBase locationInfoOfIcon;
    }
    
    private void Awake()
    {
        canvasManager = gameObject.GetComponent<CanvasManager>();
    }

    private void Start()
    {
        for (int i = 0; i < mapIcons.Length; i++)
        {
            mapIcons[i].buttonText = mapIcons[i].buttonOnMap.GetComponentInChildren<Text>();
            mapIcons[i].buttonText.text = mapIcons[i].locationInfoOfIcon.name;
        }        
    }

    public void LoadLocation(int locationValue)
    {
        canvasManager.ChangeCanvas(0);
        activeBackground.sprite = mapIcons[locationValue].locationInfoOfIcon.locationBackgroundSprite[0];
    }
}
