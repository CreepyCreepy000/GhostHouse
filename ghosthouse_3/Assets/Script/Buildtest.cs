using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildtest : MonoBehaviour {

    public GameObject G_Wall; //벽
    public GameObject G_Road; //길
    public GameObject G_Preview; //벽미리보기(설치가능)
    public GameObject G_Preview1; //벽미리보기(설치불가)
    //public GameObject G_PvRoad; //길미리보기(설치가능)
    //public GameObject G_PvRoad1; //길미리보기(설치불가)
    GameObject test; //오브젝트 설치 미리보기 저장용
    GameObject test2; //설치불가 미리보기
    Vector3 posi; //오브젝트 위치 저장용
    public int PdCondition = 0; //설치할 오브젝트 미리보기의 종류를 나타내는 변수
    public int PdType = 0; //설치할 오브젝트의 종류를 나타내는 변수

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Condi();
        ProduceObject();
        DeleteObject();
    }

    public void Condi()
    {
        
        if (test == null)
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                PdCondition = 1;
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                PdCondition = 2;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                PdCondition = -1;
            }
        }
        
    }

    public void DeleteObject()
    {
        if (PdCondition == -1)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitinfo = new RaycastHit();

            if (Physics.Raycast(ray, out hitinfo, 100.0f))
            {
                if (hitinfo.collider.tag != "Map")
                {
                    if (Input.GetMouseButtonDown(1))
                    {
                        //Debug.Log(hitinfo.collider.tag);
                        Destroy(hitinfo.collider.gameObject);
                        PdCondition = 0;
                    }
                }
            }
        }
    }

    public void ProduceObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitinfo = new RaycastHit();

        if (Physics.Raycast(ray, out hitinfo, 100.0f))
        {
            posi.x = Mathf.Round(hitinfo.point.x);
            posi.y = Mathf.Round(hitinfo.point.y);
            posi.z = Mathf.Round(hitinfo.point.z);
            if (test == null)
            {
                if (PdCondition == 1)
                {
                    test = Instantiate(G_Preview, posi, Quaternion.identity);
                    test2 = Instantiate(G_Preview1, posi, Quaternion.identity);
                    PdType = 1;
                }
                if (PdCondition == 2)
                {
                    test = Instantiate(G_Preview, posi, Quaternion.identity); // G_PvRoad로 해야하나 이미지가 없으므로 보류
                    test2 = Instantiate(G_Preview1, posi, Quaternion.identity); //G_PvRoad1로 해야함
                    PdType = 2;
                }
                if (test2 != null)
                {
                    test2.SetActive(false);
                    PdCondition = 0;
                }
                
            }
            if (test != null)
            {
                test.transform.position = posi;
                test2.transform.position = posi;

                RaycastHit hit = new RaycastHit();
                if (Physics.Raycast(test.transform.position, test.transform.forward, out hit, 100f/*, 1 << LayerMask.NameToLayer("field")*/))
                {
                    if (hit.collider.tag == "Map")
                    {
                        test.SetActive(true);
                        //Debug.Log(hit.collider.tag);                        
                        if (Input.GetMouseButtonDown(0))
                        {
                            posi.z = 0.0001f; //약간의 꼼수. 배경의 z축좌표인 0.01f 보다 작은 값을 줌으로써 생성된 벽이 
                            //카메라에서 보는 기준으로 배경보다 앞에 있게되므로 test에서 ray를 쐈을 때 배경보다 앞에있는
                            //벽을 hit에 저장하게 된다.
                            if (PdType == 1)
                            {
                                GameObject BuildWall = Instantiate(G_Wall, posi, Quaternion.identity);
                            }
                            if (PdType == 2)
                            {
                                GameObject BuildRoad = Instantiate(G_Road, posi, Quaternion.identity);
                            }                        
                        }
                    }
                    if (hit.collider.tag != "Map")
                    {
                        test2.SetActive(true);
                        test.SetActive(false);
                    }
                }
                if (Input.GetMouseButtonDown(1))
                {
                    PdType = 0;
                    Destroy(test);
                    Destroy(test2);
                    test = null;
                    test2 = null;
                }
                //if (Input.GetMouseButtonDown(0))
                //{
                //    posi.z = 0.0001f;
                //    GameObject BuildWall = Instantiate(G_Wall, posi, Quaternion.identity);
                //    Destroy(test);
                //    test = null;
                //}
                //{
                //    Collider[] hitCollider = Physics.OverlapBox(test.transform.position, test.transform.lossyScale / 4);
                //    foreach (Collider hit in hitCollider)
                //    {
                //        //Debug.Log(hit.tag);
                //        if (hit.tag != "Wall")
                //        {

                //        }
                //    }
                //    Debug.Log(hitinfo.collider.tag);

                //    if (Physics.BoxCast(test.transform.position, test.transform.lossyScale, test.transform.forward, out hit, Quaternion.identity, 100f))
                //        if (Physics.Raycast(test.transform.position, test.transform.forward, out hit, 100f, 1 << LayerMask.NameToLayer("field")))
                //        {
                //            Debug.Log(hit.collider.tag);
                //            GameObject target = hit.collider.gameObject;
                //            Debug.Log(target.tag);
                //            if (hitinfo.collider.tag == "Map")
                //            {
                //                GameObject BuildWall = Instantiate(G_Wall, test.transform.position, Quaternion.identity);
                //                Destroy(test);
                //                test = null;
                //            }
                //        }
                //    RaycastHit hit = new RaycastHit();
                //    if (Physics.Raycast(test.transform.position, test.transform.forward, out hit, 100f/*, 1 << LayerMask.NameToLayer("field")*/))
                //    {
                //        if (Input.GetMouseButtonDown(0))
                //        {
                //            Debug.Log(hit.collider.tag);
                //            if (hit.collider.tag == "Map")
                //            {
                //                posi.z = 0.0001f;
                //                GameObject BuildWall = Instantiate(G_Wall, posi, Quaternion.identity);
                //                Destroy(test);
                //                test = null;
                //            }
                //        }
                //    }
                //}

            }

            
        }

        //if (test != null)
        //{
        //    test.transform.position = posi;
        //    if (Input.GetMouseButtonDown(0))
        //    {
        //        GameObject BuildWall = Instantiate(G_Wall, test.transform.position, Quaternion.identity);
        //        Destroy(test);
        //        test = null;
        //    }
        //}

        //if (Input.GetMouseButtonDown(1))
        //{
        //    Destroy(test);
        //    test = null;
        //}
    }
}
