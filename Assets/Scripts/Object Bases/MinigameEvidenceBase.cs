using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Objects",menuName ="Objects/MinigameEvidence",order = 0)]
public class MinigameEvidenceBase : ScriptableObject
{
    //Gonna have a bigger image and then a smaller segment of the image which is the correct place to click.

    public Sprite bigImage;
    public Sprite smallImage;
    public Vector2 smallImageCoordinates;

}
