using UnityEngine;
using System.Collections;

public class Collectible : MonoBehaviour {

    public int value;
    public float rotateSpeed;
	// Update is called once per frame
	void Update () {
        gameObject.transform.Rotate(Vector3.forward * Time.deltaTime * rotateSpeed);
    }

    void OnTriggerEnter(){
        GameManager.instance.Collect(value, gameObject);

        AudioSource source = GetComponent<AudioSource>();
        source.Play();
    }
}
