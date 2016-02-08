using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
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
    int Cam_State;
    float rot_Y;

    bool Jampable = true;
    bool turn_ = false;
    bool Isrunning=false;

    GameObject Wall;
    // Use this for initialization
	void Start () {
        Wall = GameObject.Find("Wall");
	}
	// Update is called once per frame
	void Update () {
        Vector3 pos=gameObject.transform.position;
        if (!turn_)
        {
            //プレイヤーを手前の2面にとどめる処理============================
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
                Cam_State = 1;

            }
            if(pos.z<=C_Croner.z&&pos.x==C_Croner.x&&pos.z>=L_Corner.z)
            {
                transform.position += new Vector3(0,0,Input.GetAxis("Horizontal")/15);
                Cam_State = 2;
            }
            if (pos.x == C_Croner.x && pos.z == C_Croner.z)
            {
                if (Input.GetAxis("Horizontal") < 0)
                    transform.position += new Vector3(-Input.GetAxis("Horizontal") / 15, 0, 0);
                else
                    transform.position += new Vector3(0, 0,Input.GetAxis("Horizontal") / 15);
            }
            //===============================================================

            //回転処理=======================================================
            if (Input.GetAxis("R1") != 0&&Cam_State==2)
            {
                Debug.Log("R1");
                StartCoroutine("turn",-1);
            } 
            if (Input.GetAxis("L1") != 0 && Cam_State == 1)
            {
                Debug.Log("L1");
                StartCoroutine("turn",1);
            }
            //===============================================================

            //ジャンプ=======================================================
            if (Jampable && (Input.GetAxis("Jump") != 0))
            {
                Jampable = false;
                gameObject.GetComponent<Rigidbody>().AddForce(0, Jump, 0, ForceMode.Impulse);
            }
            //===============================================================
        }
	}
    //回転実行部分====================================================
    IEnumerator turn(int i)
    {
        if (Isrunning)
            yield break;
        else 
        {
            transform.parent = Wall.transform;
            Isrunning = true;
            turn_ = true;
            for (int j = 0; j < 30; j++)
            {
                Wall.transform.Rotate(0,3*i,0);
                Debug.Log(j);
                yield return null;
            }
            transform.parent = null;
            turn_ = false;
            yield return null;
            Isrunning = false;
        }
    }
    //================================================================

    //ジャンプの回復処理==============================================
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name=="Ground")
        Jampable = true;
    }
    //================================================================
}
