using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetroRabbitBossRightGunDeathFeedBack : MonoBehaviour
{
    public void isRetroRabbitBossRightGunDeath()
    {
        simdata.Score += 50;
        simdata.isRightGunDeath = true;

        if (simdata.isLeftGunDeath)
        {
            // ゲームオブジェクトのレイヤーを変更する
            simdata.BossGameObject.layer = 13;
        }
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
