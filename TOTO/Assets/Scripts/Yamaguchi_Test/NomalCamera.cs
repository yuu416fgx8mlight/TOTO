using UnityEngine;
using System.Collections;

public class NomalCamera : MonoBehaviour {

	public Transform targetP;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector3 (transform.position.x, targetP.position.y + 0.4f, transform.position.z);
	}
}
