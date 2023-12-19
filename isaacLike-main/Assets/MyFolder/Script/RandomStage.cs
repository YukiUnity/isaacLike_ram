using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomStage : MonoBehaviour
{
    //231018
    [SerializeField] GameObject[] RandomMap1;
    [SerializeField] GameObject[] RandomMap2;

    //231018
    public int[] RandomMapNum;

    // Start is called before the first frame update
    void Start()
    {
        RandomMapNum = new int[5];
        //RandomMapNum[0] = Random.Range(0, 4);
        //RandomMapNum[1] = Random.Range(0, 4);
        //Debug.Log("The Random Map is" + RandomMapNum[0]);
        Debug.Log("The Random Map is" + simdata.RandomMapNum[Player.currentPos.x, Player.currentPos.y, 0]);
        Debug.Log("The Random Map is" + simdata.RandomMapNum[Player.currentPos.x, Player.currentPos.y, 1]);
        //231018
        Instantiate(RandomMap1[simdata.RandomMapNum[Player.currentPos.x,Player.currentPos.y,0]], new Vector3(0 ,0, 0), Quaternion.identity);
        Instantiate(RandomMap2[simdata.RandomMapNum[Player.currentPos.x, Player.currentPos.y, 1]], new Vector3(0 ,0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
