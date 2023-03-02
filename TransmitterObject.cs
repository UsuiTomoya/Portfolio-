using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using extOSC;	// これを入れるのを忘れずに

public class TransmitterObject : MonoBehaviour
{
    public OSCTransmitter transmitter;	// 送信するやつ
    public bool flag;

    void Start()
    {
        flag = false;
    }

    void Update()
    {
        if(flag)
        {
            Debug.Log(flag);
            OSCMessage message = new OSCMessage("/path_UtoP");   // OSCメッセージの作成
            message.AddValue(OSCValue.String(UnityMicRecording._filepath)); // string型データを追加
            transmitter.Send(message);                      // OSCメッセージの送信
            flag = false;
        }
    }

    public void isClicked()
    {
        flag = true;
    }
}