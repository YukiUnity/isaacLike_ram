using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterLevelManager : MonoBehaviour
{
    public TextMeshProUGUI characterLevelText; //TextMeshProUGUIを参照
    //public static int Score = 0;      //Scoreの値を0           public staticにすることによって他のスクリプトから参照することが出来る
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        characterLevelText.text = "Level " + simdata.characterLevel; //Scorの合計値をテキストに表示 ScoreBoard.Score += 1;を他のスクリプトに追加すると1スコア追加できる
    }
}
