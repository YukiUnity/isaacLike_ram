using JetBrains.Annotations;
using MoreMountains.Tools;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Calc : MonoBehaviour
{
    public static void GoToSomethingBottonPressed(string direction)
    {
        Player player;

        player = new Player();

        switch (direction)
        {
            case "Up":
                Debug.Log("Go To Up Level");
                player._move_Anywhere("Up");

                //230929
                simdata.EntryPoint = 0;
                break;
            case "Right":
                Debug.Log("Go To Right Level");
                player._move_Anywhere("Right");

                //230929
                simdata.EntryPoint = 1;
                break;
            case "Down":
                Debug.Log("Go To Down Level");
                player._move_Anywhere("Down");

                //230929
                simdata.EntryPoint = 2;
                break;
            case "Left":
                Debug.Log("Go To Left Level");
                player._move_Anywhere("Left");

                //230929
                simdata.EntryPoint = 3;
                break;
            default:
                Console.WriteLine("Unknown message type.");
                break;
        }



        //231115
        MMGameEvent.Trigger("Save");

        //230929
        SceneManager.LoadScene("test");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
