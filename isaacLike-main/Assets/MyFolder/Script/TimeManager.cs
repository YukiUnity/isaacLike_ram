using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    //[SerializeField]
    //private GameManager gameManager;
    //private float currentTime;
    public TextMeshProUGUI CurrentTimeText; //TextMeshProUGUI���Q��
    //private Text fastestTimeText;
    private static float fastestTime = 999.999f;

    // Start is called before the first frame update
    void Start()
    {
        //currentTimeText = transform.Find("CurrentTimeText").GetComponent<Text>();
        //�@�ő��^�C����\��
        //fastestTimeText = transform.Find("FastestTimeText").GetComponent<Text>();
        //fastestTimeText.text = fastestTime.ToString("0.000");
    }

    // Update is called once per frame
    void Update()
    {
        //�@�S�[�����Ă��Ȃ���Ύ��Ԃ��v��
        if (!simdata.isFinished)
        {
            simdata.CurrentTime += Time.deltaTime;
            //CurrentTimeText.text = simdata.CurrentTime.ToString("Time: " + "0.000");
        }
        CurrentTimeText.text = simdata.CurrentTime.ToString("Time: " + "0.000");
    }

    //�@�ō��^�C���̍X�V
    public void UpdateFastestTime()
    {
        if (simdata.CurrentTime < fastestTime)
        {
            fastestTime = simdata.CurrentTime;
        }
    }
}