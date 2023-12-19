using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetroRabbitBossLeftGunDeathFeedBack : MonoBehaviour
{
    // Inspector
    [SerializeField] private GameObject testObject;

    public void isRetroRabbitBossLeftGunDeath()
    {
        simdata.Score += 50;
        simdata.isLeftGunDeath = true;

        if (simdata.isRightGunDeath)
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
