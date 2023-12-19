using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeButtonClick : MonoBehaviour
{

    /// <summary>セーブデータ。</summary>
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

        // 保存するデータを作成
        var data = new SaveData()
        {
            saveBossOrb = simdata.bossOrb,
            saveCharacterLevel = simdata.characterLevel,
        };

        // オブジェクトを JSON 文字列にシリアライズ
        var json = JsonUtility.ToJson(data);

        // 所定の場所にテキストファイルとして保存
        File.WriteAllText(Path.Combine(Application.persistentDataPath, "SaveData.txt"), json);

        Debug.Log("保存しました。");

        SceneManager.LoadScene("Home");
    }

}
