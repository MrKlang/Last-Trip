using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyBindings : MonoBehaviour {
    private GameObject currentKey;
    private Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();
    public Text left,right,slide,charge,jump,invertGravity;
    
    // Use this for initialization
	void Start () {
        keys.Add("Left",KeyCode.A);
        keys.Add("Right", KeyCode.D);
        keys.Add("Slide", KeyCode.S);
        keys.Add("Jump", KeyCode.Space);
        keys.Add("Charge", KeyCode.LeftShift);
        keys.Add("Invert Gravity", KeyCode.W);

        left.text = keys["Left"].ToString();
        right.text = keys["Right"].ToString();
        slide.text = keys["Slide"].ToString();
        jump.text = keys["Jump"].ToString();
        invertGravity.text = keys["Invert Gravity"].ToString();
        charge.text = keys["Charge"].ToString();
    }
	
	void OnGUI()
    {
        if (currentKey != null)
        {
            Event e = Event.current;
            if (e.isKey)
            {
                keys[currentKey.name] = e.keyCode;
                currentKey.transform.GetChild(0).GetComponent<Text>().text = e.keyCode.ToString();

                
                currentKey = null;
            }
        }
    }

    public void ChangeKey(GameObject clicked)
    {
        currentKey = clicked;
    }
}
