using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UsableObject", menuName = "UsableObjects/Make New UsableObject", order = 0)]
public class UsableObject : ScriptableObject
{
    [SerializeField] GameObject objectPrefab;
    [SerializeField] int effect;
    [SerializeField] int bestUsedInStageNumber;
    [SerializeField] int noEffectInStageNumber;
    [SerializeField] int doNotUseInStageNumber;
    [SerializeField] bool isSyringe = false;


    public void UseObject(Prisoner prisoner)
    {
        int currentStage = prisoner.GetStage();
        float noise = 0;

        if (isSyringe)
        {
            noise += effect;
        }

        if (currentStage == bestUsedInStageNumber)
        {
            noise -= effect; 
        }
        else if (currentStage == noEffectInStageNumber)
        {
            noise = 0f;
        }
        else if (currentStage == doNotUseInStageNumber)
        {
            noise += effect;
        }

        prisoner.UpdateStats(noise);
    }
}
