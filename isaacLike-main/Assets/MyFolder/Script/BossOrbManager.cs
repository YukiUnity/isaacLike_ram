using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BossOrbManager : MonoBehaviour
{

    public TextMeshProUGUI bossOrbText; //TextMeshProUGUI���Q��
    //public static int Score = 0;      //Score�̒l��0           public static�ɂ��邱�Ƃɂ���đ��̃X�N���v�g����Q�Ƃ��邱�Ƃ��o����
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        bossOrbText.text = "Boss Orb x " + simdata.bossOrb; //Scor�̍��v�l���e�L�X�g�ɕ\�� ScoreBoard.Score += 1;�𑼂̃X�N���v�g�ɒǉ������1�X�R�A�ǉ��ł���
    }
}
