using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalFlagSpawn : MonoBehaviour
{
    //ボススポーンはMap Generator
    
    //231003
    public GameObject finalFlagUp;
    public GameObject finalFlagRight;
    public GameObject finalFlagDown;
    public GameObject finalFlagLeft;

    //231003
    public GameObject FlagPointUp;
    public GameObject FlagPointRight;
    public GameObject FlagPointDown;
    public GameObject FlagPointLeft;

    public MapGenerator mapGenerator;

    int[,] move = { { 0, -1 }, { 1, 0 }, { 0, 1 }, { -1, 0 } };
    public Vector2Int nextPos;


    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < MapGenerator.mazeDatas.GetLength(0); i++)
        {
            for (int j = 0; j < MapGenerator.mazeDatas.GetLength(1); j++)
            {
                if (MapGenerator.mazeDatas[i, j] == 2)
                {
                    Player.currentPos = new Vector2Int(i, j);
                }
            }
        }

        //230929
        mapGenerator = new MapGenerator();

        
        //231003Upが壁の場合
        nextPos = Player.currentPos + new Vector2Int(move[0, 0], move[0, 1]);

        if (mapGenerator.GetNextMapType(nextPos) != 1)
        {
            Vector3 flag_pos_up = FlagPointUp.transform.position;

            Instantiate(finalFlagUp, flag_pos_up, Quaternion.identity);
        }

        //231003Rightが壁の場合
        nextPos = Player.currentPos + new Vector2Int(move[1, 0], move[1, 1]);

        if (mapGenerator.GetNextMapType(nextPos) != 1)
        {
            Vector3 flag_pos_right = FlagPointRight.transform.position;

            Instantiate(finalFlagRight, flag_pos_right, Quaternion.identity);
        }


        //231003Downが壁の場合
        nextPos = Player.currentPos + new Vector2Int(move[2, 0], move[2, 1]);

        if (mapGenerator.GetNextMapType(nextPos) != 1)
        {
            Vector3 flag_pos_down = FlagPointDown.transform.position;

            Instantiate(finalFlagDown, flag_pos_down, Quaternion.identity);
        }

        //231003Leftが壁の場合
        nextPos = Player.currentPos + new Vector2Int(move[3, 0], move[3, 1]);

        if (mapGenerator.GetNextMapType(nextPos) != 1)
        {
            Vector3 flag_pos_left = FlagPointLeft.transform.position;

            Instantiate(finalFlagLeft, flag_pos_left, Quaternion.identity);
        }
        



        /*//231003Upが壁の場合
        nextPos = Player.currentPos + new Vector2Int(move[0, 0], move[0, 1]);

        if (MapGenerator.mazeDatas[nextPos.x,nextPos.y] != 1)
        {
            Vector3 flag_pos_up = FlagPointUp.transform.position;

            Instantiate(finalFlagUp, flag_pos_up, Quaternion.identity);
        }

        //231003Rightが壁の場合
        nextPos = Player.currentPos + new Vector2Int(move[1, 0], move[1, 1]);

        if (MapGenerator.mazeDatas[nextPos.x, nextPos.y] != 1)
        {
            Vector3 flag_pos_right = FlagPointRight.transform.position;

            Instantiate(finalFlagRight, flag_pos_right, Quaternion.identity);
        }


        //231003Downが壁の場合
        nextPos = Player.currentPos + new Vector2Int(move[2, 0], move[2, 1]);

        if (MapGenerator.mazeDatas[nextPos.x, nextPos.y] != 1)
        {
            Vector3 flag_pos_down = FlagPointDown.transform.position;

            Instantiate(finalFlagUp, flag_pos_down, Quaternion.identity);
        }

        //231003Leftが壁の場合
        nextPos = Player.currentPos + new Vector2Int(move[3, 0], move[3, 1]);

        if (MapGenerator.mazeDatas[nextPos.x, nextPos.y] != 1)
        {
            Vector3 flag_pos_left = FlagPointLeft.transform.position;

            Instantiate(finalFlagUp, flag_pos_left, Quaternion.identity);
        }
        */
    }
    
}
