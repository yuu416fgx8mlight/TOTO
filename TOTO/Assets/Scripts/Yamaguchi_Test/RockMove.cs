using UnityEngine;
using System.Collections;

public class RockMove : MonoBehaviour {

	[Header("落下の力")]
	[SerializeField]public float RockFall = 0.01f;

	// Use this for initialization
	void Start () {
		StartCoroutine ("DestroyRock");
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (transform.position.x, transform.position.y - RockFall, transform.position.z);
	}

	public IEnumerator DestroyRock(){
		yield return new WaitForSeconds (5.0f);
		Destroy (gameObject);
	}
}
