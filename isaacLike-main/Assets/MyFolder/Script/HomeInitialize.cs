using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class HomeInitialize : MonoBehaviour
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
            // 存在する
            simdata.bossOrb = PlayerPrefs.GetInt("bossOrb", 0);
        }
        if (PlayerPrefs.HasKey("characterLevel"))
        {
            // 存在する
            simdata.characterLevel = PlayerPrefs.GetInt("characterLevel", 1);
        }*/

        /// <summary>
        /// 読み込みボタンをクリックしたときの処理。
        /// </summary>
        // 保存されているテキストファイルを読み込む
        var json = File.ReadAllText(Path.Combine(Application.persistentDataPath, "SaveData.txt"));

        // JSON テキストから指定したオブジェクトにデシリアライズ
        var data = JsonUtility.FromJson<SaveData>(json);

        // 読み込んだ値を各フィールドにセット
        simdata.bossOrb = data.saveBossOrb;
        simdata.characterLevel = data.saveCharacterLevel;

        Debug.Log("読み込みました。");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
