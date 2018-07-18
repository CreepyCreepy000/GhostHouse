using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildtest : MonoBehaviour {

    public GameObject G_Wall;
    public GameObject G_Preview;
    public GameObject G_Preview1;
    GameObject test;
    Vector3 posi;
    public int PdCondition = 0; //상태를 나타내는 변수

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //PurchaseWall();
        //Condi();
        PreviewWall();
	}

    public void PurchaseWall()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hitinfo = new RaycastHit();
            
        //    if (Physics.Raycast(ray, out hitinfo, 100.0f))
        //    {
        //        //Debug.Log(hitinfo.collider.tag);
        //        if (hitinfo.collider.tag == "Map")
        //        {
        //            GameObject target = hitinfo.collider.gameObject;
        //            if (Input.GetKeyDown(KeyCode.W))
        //            {
        //                Debug.Log("1");
        //                GameObject BuildWall = Instantiate(G_Wall, target.transform.position, Quaternion.identity);
        //            }
        //        }
        //    }
        //}
    }

    public void Condi()
    {
        //if(Input.GetKeyDown(KeyCode.M))
        //{
        //    PdCondition = 1;
        //}
    }

    public void PreviewWall()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitinfo = new RaycastHit();

        if (Physics.Raycast(ray, out hitinfo, 100.0f))
        {
            posi.x = Mathf.Round(hitinfo.point.x);
            posi.y = Mathf.Round(hitinfo.point.y);
            posi.z = Mathf.Round(hitinfo.point.z);
            if (test == null && Input.GetKeyDown(KeyCode.M))
            {
                test = Instantiate(G_Preview, posi, Quaternion.identity);
            }
            if (test != null)
            {
                test.transform.position = posi;
                //if(hitinfo.collider.tag != "Map")
                //{
                //    test = Instantiate(G_Preview1, posi, Quaternion.identity);
                //}
                if (Input.GetMouseButtonDown(0))
                {
                    //Debug.Log(hitinfo.collider.tag);
                    //RaycastHit hit = new RaycastHit();
                    //if (Physics.BoxCast(test.transform.position, test.transform.lossyScale, test.transform.forward, out hit, Quaternion.identity, 100f))
                    //if (Physics.Raycast(test.transform.position, test.transform.forward, out hit, 100f, 1 << LayerMask.NameToLayer("field")))
                    {
                        //Debug.Log(hit.collider.tag);
                        //GameObject target = hit.collider.gameObject;
                        //Debug.Log(target.tag);
                        //if (hitinfo.collider.tag == "Map")
                        {
                            GameObject BuildWall = Instantiate(G_Wall, test.transform.position, Quaternion.identity);
                            Destroy(test);
                            test = null;
                        }
                    }
                }
                if (Input.GetMouseButtonDown(1))
                {
                    Destroy(test);
                    test = null;
                }
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
