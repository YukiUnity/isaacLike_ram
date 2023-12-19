using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUpButtonClick : MonoBehaviour
{
    public void OnClickLevelUpButton()
    {
        SceneManager.LoadScene("LevelUp");
    }

}
