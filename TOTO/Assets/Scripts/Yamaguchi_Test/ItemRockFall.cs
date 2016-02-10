using UnityEngine;
using System.Collections;

public class ItemRockFall : MonoBehaviour {

	public Transform LeftTarget;
	public Transform RightTarget;
	public GameObject Rocks;

	private int i;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTriggerEnter(Collider RockItemGet){
		if (RockItemGet.gameObject.tag == "LeftPlayer") {
			StartCoroutine ("LeftRockItem");
		}
		if (RockItemGet.gameObject.tag == "RightPlayer") {
			StartCoroutine ("RightRockItam");
		}
	}

	public IEnumerator LeftRockItem(){
		for (i=1;i<10;i++) {
			Instantiate (Rocks, new Vector3 (RightTarget.position.x, RightTarget.position.y + 10, RightTarget.position.z), Quaternion.identity);
			yield return new WaitForSeconds (0.5f);
		}
		Destroy (gameObject);
	}

	public IEnumerator RightRockItem(){
		for (i=1;i<10;i++) {
			Instantiate (Rocks, new Vector3 (LeftTarget.position.x, LeftTarget.position.y + 10, LeftTarget.position.z), Quaternion.identity);
			yield return new WaitForSeconds (0.5f);
		}
		Destroy (gameObject);
	}
}
