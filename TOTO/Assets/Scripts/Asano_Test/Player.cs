using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

//    [SerializeField] Vector3 Npos = new Vector3(2,0,2);
//    [SerializeField] Vector3 Wpos = new Vector3(2,0,-2);
//    [SerializeField] Vector3 Spos = new Vector3(-2,0,-2);
//    [SerializeField] Vector3 Epos = new Vector3(-2,0,2);
    [SerializeField]Vector3 C_Croner = new Vector3(2,0,2);
    [SerializeField]Vector3 R_Corner=new Vector3(-2,0,2);
    [SerializeField]Vector3 L_Corner = new Vector3(2, 0, -2);

    public int Jump=3;
    /* pos_State 値
     * N-W 1
     * W-S 2
     * S-E 3
     * E-N 4
     */
    private int Cam_State;

    bool Jampable = true;
    bool turn = false;
    // Use this for initialization
	void Start () {
	}
	// Update is called once per frame
	void Update () {
        Vector3 pos=gameObject.transform.position;
        if (!turn)
        {
            //オーバーしたときの処理=========================================
            if (pos.x > C_Croner.x)
                gameObject.transform.position = new Vector3(C_Croner.x,pos.y,pos.z);
            if (pos.x < R_Corner.x)
                gameObject.transform.position = new Vector3(R_Corner.x, pos.y, pos.z);
            if (pos.z < L_Corner.z)
                gameObject.transform.position = new Vector3(pos.x, pos.y, L_Corner.z);
            if (pos.z > C_Croner.z)
                gameObject.transform.position = new Vector3(pos.x, pos.y, C_Croner.z);
            //===============================================================

            //移動処理=======================================================
            if (pos.x <= C_Croner.x && pos.z == C_Croner.z && pos.x >= R_Corner.x)
            {
                transform.position += new Vector3(-Input.GetAxis("Horizontal") / 15, 0, 0);
            }
            if(pos.z<=C_Croner.z&&pos.x==C_Croner.x&&pos.z>=L_Corner.z)
            {
                transform.position += new Vector3(0,0,Input.GetAxis("Horizontal")/15);
            }
            if (pos.x == C_Croner.x && pos.z == C_Croner.z)
            {
                if (Input.GetAxis("Horizontal") < 0)
                    transform.position += new Vector3(-Input.GetAxis("Horizontal") / 15, 0, 0);
                else
                    transform.position += new Vector3(0, 0,Input.GetAxis("Horizontal") / 15);
            }
            //===============================================================

            if (Jampable && (Input.GetAxis("Jump") != 0))
            {
                Jampable = false;
                gameObject.GetComponent<Rigidbody>().AddForce(0, Jump, 0, ForceMode.Impulse);
            }
        }
	}

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name=="Ground")
        Jampable = true;
    }
}
