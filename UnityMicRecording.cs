using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Unityで録音し、メモリ上に保持した録音サウンドを再生するサンプルコード
/// OnGUIでデバッグボタンを表示しています
/// </summary>

public class UnityMicRecording : MonoBehaviour
{
    /// <summary>
    /// 録音するAudioClip
    /// </summary>
    private AudioClip _recordedClip;
    private TransmitterObject transmitterobject;
    /// <summary>
    /// 再生させるオーディオソース
    /// </summary>
    private AudioSource _audioSource;

    /// <summary>
    /// 録音機材名リスト
    /// </summary>
    private string mic;

    /// <summary>
    /// 録音に使用している機材名
    /// </summary>
    private string _recordingMicName;

    public static string _filepath;

    public readonly static List<string> filepath_list = new List<string>();
    void Start()
    {
        transmitterobject = GameObject.Find("TransmitterObject").GetComponent<TransmitterObject>();
        foreach (string device in Microphone.devices)
        {
            Debug.Log("DeviceName " + device);
        }
        mic = Microphone.devices[0];
        //Debug.Log(data.wavfilepass);
    }

    /// <summary>
    /// 録音機材名を指定して録音開始
    /// </summary>
    public void StartRecord()
    {
  
        _recordingMicName = mic;
        _recordedClip = Microphone.Start(mic, false, 10, 44100);

        Invoke(nameof(EndRecord), 5.0f);
        Invoke(nameof(PlayRecordedAudioClip), 5.1f);
        Invoke(nameof(Transmit), 8.0f);
    }

    /// <summary>
    /// 現在使用している機材の録音を停止
    /// </summary>
    public void EndRecord()
    {
        if (string.IsNullOrEmpty(_recordingMicName) == false && Microphone.IsRecording(_recordingMicName))
        {
            Microphone.End(_recordingMicName);
        }

        _recordingMicName = null;
        Debug.Log("Done!");
        SaveWavFile();
    }

    /// <summary>
    /// メモリ上に保持した録音したオーディオを再生
    /// </summary>
    public void PlayRecordedAudioClip()
    {
        _audioSource = gameObject.GetComponent<AudioSource>();
        if (_audioSource == null)
        {
            _audioSource = gameObject.AddComponent<AudioSource>();
        }

        _audioSource.clip = _recordedClip;
        _audioSource.Play();
    }
    //[SerializeField] WavFile scriptable;
    public void SaveWavFile()
    {
        string filepath;
        _audioSource = gameObject.GetComponent<AudioSource>();
        _audioSource.clip = _recordedClip;
        byte[] bytes = WavUtility.FromAudioClip(_audioSource.clip, out filepath, true);
        Debug.Log("Filepath: " + filepath);
        _filepath = filepath;
        filepath_list.Add(filepath);
        int i = 0;
        Debug.Log("filepath_list" + filepath_list[i]);
        i ++;
        //scriptable.wavfilepass = filepath;
        //data.wavfilepass = filepath;
        //Array.Resize(ref wfile, wfile.Length + 1);
        //wfile[wfile.Length - 1] = filepath;
        //Debug.Log(wfile[0]);
        //for(int i=0; i<wfile.Length; i++)
        {
            //Debug.Log("配列  " + wfile[i]);
        }
    }
    //[SerializeField]
    //WavFile data;
    void Update()
    {
        //data.wavfilepass = _filepath;
    }

    public void Transmit()
    {
        transmitterobject.isClicked();
    }

    
}
