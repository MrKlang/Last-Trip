using UnityEngine;
using System.Collections;

public class characterRotate : MonoBehaviour {

	public GameObject frog;
	
	
	
	private Rect FpsRect ;
	private string frpString;
	
	private GameObject instanceObj;
	public GameObject[] gameObjArray=new GameObject[15];
	public AnimationClip[] AniList  = new AnimationClip[15];
	
	float minimum = 2.0f;
	float maximum = 50.0f;
	float touchNum = 0f;
	string touchDirection ="forward"; 
	private GameObject Warrior;
	
	// Use this for initialization
	void Start () {
		
		//frog.animation["dragon_03_ani01"].blendMode=AnimationBlendMode.Blend;
		//frog.animation["dragon_03_ani02"].blendMode=AnimationBlendMode.Blend;
		//Debug.Log(frog.GetComponent("dragon_03_ani01"));
		
		//Instantiate(gameObjArray[0], gameObjArray[0].transform.position, gameObjArray[0].transform.rotation);
	}
	
 void OnGUI() {
	  if (GUI.Button(new Rect(20, 20, 70, 40),"Idle")){
		 frog.GetComponent<Animation>().wrapMode= WrapMode.Loop;
		  	frog.GetComponent<Animation>().CrossFade("Idle");
	  }
	    if (GUI.Button(new Rect(90, 20, 70, 40),"Idle1")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Loop;
		  	frog.GetComponent<Animation>().CrossFade("Idle1");
	  }
	    if (GUI.Button(new Rect(160, 20, 70, 40),"Talk")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Loop;
		  	frog.GetComponent<Animation>().CrossFade("Talk");			
	  }
		
	     if (GUI.Button(new Rect(230, 20, 70, 40),"Walk")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Loop;
		  	frog.GetComponent<Animation>().CrossFade("Walk");
	  }
		if (GUI.Button(new Rect(300, 20, 70, 40),"R-Walk")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Loop;
		  	frog.GetComponent<Animation>().CrossFade("R-Walk");
	  } 
		if (GUI.Button(new Rect(370, 20, 70, 40),"L-Walk")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Loop;
		  	frog.GetComponent<Animation>().CrossFade("L-Walk");
	  } 
		if (GUI.Button(new Rect(440, 20, 70, 40),"B-Walk")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Loop;
		  	frog.GetComponent<Animation>().CrossFade("B-Walk");
	  }
	    if (GUI.Button(new Rect(510, 20, 70, 40),"Run2")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Loop;
		  	frog.GetComponent<Animation>().CrossFade("Run2");
	  }
	    if (GUI.Button(new Rect(580, 20, 70, 40),"R-Run2")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Loop;
		  	frog.GetComponent<Animation>().CrossFade("R-Run2");
	  }
	    if (GUI.Button(new Rect(650, 20, 70, 40),"L-Run2")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Loop;
		  	frog.GetComponent<Animation>().CrossFade("L-Run2");
	  }
	    if (GUI.Button(new Rect(720, 20, 70, 40),"Throw")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Once;
		  	frog.GetComponent<Animation>().CrossFade("Throw");			
	  } 
	    if (GUI.Button(new Rect(790, 20, 70, 40),"Draw")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Once;
		  	frog.GetComponent<Animation>().CrossFade("Draw");			
	  } 		
		if (GUI.Button(new Rect(20, 65, 70, 40),"Run")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Loop;
		  	frog.GetComponent<Animation>().CrossFade("Run");
	  }
			    if (GUI.Button(new Rect(90, 65, 70, 40),"Walk2")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Loop;
		  	frog.GetComponent<Animation>().CrossFade("Walk2");
	  }	
	    if (GUI.Button(new Rect(160, 65, 70, 40),"R-Walk2")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Loop;
		  	frog.GetComponent<Animation>().CrossFade("R-Walk2");
	  }
	    if (GUI.Button(new Rect(230, 65, 70, 40),"L-Walk2")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Loop;
		  	frog.GetComponent<Animation>().CrossFade("L-Walk2");			
	  } 
		if (GUI.Button(new Rect(300, 65, 70, 40),"B-Walk2")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Loop;
		  	frog.GetComponent<Animation>().CrossFade("B-Walk2");
	  } 
		if (GUI.Button(new Rect(370, 65, 70, 40),"R-RUN")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Loop;
		  	frog.GetComponent<Animation>().CrossFade("R-Run");
	  }
	    if (GUI.Button(new Rect(440, 65, 70, 40),"L-Run")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Loop;
		  	frog.GetComponent<Animation>().CrossFade("L-Run");
	  }
		if (GUI.Button(new Rect(510, 65, 70, 40),"Dash")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Once;
		  	frog.GetComponent<Animation>().CrossFade("Dash");
	  } 
		if (GUI.Button(new Rect(580, 65, 70, 40),"Down")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Once;
		  	frog.GetComponent<Animation>().CrossFade("Down");
	  } 
		if (GUI.Button(new Rect(650, 65, 70, 40),"Up")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Once;
		  	frog.GetComponent<Animation>().CrossFade("Up");
	  } 
		if (GUI.Button(new Rect(720, 65, 70, 40),"Jump")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Once;
		  	frog.GetComponent<Animation>().CrossFade("Jump");
	  }		
			if (GUI.Button(new Rect(790, 65, 70, 40),"Attack_stance")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Loop;
		  	frog.GetComponent<Animation>().CrossFade("Attack_stance");
	  } 
		if (GUI.Button(new Rect(20, 110, 70, 40),"Attack1")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Once;
		  	frog.GetComponent<Animation>().CrossFade("Attack1");
	  } 
		if (GUI.Button(new Rect(90, 110, 70, 40),"Attack2")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Once;
		  	frog.GetComponent<Animation>().CrossFade("Attack2");
	  } 
		if (GUI.Button(new Rect(160, 110, 70, 40),"Attack3")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Once;
		  	frog.GetComponent<Animation>().CrossFade("Attack3");
	  }
	    if (GUI.Button(new Rect(230, 110, 70, 40),"Combo")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Once;
		  	frog.GetComponent<Animation>().CrossFade("Combo");
	  }
	    if (GUI.Button(new Rect(300, 110, 70, 40),"Skill")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Once;
		  	frog.GetComponent<Animation>().CrossFade("Skill");
	  }
	    if (GUI.Button(new Rect(370, 110, 70, 40),"Skill1")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Once;
		  	frog.GetComponent<Animation>().CrossFade("Skill1");			
	  } 		
	    if (GUI.Button(new Rect(440, 110, 70, 40),"Push")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Once;
		  	frog.GetComponent<Animation>().CrossFade("Push");
	  }
	    if (GUI.Button(new Rect(510, 110, 70, 40),"Brock")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Once;
		  	frog.GetComponent<Animation>().CrossFade("Brock");			
	  } 
		if (GUI.Button(new Rect(580, 110, 70, 40),"Buff")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Once;
		  	frog.GetComponent<Animation>().CrossFade("Buff");
	  } 
		if (GUI.Button(new Rect(650, 110, 70, 40),"Stun")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Loop;
		  	frog.GetComponent<Animation>().CrossFade("Stun");
	  }
	    if (GUI.Button(new Rect(720, 110, 70, 40),"Damage")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Once;
		  	frog.GetComponent<Animation>().CrossFade("Damage");
	  }	
	    if (GUI.Button(new Rect(790, 110, 70, 40),"Dead")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Once;
		  	frog.GetComponent<Animation>().CrossFade("Dead");
	  }
	    if (GUI.Button(new Rect(20, 155, 70, 40),"Play")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Once;
		  	frog.GetComponent<Animation>().CrossFade("Play");
	  }
		if (GUI.Button(new Rect(160, 155, 70, 40),"B-L-Walk")){
			frog.GetComponent<Animation>().wrapMode= WrapMode.Loop;
			frog.GetComponent<Animation>().CrossFade("B-L-Walk");
	  }
		if (GUI.Button(new Rect(230, 155, 70, 40),"B-R-Walk")){
			frog.GetComponent<Animation>().wrapMode= WrapMode.Loop;
			frog.GetComponent<Animation>().CrossFade("B-R-Walk");
	  }	
		if (GUI.Button(new Rect(300, 155, 70, 40),"B-L-Walk2")){
			frog.GetComponent<Animation>().wrapMode= WrapMode.Loop;
			frog.GetComponent<Animation>().CrossFade("B-L-Walk2");
	  }
		if (GUI.Button(new Rect(370, 155, 70, 40),"B-R-Walk2")){
			frog.GetComponent<Animation>().wrapMode= WrapMode.Loop;
			frog.GetComponent<Animation>().CrossFade("B-R-Walk2");
	  }

	


		
//				if (GUI.Button(new Rect(580, 470, 120, 40),"Ver ")){
//		  frog.animation.wrapMode= WrapMode.Loop;
//		  	frog.animation.CrossFade("Idle");
//	  }
 }
	
	// Update is called once per frame
	void Update () {
		
		//if(Input.GetMouseButtonDown(0)){
		
			//touchNum++;
			//touchDirection="forward";
		 // transform.position = new Vector3(0, 0,Mathf.Lerp(minimum, maximum, Time.time));
			//Debug.Log("touchNum=="+touchNum);
		//}
		/*
		if(touchDirection=="forward"){
			if(Input.touchCount>){
				touchDirection="back";
			}
		}
	*/
		 
		//transform.position = Vector3(Mathf.Lerp(minimum, maximum, Time.time), 0, 0);
	if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
		//frog.transform.Rotate(Vector3.up * Time.deltaTime*30);
	}
	
}
