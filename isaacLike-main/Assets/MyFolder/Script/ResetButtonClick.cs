using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButtonClick : MonoBehaviour
{
    public void OnClickResetButton()
    {
            simdata.characterLevel = 1;
            simdata.bossOrb = 0;
    }
}
