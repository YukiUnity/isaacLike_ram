using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class HomeInitialize : MonoBehaviour
{
    /// <summary>�Z�[�u�f�[�^�B</summary>
    public class SaveData
    {
        public int saveBossOrb;
        public int saveCharacterLevel;
    }

    // Start is called before the first frame update
    void Start()
    {
        simdata.createmazeflag = 0;
        simdata.isExitTrue = false;
        simdata.EntryPoint = 4;

        //231006
        simdata.Score = 0;

        //231010
        simdata.isFinished = false;
        simdata.CurrentTime = 0;

        //231112
        if (simdata.BossGameObject != null)
        {
            simdata.BossGameObject.layer = 12;
        }

        //231123
        /*if (PlayerPrefs.HasKey("bossOrb"))
        {
            // ���݂���
            simdata.bossOrb = PlayerPrefs.GetInt("bossOrb", 0);
        }
        if (PlayerPrefs.HasKey("characterLevel"))
        {
            // ���݂���
            simdata.characterLevel = PlayerPrefs.GetInt("characterLevel", 1);
        }*/

        /// <summary>
        /// �ǂݍ��݃{�^�����N���b�N�����Ƃ��̏����B
        /// </summary>
        // �ۑ�����Ă���e�L�X�g�t�@�C����ǂݍ���
        var json = File.ReadAllText(Path.Combine(Application.persistentDataPath, "SaveData.txt"));

        // JSON �e�L�X�g����w�肵���I�u�W�F�N�g�Ƀf�V���A���C�Y
        var data = JsonUtility.FromJson<SaveData>(json);

        // �ǂݍ��񂾒l���e�t�B�[���h�ɃZ�b�g
        simdata.bossOrb = data.saveBossOrb;
        simdata.characterLevel = data.saveCharacterLevel;

        Debug.Log("�ǂݍ��݂܂����B");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
