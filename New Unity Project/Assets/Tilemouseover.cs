using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilemouseover : MonoBehaviour {
    public Collider coll;
    Camera cam;
    void start()
    {

    }
    void OnMouseExit()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.red;//http://answers.unity3d.com/questions/209573/how-to-change-material-color-of-an-object.html
    }

    void OnMouseOver()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.blue;
    }
	// Update is called once per frame
	void Update () {
		Ray ray= cam.ScreenPointToRay(Input.mousePosition);//https://docs.unity3d.com/ScriptReference/Camera.ScreenPointToRay.html
        RaycastHit hitinfo;
        if (coll.Raycast( ray,out hitinfo, Mathf.Infinity))//
        {
            gameObject.GetComponent<Renderer>().material.color = Color.blue;

        }
        else {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
    }
}
