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

        Debug.Log("Invoke�X�^�[�g");
        //2�b��ɃI�u�W�F�N�g������
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
        //�I���܂ő҂��Ăق�������������
        //��F�G���|���A�j���[�V�������J�n
        Debug.Log("�R���[�`���X�^�[�g");
        //2�b�҂�
        yield return new WaitForSeconds(2);

        //�ĊJ���Ă�����s����������������
        //��F�G�I�u�W�F�N�g��j��

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
