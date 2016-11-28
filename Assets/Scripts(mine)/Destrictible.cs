using UnityEngine;
using System.Collections;

public class Destrictible : MonoBehaviour {
    

    public void OnTriggerEnter()
    {
            Destroy(gameObject);
            //AudioSource source = GetComponent<AudioSource>();
            //source.Play();
    }
}
