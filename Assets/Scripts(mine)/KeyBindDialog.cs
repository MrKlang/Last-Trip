﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class KeyBindDialog : MonoBehaviour {
    // Use this for initialization
    string[] keys;
	void Start () {
        inputManager = FindObjectOfType<InputManager>();
        string[] buttonNames = inputManager.GetButtonNames();
        buttonToLabel = new Dictionary<string, Text>();
       
        for(int i =0; i<buttonNames.Length; i++)
        {
            string bn;
            bn = buttonNames[i];

            GameObject go = (GameObject)Instantiate(keyItemPrefab);
            go.transform.SetParent(keyList.transform);
            go.transform.localScale = Vector3.one;

            Text buttonNameText = go.transform.Find("Button Name").GetComponent<Text>();
            buttonNameText.text = bn;

            Text keyNameText = go.transform.Find("Button/Key Name").GetComponent<Text>();
            keyNameText.text = inputManager.GetKeyNameForButton(bn);
            buttonToLabel[bn] = keyNameText;

            Button keyBindButton = go.transform.Find("Button").GetComponent<Button>();
            keyBindButton.onClick.AddListener(()=> { StartRebindFor(bn); });
            keys = buttonNames;
        }
    }
    public GameObject keyItemPrefab;
    public GameObject keyList;
    InputManager inputManager;
    string buttonToRebind = null;
    Dictionary<string, Text> buttonToLabel;
    // Update is called once per frame
    void Update () {
        if (buttonToRebind != null)
        {
            if (Input.anyKeyDown)
            {
                foreach(KeyCode kc in Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKeyDown(kc))
                    {
                        inputManager.SetButtonForKey(buttonToRebind,kc);
                        buttonToLabel[buttonToRebind].text = kc.ToString();
                        buttonToRebind = null;
                        break;
                    }
                }
            }
        }
    }

    void StartRebindFor(string buttonName)
    {
        buttonToRebind = buttonName;
    }
}
