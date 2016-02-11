using UnityEngine;
using System.Collections;

public class TourMover : MonoBehaviour {

	public GameObject PlayerPos;
	public float JumpPoint;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (transform.position.x, transform.position.y + JumpPoint, transform.position.z);

		//Debug.Log (JumpPoint);

		if (Input.GetButtonDown("Jump1"))
		{
			if (Player.Jampable == true) {
				StartCoroutine ("Jumping");
			}
		}
	}

	public IEnumerator Jumping(){
		JumpPoint -= 0.01f;
		yield return new WaitForSeconds (0.01f);
		JumpPoint -= 0.01f;
		yield return new WaitForSeconds (0.01f);
		JumpPoint -= 0.01f;
		yield return new WaitForSeconds (0.01f);
		JumpPoint -= 0.01f;
		yield return new WaitForSeconds (0.01f);
		JumpPoint -= 0.01f;
		yield return new WaitForSeconds (0.01f);
		JumpPoint += 0.02f;
		yield return new WaitForSeconds (0.01f);
		JumpPoint += 0.02f;
		yield return new WaitForSeconds (0.01f);
		JumpPoint += 0.02f;
		yield return new WaitForSeconds (0.01f);
		JumpPoint += 0.02f;
		yield return new WaitForSeconds (0.01f);
		JumpPoint += 0.02f;
		yield return new WaitForSeconds (0.01f);
		JumpPoint -= 0.01f;
		yield return new WaitForSeconds (0.01f);
		JumpPoint -= 0.01f;
		yield return new WaitForSeconds (0.01f);
		JumpPoint -= 0.01f;
		yield return new WaitForSeconds (0.01f);
		JumpPoint -= 0.01f;
		yield return new WaitForSeconds (0.01f);
		JumpPoint -= 0.01f;
		yield return new WaitForSeconds (0.01f);
	}
}
