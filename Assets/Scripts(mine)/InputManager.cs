using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InputManager : MonoBehaviour {

    void OnEnable(){
        keys = new Dictionary<string, KeyCode>();
        keys["Left"] = KeyCode.A;
        keys["Right"] = KeyCode.D;
        keys["Slide"] = KeyCode.S;
        keys["Jump"] = KeyCode.Space;
        keys["Charge"] = KeyCode.LeftShift;
        keys["Invert Gravity"] = KeyCode.W;
    }

	// Use this for initialization
	void Start () {
        
    }

    Dictionary<string, KeyCode> keys;

	// Update is called once per frame
	void Update () {
		
	}

    public bool GetButtonDown(string buttonName)
    {
        if(keys.ContainsKey(buttonName) == false)
        {
            return false;
        }
        return Input.GetKeyDown(keys[buttonName]);
    }

    public string[] GetButtonNames()
    {
        return keys.Keys.ToArray();
    }

    public string GetKeyNameForButton(string buttonName)
    {
        if(keys.ContainsKey(buttonName) == false)
        {
            return "N/A";
        }
        return keys[buttonName].ToString();
    }

    public void SetButtonForKey(string buttonName, KeyCode keyCode)
    {
        keys[buttonName] = keyCode;
    }
}
