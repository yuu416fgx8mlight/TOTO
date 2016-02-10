using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpotLightItem : MonoBehaviour {

	public Image RightSpot;
	public Image LeftSpot;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter(Collider SpotItemGet){
		if (gameObject.tag == "LeftPlayer") {
			StartCoroutine ("LeftSpotItem");
		}
		if (gameObject.tag == "RightPlayer") {
			StartCoroutine ("RightSpotItam");
		}
	}

	//左側の塔でアイテムを取得した場合の処理
	public IEnumerator LeftSpotItem(){
		RightSpot.enabled = true;
		yield return new WaitForSeconds(10.0f);
		RightSpot.enabled = false;
	}

	//右側の塔でアイテムを取得した場合の処理
	public IEnumerator RightSpotItem(){
		LeftSpot.enabled = true;
		yield return new WaitForSeconds(10.0f);
		LeftSpot.enabled = false;
	}
}
