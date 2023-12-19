using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameButtonClick : MonoBehaviour
{
    public void OnClickGameButton()
    {
        Debug.Log("Load Scene Start");
        SceneManager.LoadScene("test");
        Debug.Log("Load Scene End");
    }
}
