using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	[Header("制限時間")]
	[SerializeField]public float Timer = 180;

	[Header("タイマー")]
	[SerializeField]public Text TimerText;

	//ゲーム中かどうか
	public static bool IsGame;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//シーン遷移用ATフィールド
		DontDestroyOnLoad (this.gameObject);
		Timer -= Time.deltaTime * 1.0f;
		TimerText.GetComponent<Text>().text = ((int)Timer).ToString();
	}
}
