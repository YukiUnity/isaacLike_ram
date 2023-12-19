using MoreMountains.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToDownLevel : MonoBehaviour
{

    public Player player;

    /*void OnTriggerEnter2D(Collider2D t2)
    {
        if (t2.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            player = new Player();
            Debug.Log("Go To Down Level");
            player._move_DOWN();

            //230929
            simdata.EntryPoint = 2;

            //231115
            MMGameEvent.Trigger("Save");

            //230929
            SceneManager.LoadScene("test");
        }
    }*/

    public void isGoToDownLevelPressed()
    {
        Calc.GoToSomethingBottonPressed("Down");
        
        /*player = new Player();
        Debug.Log("Go To Down Level");
        player._move_DOWN();

        //230929
        simdata.EntryPoint = 2;

        //231115
        MMGameEvent.Trigger("Save");

        //230929
        SceneManager.LoadScene("test");*/
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
