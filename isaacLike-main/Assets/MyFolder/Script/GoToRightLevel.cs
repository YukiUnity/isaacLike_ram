using MoreMountains.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToRightLevel : MonoBehaviour
{
    public Player player;

    /*void OnCollisionEnter2D(Collision collision)
    {
        Debug.Log("Hit"); // ÉçÉOÇï\é¶Ç∑ÇÈ

    }*/

    /*void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("miya");
    }*/

    /*void OnTriggerEnter2D(Collider2D t2)
    {
        if (t2.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            player = new Player();
            Debug.Log("Go To Right Level");
            player._move_RIGHT();

            //230929
            simdata.EntryPoint = 1;

            //231115
            MMGameEvent.Trigger("Save");

            //230929
            SceneManager.LoadScene("test");
        }
    }*/

    /*void OnTriggerEnter(Collider t)
    {
        Debug.Log("Hit?");
    }*/

    public void isGoToRightLevelPressed()
    {
        Calc.GoToSomethingBottonPressed("Right");
        
        /*
        player = new Player();
        Debug.Log("Go To Right Level");
        player._move_RIGHT();

        //230929
        simdata.EntryPoint = 1;

        //231115
        MMGameEvent.Trigger("Save");

        //230929
        SceneManager.LoadScene("test");
        */
    }

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("ready");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
