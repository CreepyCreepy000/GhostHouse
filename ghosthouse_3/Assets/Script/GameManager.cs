using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject Ghost1; //유령 오브젝트
    public GameObject Wall1; //벽 오브젝트
    public int PdCondition = 0; //상태를 나타내는 변수

    static GameManager m_cInstance;

    static public GameManager GetInstance()
    {
        return m_cInstance;
    }

    // Use this for initialization
    void Start () {
        m_cInstance = this;
    }
	
	// Update is called once per frame
	void Update () {
        PurchaseArea();
        //PdWall();
        //PdGhost();
        PreviewModel();
        ProduceModel();
    }

    public void PurchaseArea()
    {
        //GameObject target = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitinfo = new RaycastHit();
        if (Physics.Raycast(ray, out hitinfo, 100.0f))
        {
            if(hitinfo.collider.gameObject.tag=="area")
            {
                if (Input.GetMouseButtonDown(0))
                    Destroy(hitinfo.collider.gameObject);
            }
        }
    }

    //public void PdWall()
    //{
    //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //    RaycastHit hitinfo = new RaycastHit();
    //    if (Physics.Raycast(ray, out hitinfo, 100.0f))
    //    {
    //        if (hitinfo.collider.gameObject.tag == "Map")
    //        {
    //            //Debug.Log(hitinfo.collider.gameObject.tag);
    //            if (Input.GetKeyDown(KeyCode.M))
    //            {
    //                //GameObject G_wall = Instantiate(Wall1, hitinfo.point, Quaternion.identity);
    //                PdCondition = 1;
    //            }
    //        }
    //    }
    //}

    //public void PdGhost()
    //{
    //    //GameObject target = null;
    //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //    RaycastHit hitinfo = new RaycastHit();
    //    if (Physics.Raycast(ray, out hitinfo, 100.0f))
    //    {
    //        if (hitinfo.collider.gameObject.tag == "Map")
    //        {
    //            //Debug.Log(hitinfo.collider.gameObject.tag);
    //            if (Input.GetKeyDown(KeyCode.G))
    //            {
    //                //GameObject G_ghost = Instantiate(Ghost1, hitinfo.point, Quaternion.identity);
    //                PdCondition = 2;
    //            }
    //        }
    //    }
    //}

    public void ProduceModel()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            //GameObject G_wall = Instantiate(Wall1, hitinfo.point, Quaternion.identity);
            PdCondition = 1;
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            //GameObject G_ghost = Instantiate(Ghost1, hitinfo.point, Quaternion.identity);
            PdCondition = 2;
        }
    }

    public void PreviewModel()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitinfo = new RaycastHit();
        if (Physics.Raycast(ray, out hitinfo, 100.0f))
        {
            if (PdCondition != 0)
            {
                //if (PdCondition == 1)
                //{
                //    Model = Instantiate(Wall1, hitinfo.point, Quaternion.identity);
                //    //Destroy(WallModel);
                //}

                //if (PdCondition == 2)
                //{
                //    Model = Instantiate(Ghost1, hitinfo.point, Quaternion.identity);
                //    //Destroy(GhostModel);   
                //}
            }
        }     
    }
    
}
