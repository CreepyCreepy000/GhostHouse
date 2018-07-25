using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMove : MonoBehaviour {

    //public Vector3 RandomPoint;
    public Vector3 TargetPosition; //처음 생성 위치 저장
    public GameObject Checkpoint; //벽인지 길인지 판단할 오브젝트
    public int moveDirection = 0; //방향을 나타내는 변수
    public int moveRotation = 0; //회전을 나타내는 변수

	// Use this for initialization
	void Start () {
        //RandomPoint.x = Random.Range(-1, 1);
        //RandomPoint.y = Random.Range(-1, 1);
        TargetPosition = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        //G_Way();
        G_Move();
        //MoveCheck();
        //test1();
        //Debug.Log(this.transform.rotation.y);
	}

    public void G_Move()
    {
        if (this.transform.position.x <= TargetPosition.x - 1)
        {
            moveRotation = 1;
        }
        if (this.transform.position.x >= TargetPosition.x + 1)
        {
            moveRotation = 1;
        }
        if (moveRotation == 1)
        {
            this.transform.Rotate(0, 180, 0);
            Checkpoint.transform.Rotate(0, 180, 0);
            moveRotation = 0;
        }

        this.transform.Translate(Vector3.left * Time.smoothDeltaTime);
        RaycastHit hitinfo = new RaycastHit();
        if (Physics.Raycast(Checkpoint.transform.position, Checkpoint.transform.forward, out hitinfo, 100f))
        {
            if (hitinfo.collider.tag != "Road")
            {
                moveRotation = 1;

            }
        }
    }

    //public void G_Move1()
    //{
    //    this.transform.Translate(Vector3.left * Time.smoothDeltaTime);
    //    if (moveDirection == 1/* || moveDirection == 0*/)
    //    {
    //        //this.transform.Translate(Vector3.left * Time.smoothDeltaTime);
    //        this.transform.rotation = Quaternion.Euler(0, 180, 0);
    //    }
    //    if (moveDirection == 2)
    //    {
    //        //this.transform.Translate(Vector3.right * Time.smoothDeltaTime);
    //        this.transform.rotation = Quaternion.Euler(0, 0, 0);
    //    }
    //}

    //public void test1()
    //{
    //    if(this.transform.rotation.y == 180)
    //    {
    //        Debug.Log("180");
    //    }
    //    if (this.transform.rotation.y == 0)
    //    {
    //        Debug.Log("0");
    //    }
    //}

    //public void G_Way()
    //{
    //    if (this.transform.position.x <= TargetPosition.x - 1)
    //    {
    //        moveRotation = 1;
    //    }
    //    if (this.transform.position.x >= TargetPosition.x + 1)
    //    {
    //        moveRotation = 1;
    //    }
    //    if (moveRotation == 1)
    //    {
    //        this.transform.Rotate(0, 180, 0);
    //        Checkpoint.transform.Rotate(0, 180, 0);
    //        moveRotation = 0;
    //    }

    //}

    //public void MoveCheck()
    //{
    //    this.transform.Translate(Vector3.left * Time.smoothDeltaTime);
    //    RaycastHit hitinfo = new RaycastHit();

    //    if (moveDirection == 1 || moveDirection == 0)
    //    {
    //        if (Physics.Raycast(Checkpoint.transform.position, Checkpoint.transform.forward, out hitinfo, 100f))
    //        {
    //            if (hitinfo.collider.tag != "Road")
    //            {
    //                moveRotation = 1;
    //                Debug.Log(moveRotation);
    //                moveDirection = 2;
    //            }
    //        }
    //    }
    //    if (moveDirection == 2)
    //    {
    //        if (Physics.Raycast(Checkpoint.transform.position, Checkpoint.transform.forward, out hitinfo, 100f))
    //        {
    //            if (hitinfo.collider.tag != "Road")
    //            {
    //                moveRotation = 1;
    //                //Debug.Log(moveRotation);
    //                moveDirection = 1;
    //            }
    //        }
    //    }
    //}
}
