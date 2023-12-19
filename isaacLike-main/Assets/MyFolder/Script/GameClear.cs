using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameClear : MonoBehaviour
{
    public void isBossDeath()
    {
        //StartCoroutine("bossDeathDelay");

        Debug.Log("Invokeスタート");
        //2秒後にオブジェクトを消す
        Invoke("bossDeath", 2);


    }

    void bossDeath()
    {
        //231010
        simdata.isFinished = true;

        simdata.Score += 300;

        //231122
        simdata.bossOrb += 1;

        SceneManager.LoadScene("GameClear");
    }

    IEnumerator bossDeathDelay()
    {
        //終わるまで待ってほしい処理を書く
        //例：敵が倒れるアニメーションを開始
        Debug.Log("コルーチンスタート");
        //2秒待つ
        yield return new WaitForSeconds(2);

        //再開してから実行したい処理を書く
        //例：敵オブジェクトを破壊

        //231010
        simdata.isFinished = true;

        simdata.Score += 300;

        //231122
        simdata.bossOrb += 1;

        SceneManager.LoadScene("GameClear");
    }

    void Update()
    {
        /*if(simdata.isFinished)
        {
            StartCoroutine(bossDeathDelay());
        }*/
    }
}
