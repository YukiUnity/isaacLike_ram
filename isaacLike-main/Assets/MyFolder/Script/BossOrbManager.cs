using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BossOrbManager : MonoBehaviour
{

    public TextMeshProUGUI bossOrbText; //TextMeshProUGUIを参照
    //public static int Score = 0;      //Scoreの値を0           public staticにすることによって他のスクリプトから参照することが出来る
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        bossOrbText.text = "Boss Orb x " + simdata.bossOrb; //Scorの合計値をテキストに表示 ScoreBoard.Score += 1;を他のスクリプトに追加すると1スコア追加できる
    }
}
