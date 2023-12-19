using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public TextMeshProUGUI ScoreText; //TextMeshProUGUIを参照
    //public static int Score = 0;      //Scoreの値を0           public staticにすることによって他のスクリプトから参照することが出来る
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "Score: " + simdata.Score; //Scorの合計値をテキストに表示 ScoreBoard.Score += 1;を他のスクリプトに追加すると1スコア追加できる
    }
}
