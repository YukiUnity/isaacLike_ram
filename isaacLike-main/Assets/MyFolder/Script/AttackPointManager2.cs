using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AttackPointManager2 : MonoBehaviour
{
    public TextMeshProUGUI AttackPointText; //TextMeshProUGUI���Q��
    //public static int Score = 0;      //Score�̒l��0           public static�ɂ��邱�Ƃɂ���đ��̃X�N���v�g����Q�Ƃ��邱�Ƃ��o����
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        int AttackPoint = 10 * simdata.characterLevel - 10;
        AttackPointText.text = "Attack Point + " + AttackPoint; //Scor�̍��v�l���e�L�X�g�ɕ\�� ScoreBoard.Score += 1;�𑼂̃X�N���v�g�ɒǉ������1�X�R�A�ǉ��ł���
    }
}
