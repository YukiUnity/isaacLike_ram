using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ESCButtonPressed : MonoBehaviour
{

    /// <summary>セーブデータ。</summary>
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
                UnityEditor.EditorApplication.isPlaying = false;   // UnityEditorの実行を停止する処理
            #else
                Application.Quit();                                // ゲームを終了する処理
            #endif
            */

            //231123
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


            simdata.isFinished = true;
            SceneManager.LoadScene("Home");
        }
    }
}
