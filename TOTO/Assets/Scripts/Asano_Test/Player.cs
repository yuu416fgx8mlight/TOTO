using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    [SerializeField]Vector3 C_Corner = new Vector3(2,0,2);
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
    float pos_num=0;
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
            //プレイヤーの移動処理===========================================
            pos_num += Input.GetAxis("Horizontal")/45;
            if (pos_num > 1)
                pos_num = 1;
            else if (pos_num < -1)
                pos_num = -1;
            if (pos_num < 0 && pos_num > -1)
            {
                gameObject.transform.position = new Vector3(C_Corner.x, pos.y, C_Corner.z + (C_Corner.z - L_Corner.z) * pos_num);
                Cam_State = 2;
            }
            else if (pos_num <= -1)
            {
                gameObject.transform.position = new Vector3(L_Corner.x, pos.y, L_Corner.z);
                Cam_State = 2;
            }
            else if (pos_num > 0 && pos_num < 1)
            {
                gameObject.transform.position = new Vector3(C_Corner.x - (C_Corner.x - R_Corner.x) * pos_num, pos.y, C_Corner.z);
                Cam_State = 1;
            }
            else if (pos_num >= 1)
            {
                gameObject.transform.position = new Vector3(R_Corner.x, pos.y, R_Corner.z);
                Cam_State = 1;
            }
            else
            {
                gameObject.transform.position = new Vector3(C_Corner.x, pos.y, C_Corner.z);
                Cam_State = 0;
            }

            //===============================================================
            //回転処理=======================================================
            if (Input.GetAxis("R1") != 0&&Cam_State==2)
            {
                Debug.Log("R1");
                StartCoroutine("turn",-1);
                pos_num = pos_num + 1;
            } 
            if (Input.GetAxis("L1") != 0 && Cam_State == 1)
            {
                Debug.Log("L1");
                StartCoroutine("turn", 1);
                pos_num = pos_num - 1;
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
            //pos_num *= -1;
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
