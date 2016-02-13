using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

	public Transform Player1;
	public Transform Player2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Player1.position.y >= Player2.position.y) {
			this.transform.position = new Vector3 (transform.position.x, /*transform.position.y + */Player1.position.y+0.4f, transform.position.z);
		} else {
			this.transform.position = new Vector3 (transform.position.x, /*transform.position.y + */Player2.position.y+0.4f, transform.position.z);
		}
	}
}
