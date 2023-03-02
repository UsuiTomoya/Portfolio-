using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordText : MonoBehaviour
{
    public Text Textfield;

    public void setText(string text)
    {
        Textfield.text = text;
    }
}
 