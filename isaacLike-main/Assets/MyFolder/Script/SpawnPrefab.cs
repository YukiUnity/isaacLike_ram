using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPrefab : MonoBehaviour
{
    // プレハブ格納用
    public GameObject CubePrefab;
    public GameObject SpawnPoint;

    //230929
    public GameObject SpawnPointUp;
    public GameObject SpawnPointRight;
    public GameObject SpawnPointDown;
    public GameObject SpawnPointLeft;

    // Start is called before the first frame update
    void Start()
    {
        //230929
        switch(simdata.EntryPoint)
        {
            case 0:
                Vector3 spawn_pos_up = SpawnPointUp.transform.position;
                //Vector3 pos = new Vector3(0f, 0f, 0f);
                // プレハブを指定位置に生成
                Instantiate(CubePrefab, spawn_pos_up, Quaternion.identity);
            break;

            case 1:
                Vector3 spawn_pos_right = SpawnPointRight.transform.position;
                //Vector3 pos = new Vector3(0f, 0f, 0f);
                // プレハブを指定位置に生成
                Instantiate(CubePrefab, spawn_pos_right, Quaternion.identity);
                break;

            case 2:
                Vector3 spawn_pos_down = SpawnPointDown.transform.position;
                //Vector3 pos = new Vector3(0f, 0f, 0f);
                // プレハブを指定位置に生成
                Instantiate(CubePrefab, spawn_pos_down, Quaternion.identity);
                break;

            case 3:
                Vector3 spawn_pos_left = SpawnPointLeft.transform.position;
                //Vector3 pos = new Vector3(0f, 0f, 0f);
                // プレハブを指定位置に生成
                Instantiate(CubePrefab, spawn_pos_left, Quaternion.identity);
                break;

            default:
                //処理Default
                Debug.Log("Default");
                Vector3 spawn_pos = SpawnPoint.transform.position;
                //Vector3 pos = new Vector3(0f, 0f, 0f);
                // プレハブを指定位置に生成
                Instantiate(CubePrefab, spawn_pos, Quaternion.identity);
                //break文
                break;
        }

        /*230929
        // 生成位置
        //Vector3 pos = new Vector3(5.0f, 10.0f, 0.0f);
        //Vector3 pos = new Vector3(-13.4994049f, -7.2f, 0f);
        Vector3 pos = SpawnPoint.transform.position;
        //Vector3 pos = new Vector3(0f, 0f, 0f);
        // プレハブを指定位置に生成
        Instantiate(CubePrefab, pos, Quaternion.identity);
        */
    }

    // Update is called once per frame
    void Update()
    {
        // 一定時間ごとにプレハブを生成
        if (Time.frameCount % 60 == 0)
        {

        }
    }
}