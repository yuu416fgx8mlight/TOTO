using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    [SerializeField]Vector3 C_Corner;
    [SerializeField]Vector3 R_Corner;
    [SerializeField]Vector3 L_Corner;

    public float Jump;  
    public int H_Jamp;

    int Cam_State;
    float pos_num=0;
    float rot_Y;

    int High_Jamp = 0;

    public static bool Jampable = true;
    bool turn_ = false;
    bool Isrunning=false;
    Vector3 pos_;
    [SerializeField]GameObject Wall;
    // Use this for initialization
	void Start () {
        Wall = GameObject.Find("tou"+gameObject.name);
        pos_ = this.gameObject.transform.position;

	}
	// Update is called once per frame
	void Update () {
        Vector3 pos=this.gameObject.transform.position;
        if (!turn_)
        {
            //プレイヤーの移動処理===========================================
            pos_num += Input.GetAxis("Horizontal"+gameObject.name)/45;
            if (this.pos_num > 1)
            {
                pos_num = 1;
            }
            else if (pos_num < -1)
                pos_num = -1;
            //===============================================================
            if (this.pos_num < 0 && pos_num > -1)
            {
                this.gameObject.transform.localPosition = new Vector3(C_Corner.x, pos.y, C_Corner.z + (C_Corner.z - L_Corner.z) * pos_num);
                Cam_State = 2;
            }
            else if (pos_num <= -1)
            {
                this.gameObject.transform.localPosition = new Vector3(L_Corner.x, pos.y, L_Corner.z);
                Cam_State = 2;
            }
            else if (pos_num > 0 && pos_num < 1)
            {
                this.gameObject.transform.localPosition = new Vector3((C_Corner.x - (C_Corner.x - R_Corner.x) * pos_num), pos.y, C_Corner.z);
                Cam_State = 1;
            }
            else if (pos_num >= 1)
            {
                this.gameObject.transform.localPosition = new Vector3(R_Corner.x, pos.y, R_Corner.z);
                Cam_State = 1;
            }
            else
            {
                this.gameObject.transform.localPosition = new Vector3(C_Corner.x, pos.y, C_Corner.z);
                Cam_State = 0;
            }

            //===============================================================

            //回転処理=======================================================
            if (Input.GetAxis("L" + gameObject.name) != 0 && Cam_State == 2)
            {
//                Debug.Log("R1");
                StartCoroutine("turn",-1);
            }
            if (Input.GetAxis("R" + gameObject.name) != 0 && Cam_State == 1)
            {
//                Debug.Log("L1");
                StartCoroutine("turn", 1);
            }
            //===============================================================

            //ジャンプ=======================================================
            if (Jampable && (Input.GetAxis("Jump" + gameObject.name) != 0))
            {
                
                    Jampable = false;
                    this.gameObject.GetComponent<Rigidbody>().AddForce(0, Jump/5, 0, ForceMode.Impulse);
                
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
            for (int j = 0; j < 15; j++)
            {
                Wall.transform.Rotate(0,6*i,0);
//                Debug.Log(j);
                yield return null;
            }
            transform.parent = null;
            pos_num -= i;
            yield return null;
            turn_ = false;
            Isrunning = false;
        }
    }
    //================================================================

    //ジャンプの回復処理==============================================
    void OnCollisionEnter(Collision col)
    {
        this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        switch (col.gameObject.tag)
        {
            case "Ground":
                Jampable = true;
                break;
            case "ItemA":
                break;
        }
    }
    //================================================================
}
