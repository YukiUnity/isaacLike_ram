using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public TextMeshProUGUI ScoreText; //TextMeshProUGUI���Q��
    //public static int Score = 0;      //Score�̒l��0           public static�ɂ��邱�Ƃɂ���đ��̃X�N���v�g����Q�Ƃ��邱�Ƃ��o����
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "Score: " + simdata.Score; //Scor�̍��v�l���e�L�X�g�ɕ\�� ScoreBoard.Score += 1;�𑼂̃X�N���v�g�ɒǉ������1�X�R�A�ǉ��ł���
    }
}
