using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CubeGameUI : MonoBehaviour
{
    public TextMeshProUGUI TimerText;    //UI����
    public float Timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        TimerText.text = "�����ð� : " + Timer.ToString("0.00");
    }
}
