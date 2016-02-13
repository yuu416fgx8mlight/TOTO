using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	[Header("制限時間")]
	[SerializeField]public float Timer = 180;

	//ゲーム中かどうか
	public static bool IsGame;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		DontDestroyOnLoad (this.gameObject);
	}
}
