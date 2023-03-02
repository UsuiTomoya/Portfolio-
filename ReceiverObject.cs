using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using extOSC; // これを忘れずに
using System.Threading.Tasks;

public class ReceiverObject : MonoBehaviour
{
	public OSCReceiver receiver;  // 受信するやつ
	[HideInInspector]
	public static float similary;
	public string stuffname;
	public static int stuffnumber;
	//public float step_time;
	void Start()
	{
		receiver.Bind("/path_PtoU", OnReceivedMessage);  // 受信イベント関数の登録
		DontDestroyOnLoad(this);
	}

	void Update()
	{
		
	}

	// 受信イベント関数
	public static void OnReceivedMessage(OSCMessage message)
	{
		Debug.Log(message); // 受信したOSCメッセージを表示する
		
		// OSCメッセージからのデータの取り出し
		//int    data0 = message.Values[0].IntValue;    // 0番目のint型データを取得
		//int    data1 = message.Values[1].IntValue;    // 1番目のint型データを取得
		//int    data2 = message.Values[2].IntValue;    // 2番目のint型データを取得
		float  data1 = message.Values[0].FloatValue;  // 1番目のfloat型データを取得
		string data2 = message.Values[1].StringValue; // 2番目のstring型データを取得

		//Debug.Log(data1);
		//Debug.Log("data2 => " + data2);
		
		similary = data1;
		string stuffname = data2;
		//Debug.Log("similary => " + similary);
		//Debug.Log(stuffname);
		//道具の名前の文字列
		string strA = "steel wool";
		string strB = "sudare";
		string strC = "chopstick";
		string strD = "stapler";
		string strE = "glove";
		//
		if(data2.Equals(strA))
		{
			stuffnumber = 1;
		}
		else if(data2.Equals(strB))
		{
			stuffnumber = 2;
		}
		else if(data2.Equals(strC))
		{
			stuffnumber = 3;
		}
		else if(data2.Equals(strD))
		{
			stuffnumber = 4;
		}
		else if(data2.Equals(strE))
		{
			stuffnumber = 5;
		}
		//Debug.Log("stuffnumber => " + stuffnumber);

		
		//データの取得が完了したら次のページにシーンを移す
		Scene scene = SceneManager.GetActiveScene();	//現在のScene名の取得
		
		{
			if(scene.name == "Challenge#1")
			{
				SceneManager.LoadScene("C#1Answer");
			    //SceneManager.LoadScene("Challenge#2");
            }
	        else if(scene.name == "Challenge#2")
	    	{
		    	SceneManager.LoadScene("C#2Answer");
	    	}
	    	else if(scene.name == "Challenge#3")
	    	{
	    		SceneManager.LoadScene("C#3Answer");
	    	}
			else if(scene.name == "Challenge#4")
	    	{
	    		SceneManager.LoadScene("C#4Answer");
	    	}
			else if(scene.name == "Challenge#5")
	    	{
	    		SceneManager.LoadScene("C#5Answer");
	    	}
		}
		
	
	}

	public static float Similary()
	{
		Debug.Log( "return => " + similary);
		return similary;
	}

	public static int Stuffnumber()
	{
		Debug.Log( "return STnumber => " + stuffnumber);
		return stuffnumber;
	}
	
}
