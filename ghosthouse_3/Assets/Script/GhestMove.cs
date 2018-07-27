using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhestMove : MonoBehaviour {

    public GameObject EyeSight;
    public int MoveCondition = 1; //방향을 나타내는 변수
    public float ContectTime = 0f; //타일을 밟았을때 움직임을 더 매끄럽게 하기위한 시간변수
    public float CheckTime; //그 시간을 비교하기 위한 랜덤변수

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        TileCheck();
        GhestMovement();
	}

    public void TileCheck()
    {
        RaycastHit hit = new RaycastHit();
        //if(Physics.BoxCast(this.transform.position, this.transform.lossyScale, this.transform.forward, out hit, Quaternion.identity, 100f))
        if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, 100f))
        {
            //Debug.Log(hit.collider.tag);
            if (hit.collider.tag == "Down")
            {
                ContectTime += Time.deltaTime;
                if (CheckTime == 0) { CheckTime = Random.Range((float)0.3, (float)0.6); }
                
                if (ContectTime >= CheckTime)
                {
                    MoveCondition = 0;
                    EyeSight.transform.rotation = Quaternion.Euler(0, 0, 180);
                }               
            }
            if (hit.collider.tag == "Up")
            {
                ContectTime += Time.deltaTime;
                if (CheckTime == 0) { CheckTime = Random.Range((float)0.3, (float)0.6); }
                if (ContectTime >= CheckTime)
                {
                    MoveCondition = 1;
                    EyeSight.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
            }
            if (hit.collider.tag == "Right")
            {
                ContectTime += Time.deltaTime;
                if (CheckTime == 0) { CheckTime = Random.Range((float)0.3, (float)0.6); }
                if (ContectTime >= CheckTime)
                {
                    MoveCondition = 2;
                    EyeSight.transform.rotation = Quaternion.Euler(0, 0, 270);
                }
            }
            if (hit.collider.tag == "Left")
            {
                ContectTime += Time.deltaTime;
                if (CheckTime == 0) { CheckTime = Random.Range((float)0.3, (float)0.6); }
                if (ContectTime >= CheckTime)
                {
                    MoveCondition = 3;
                    EyeSight.transform.rotation = Quaternion.Euler(0, 0, 90);
                }
            }
            if (hit.collider.tag == "Road")
            {
                ContectTime = 0;
                CheckTime = 0;
            }
        }
    }

    public void GhestMovement()
    {
        if (MoveCondition == 0)
        {
            this.transform.Translate(Vector3.down * Time.smoothDeltaTime);
        }
        if (MoveCondition == 1)
        {
            this.transform.Translate(Vector3.up * Time.smoothDeltaTime);
        }
        if (MoveCondition == 2)
        {
            this.transform.Translate(Vector3.right * Time.smoothDeltaTime);
        }
        if (MoveCondition == 3)
        {
            this.transform.Translate(Vector3.left * Time.smoothDeltaTime);
        }
    }

    public void GhostCheck()
    {
        RaycastHit hitinfo = new RaycastHit();
        //if(Physics.BoxCast(EyeSight.transform.position, EyeSight.transform.lossyScale/2, 
        //    EyeSight.transform.up, out hitinfo, EyeSight.transform.rotation, 3f))
        if(Physics.Raycast(EyeSight.transform.position, EyeSight.transform.forward, out hitinfo, 3f))
        {
            Debug.Log(hitinfo.collider.tag);
            if (hitinfo.collider.tag == "Ghost")
            {
                Debug.Log("1");
            }
        }
    }
}
