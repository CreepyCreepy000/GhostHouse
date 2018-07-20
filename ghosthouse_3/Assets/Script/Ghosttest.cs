using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghosttest : MonoBehaviour {

    public GameObject G_Ghost1; //유령 오브젝트
    Vector3 posi;
    GameObject testghost;
    public int ghostnumber = 0;
    public int GhostType = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {        
        GNumber();
        LocateGhost();
    }

    public void GNumber()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            ghostnumber = 1;
        }
    }

    public void LocateGhost()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitinfo = new RaycastHit();

        if (Physics.Raycast(ray, out hitinfo, 100.0f))
        {
            posi.x = Mathf.Round(hitinfo.point.x);
            posi.y = Mathf.Round(hitinfo.point.y);
            posi.z = Mathf.Round(hitinfo.point.z);
            if (testghost == null)
            {
                if (ghostnumber == 1)
                {
                    testghost = Instantiate(G_Ghost1, posi, Quaternion.identity);
                    GhostType = 1;
                    ghostnumber = 0;
                }
            }
            if (testghost != null)
            {
                testghost.transform.position = posi;
                RaycastHit hit = new RaycastHit();
                if (Physics.Raycast(testghost.transform.position, testghost.transform.forward, out hit, 100f))
                {
                    if (hit.collider.tag == "Road")
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            if (GhostType == 1)
                            {
                                GameObject LocateG = Instantiate(G_Ghost1, posi, Quaternion.identity);
                                GhostType = 0;
                                Destroy(testghost);
                            }
                        }
                    }
                    if (Input.GetMouseButtonDown(1))
                    {
                        Destroy(testghost);
                    }
                }
            }
        }
    }
}
