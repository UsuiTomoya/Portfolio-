using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavFileRead : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] WavFile scriptable;
    //WavFile data;
    void Start()
    {
        foreach (string path in UnityMicRecording.filepath_list)
        {
            //Debug.Log("Read " + path);
        }
       // Debug.Log("データの方　" + scriptable.wavfilepass);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
