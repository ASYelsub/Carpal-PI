using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Objects",menuName ="Objects/Evidence",order = 0)]
public class Evidence : ScriptableObject
{
    private string evidenceName;

    public bool hasBeenPickedUp; //set false if not in the court record
   // public int evidenceType; //potentially useless //0 = testimony from witness, 1 = found item
    public Sprite imageInCourtRecord;
    public Sprite imageInCrimeScene;
}
