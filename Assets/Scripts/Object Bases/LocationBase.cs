using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="Objects",menuName ="Objects/Location",order = 0)]
public class LocationBase : ScriptableObject
{
    public string locationName;
     
    [HideInInspector]
    public int visitValue; //0 = can't go to this case, 1 = locked, 2 = visitable

    [Header("Based On Map")]
    public Sprite mapSprite;
    [Header("Based In Location")]
    public Evidence[] evidenceAtLocation;
    public Sprite[] locationBackgroundSprite; //usually 3 for each location

}
