using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {

    public ExoController ch;
    public float restartDelay = 5f;

    Animator anim;
    float reastartTimer;
	// Use this for initialization
	void Awake () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (ch.isDead == true)
        {
            anim.SetTrigger("GameOver");
            reastartTimer += Time.deltaTime;
            if (reastartTimer >= restartDelay)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
	}
}
