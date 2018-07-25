using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhestMove : MonoBehaviour {

    public GameObject EyeSight;
    public int MoveCondition = 0;

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
            Debug.Log(hit.collider.tag);
            if (hit.collider.tag == "Down")
            {
                MoveCondition = 0;
            }
            if (hit.collider.tag == "Up")
            {
                MoveCondition = 1;
            }
            if (hit.collider.tag == "Right")
            {
                MoveCondition = 2;
            }
            if (hit.collider.tag == "Left")
            {
                MoveCondition = 3;
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
}
