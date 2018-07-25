using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollider : MonoBehaviour {

    public int Check;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Pd();
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Map")
        {
            Check = 0;
        }
        if (other.tag != "Map")
        {
            Check = 1;
        }
    }

    //void OnCollisionStay(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Map")
    //    {
    //        Check = 0;
    //    }
    //    if (collision.gameObject.tag != "Map")
    //    {
    //        Check = 1;
    //    }
    //}

    //public void Pd()
    //{
    //    if (Check == 0)
    //    {
    //        if (Input.GetMouseButtonDown(0))
    //        {
    //            Buildtest2.GetInstance().posi.z = 0.0001f; //약간의 꼼수. 배경의 z축좌표인 0.01f 보다 작은 값을 줌으로써 생성된 벽이 
    //                              //카메라에서 보는 기준으로 배경보다 앞에 있게되므로 test에서 ray를 쐈을 때 배경보다 앞에있는
    //                              //벽을 hit에 저장하게 된다.
    //            if (Buildtest2.GetInstance().PdType == 1)
    //            {
    //                GameObject BuildWall = Instantiate(Buildtest2.GetInstance().G_Wall, Buildtest2.GetInstance().posi, Quaternion.identity);
    //            }
    //            if (Buildtest2.GetInstance().PdType == 2)
    //            {
    //                GameObject BuildRoad = Instantiate(Buildtest2.GetInstance().G_Road, Buildtest2.GetInstance().posi, Quaternion.identity);
    //            }
    //        }
    //    }
    //}

}
