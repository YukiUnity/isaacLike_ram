using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using MyData.simdata;

public class CharacterLevelDownButtonClick : MonoBehaviour
{
    public void OnClickCharacterLevelDownButton()
    {
        if (simdata.characterLevel > 1)
        {
            simdata.characterLevel -= 1;
            simdata.bossOrb += 1;
        }
    }
}
