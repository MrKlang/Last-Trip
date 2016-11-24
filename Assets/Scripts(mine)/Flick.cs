using UnityEngine;
using System.Collections;

public class Flick : MonoBehaviour {

    public Light light1,light2;
    public float minTime = 0.05f, maxTime =1.2f;
    private float timer;
    // Use this for initialization
    void Start () {
        timer = Random.Range(minTime,maxTime);
	}

    void Update(){
        timer -= Time.deltaTime;
        if (timer < 0){
            light1.enabled = !light1.enabled;
            light2.enabled = !light2.enabled;
            //audio.Play();
            timer = Random.Range(minTime, maxTime);
        }
    }
}
