using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using MoreMountains.InventoryEngine;

using MoreMountains.Tools;
using MoreMountains.Feedbacks;
using MoreMountains.CorgiEngine;

public class GoToUpLevel : MonoBehaviour
{
    public Player player;

    public Inventory testInventory { get; set; }
    public string AmmoInventoryName = "MainInventory";
    public float DelayBeforeTransition = 0f;

    /*void OnTriggerEnter2D(Collider2D t2)
    {
        if (t2.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            player = new Player();
            Debug.Log("Go To Up Level");
            player._move_UP();

            //230929
            simdata.EntryPoint = 0;


            //231114
            // we grab the ammo inventory if it exists
            GameObject ammoInventoryTmp = GameObject.Find(AmmoInventoryName);
            if (ammoInventoryTmp != null) { testInventory = ammoInventoryTmp.GetComponent<Inventory>(); }

            //testInventory.SaveInventory();

            */
            /*
            if (LevelManager.HasInstance)
            {
                LevelManager.Instance.GotoLevel("test", (DelayBeforeTransition == 0f));
            }
            else
            {
                MMSceneLoadingManager.LoadScene("test");
            }
            */

            /*
            MMGameEvent.Trigger("Save");


            //230929
            SceneManager.LoadScene("test");

        }
    }*/

    public void isGoToUpLevelPressed()
    {
        Calc.GoToSomethingBottonPressed("Up");

        //231216
        /*
        player = new Player();
        Debug.Log("Go To Up Level");
        player._move_UP();

        //230929
        simdata.EntryPoint = 0;


        //231114
        // we grab the ammo inventory if it exists
        GameObject ammoInventoryTmp = GameObject.Find(AmmoInventoryName);
        if (ammoInventoryTmp != null) { testInventory = ammoInventoryTmp.GetComponent<Inventory>(); }

        //testInventory.SaveInventory();

        MMGameEvent.Trigger("Save");


        //230929
        SceneManager.LoadScene("test");
        */
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
