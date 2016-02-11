using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	[Header("制限時間")]
	[SerializeField]public float Timer = 180;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		DontDestroyOnLoad (this.gameObject);
	}
}
