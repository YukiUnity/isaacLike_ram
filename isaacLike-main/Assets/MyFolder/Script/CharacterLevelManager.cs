using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterLevelManager : MonoBehaviour
{
    public TextMeshProUGUI characterLevelText; //TextMeshProUGUI���Q��
    //public static int Score = 0;      //Score�̒l��0           public static�ɂ��邱�Ƃɂ���đ��̃X�N���v�g����Q�Ƃ��邱�Ƃ��o����
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        characterLevelText.text = "Level " + simdata.characterLevel; //Scor�̍��v�l���e�L�X�g�ɕ\�� ScoreBoard.Score += 1;�𑼂̃X�N���v�g�ɒǉ������1�X�R�A�ǉ��ł���
    }
}
