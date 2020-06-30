using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="Objects",menuName ="Objects/Location",order = 0)]
public class LocationBase : ScriptableObject
{
    public string locationName;
    public int visitValue; //0 = can't go to this case, 1 = locked, 2 = visitable
    [System.Serializable]
    public class Evidence
    { 
        public Button[] evidenceClickable; //click on to add to evidence holder
        public SceneTextBase[] sceneFromEvidence; //interaction that happens with evidence  
    }
    public Evidence[] evidenceAtLocation;
    public Sprite[] locationBackgroundSprite; //usually 3 for each location
    public SceneTextBase[] scenesAtLocation; //scenes that happen at location that don't happen from
    //clicking on evidence.
    
}
