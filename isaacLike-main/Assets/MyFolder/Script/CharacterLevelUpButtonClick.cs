using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLevelUpButtonClick : MonoBehaviour
{
    public void OnClickCharacterLevelUpButton()
    {
        if(simdata.bossOrb > 0)
        {
            simdata.characterLevel += 1;
            simdata.bossOrb -= 1;
        }
    }
}
