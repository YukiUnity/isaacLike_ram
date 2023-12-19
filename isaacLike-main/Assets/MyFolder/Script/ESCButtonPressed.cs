using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ESCButtonPressed : MonoBehaviour
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
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //231021
            /*
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;   // UnityEditor�̎��s���~���鏈��
            #else
                Application.Quit();                                // �Q�[�����I�����鏈��
            #endif
            */

            //231123
            // �ۑ�����f�[�^���쐬
            var data = new SaveData()
            {
                saveBossOrb = simdata.bossOrb,
                saveCharacterLevel = simdata.characterLevel,
            };

            // �I�u�W�F�N�g�� JSON ������ɃV���A���C�Y
            var json = JsonUtility.ToJson(data);

            // ����̏ꏊ�Ƀe�L�X�g�t�@�C���Ƃ��ĕۑ�
            File.WriteAllText(Path.Combine(Application.persistentDataPath, "SaveData.txt"), json);

            Debug.Log("�ۑ����܂����B");


            simdata.isFinished = true;
            SceneManager.LoadScene("Home");
        }
    }
}
