using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeButtonClick : MonoBehaviour
{

    /// <summary>�Z�[�u�f�[�^�B</summary>
    public class SaveData
    {
        public int saveBossOrb;
        public int saveCharacterLevel;
    }

    public void OnClickHomeButton()
    {
        //231123
        /*PlayerPrefs.SetInt("bossOrb", simdata.bossOrb);
        PlayerPrefs.SetInt("characterLevel", simdata.characterLevel);
        PlayerPrefs.Save();*/

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

        SceneManager.LoadScene("Home");
    }

}
