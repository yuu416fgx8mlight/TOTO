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
		GetComponent<Renderer>().enabled = false;
		GetComponent<BoxCollider> ().enabled = false;
		for (i=1;i<20;i++) {
			Instantiate (Rocks, new Vector3 (RightTarget.position.x, RightTarget.position.y + 1, RightTarget.position.z), Quaternion.identity);
			yield return new WaitForSeconds (0.5f);
		}
		Destroy (gameObject);
	}

	public IEnumerator RightRockItem(){
		GetComponent<Renderer>().enabled = false;
		GetComponent<BoxCollider> ().enabled = false;
		for (i=1;i<20;i++) {
			Instantiate (Rocks, new Vector3 (LeftTarget.position.x, LeftTarget.position.y + 1, LeftTarget.position.z), Quaternion.identity);
			yield return new WaitForSeconds (0.5f);
		}
		Destroy (gameObject);
	}
}
