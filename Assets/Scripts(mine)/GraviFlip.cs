using UnityEngine;
using System.Collections;

public class GraviFlip : MonoBehaviour {

    public GameObject obj;
    bool inverted = false;
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Invert Gravity")){
            if(inverted == false)
            {
                inverted = true;
                Physics.gravity = Vector3.down;
                obj.transform.Rotate(180, 180, 0);
            }
            else
            {
                inverted = false;
                obj.transform.Rotate(180,180,0);
                Physics.gravity = Vector3.up;
            }
        }
	}
}
