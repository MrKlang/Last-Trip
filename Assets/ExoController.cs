using System;
using System.Collections;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;
using Random = UnityEngine.Random;

namespace UnityStandardAssets.Characters.FirstPerson
{
    [RequireComponent(typeof (CharacterController))]
    [RequireComponent(typeof (AudioSource))]
    public class ExoController : MonoBehaviour
    {
        [SerializeField] private bool m_IsWalking;
        [SerializeField] private float m_WalkSpeed;
        [SerializeField] private float m_RunSpeed;
        [SerializeField] [Range(0f, 1f)] private float m_RunstepLenghten;
        [SerializeField] private float m_JumpSpeed;
        [SerializeField] private float m_StickToGroundForce;
        [SerializeField] private float m_GravityMultiplier;
        [SerializeField] private MouseLook m_MouseLook;
        [SerializeField] private bool m_UseFovKick;
        [SerializeField] private FOVKick m_FovKick = new FOVKick();
        [SerializeField] private bool m_UseHeadBob;
        [SerializeField] private CurveControlledBob m_HeadBob = new CurveControlledBob();
        [SerializeField] private LerpControlledBob m_JumpBob = new LerpControlledBob();
        [SerializeField] private float m_StepInterval;
        [SerializeField] private AudioClip[] m_FootstepSounds;    // an array of footstep sounds that will be randomly selected from.
        [SerializeField] private AudioClip m_JumpSound;           // the sound played when character leaves the ground.
        [SerializeField] private AudioClip m_LandSound;           // the sound played when character touches back on ground.

        public int lane = 0;
        public float grav;
        private Camera m_Camera;
        private bool m_Jump;
        private float m_YRotation;
        private Vector2 m_Input;
        private Vector3 m_MoveDir = Vector3.zero;
        private CharacterController m_CharacterController;
        private CollisionFlags m_CollisionFlags;
        private bool m_PreviouslyGrounded;
        private Vector3 m_OriginalCameraPosition;
        private float m_StepCycle;
        private float m_NextStep;
        private bool m_Jumping;
        private AudioSource m_AudioSource;
        public GameObject obj;
        private bool inverted = true;
        bool isSliding = false;
        float height;
        private bool triggercollision = false;
        float horizontal = 0; //CrossPlatformInputManager.GetAxis("Horizontal");
        float vertical = 0;
        bool isRotttated = false;

        bool isCharging = false;

        // Use this for initialization
        private void Start()
        {
            m_CharacterController = GetComponent<CharacterController>();
            m_Camera = Camera.main;
            m_OriginalCameraPosition = m_Camera.transform.localPosition;
            m_FovKick.Setup(m_Camera);
            m_HeadBob.Setup(m_Camera, m_StepInterval);
            m_StepCycle = 0f;
            m_NextStep = m_StepCycle/2f;
            m_Jumping = false;
            m_AudioSource = GetComponent<AudioSource>();
			m_MouseLook.Init(transform , m_Camera.transform);
            
            height = m_CharacterController.height;
            



        }


        // Update is called once per frame
        private void Update()
        {
            
            //RotateView();
            // the jump state needs to read here to make sure it is not missed
            if (!m_Jump)
            {
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }
            if (isRotttated)
            {
               
            }
            else
            {
                horizontal = 0;
                vertical = 1;
            }

            if (Input.GetKeyDown(KeyCode.A) && (lane != -1) && (!m_Jumping))
            {
                if (isRotttated)
                {
                    StartCoroutine(SmoothH(3f));
                    lane--;
                } 
                else{ 
                    StartCoroutine(SmoothH(-3f));
                    lane--; }
            }
            if (Input.GetKeyDown(KeyCode.D) && (lane != 1) && (!m_Jumping))
            {
                if (isRotttated)
                {
                    StartCoroutine(SmoothH(-3f));
                    lane++;
                }
                else { 
                StartCoroutine(SmoothH(3f));
                lane++; }
            }
            if (Input.GetKeyDown(KeyCode.S) && (!isSliding) && (!m_Jumping))
            {
                StartCoroutine(Slide());
            }
            if (Input.GetKeyDown(KeyCode.LeftShift) && isCharging == false)
            {
                isCharging = true;
                StartCoroutine(Charge());
            }


            if (!m_PreviouslyGrounded && m_CharacterController.isGrounded)
            {
                StartCoroutine(m_JumpBob.DoBobCycle());
                PlayLandingSound();
                m_MoveDir.y = 0f;
                m_Jumping = false;
            }
            if (!m_CharacterController.isGrounded && !m_Jumping && m_PreviouslyGrounded)
            {
                m_MoveDir.y = 0f;
            }

            m_PreviouslyGrounded = m_CharacterController.isGrounded;
         
        }

        private void ControlManager(CharacterController m_CharacterController)
        {
            
        }

        void OnTriggerEnter(Collider col)
        {
            if (col.tag == "Destr")
            {
<<<<<<< HEAD
=======
                triggercollision = true;
                if (isCharging == true)
                {
                    Destroy(col.gameObject);
                }
                //StartCoroutine(TurnSmooth(90));
            }
            if (col.tag == "TurnTriggerLeft")
            {
>>>>>>> origin/master
                
                
                //StartCoroutine(TurnSmooth(-90));
            }
            if (col.tag == "TurnTriggerRight")
            {
                
                
                //StartCoroutine(TurnSmooth(90));
            }
        }
        void OnTriggerExit(Collider col)
        {
            if (col.tag == "TurnTriggerLeft" && triggercollision != true)
            {
                triggercollision = true;
                isRotttated = true;
                StartCoroutine(TurnSmooth(-1));
                
                
            }
            if (col.tag == "TurnTriggerRight"&&triggercollision !=true)
            {
                triggercollision = true;
                isRotttated = true;
                StartCoroutine(TurnSmooth(1));
                
                
            }
            
        }

        IEnumerator Charge()
        {
            m_JumpSpeed = 9;
            m_WalkSpeed = 9;
            m_RunSpeed = 9;
            yield return new WaitForSeconds(0.5f);
            m_JumpSpeed = 7;
            m_WalkSpeed = 5;
            m_RunSpeed = 6;
            isCharging = false;
        }

        IEnumerator Slide()
        {
            isSliding = true;
            Vector3 pos = transform.position;
            float slideTimer = 0.0f;
            float slideTimerMax = 1.0f;
            float startHeight = m_CharacterController.height, tmpHeight = m_CharacterController.height;
            float startCHeight= pos.y, tmpCHeight = pos.y;

            while (tmpHeight>(startHeight/2))
            {
            
             pos = transform.position;
             tmpCHeight = Mathf.Lerp(startCHeight,(startCHeight/2), slideTimer);
             tmpHeight = Mathf.Lerp(startHeight, (startHeight/2), slideTimer);
             slideTimer += 5*Time.deltaTime;
             transform.position = new Vector3(transform.position.x,tmpCHeight,transform.position.z);
             m_CharacterController.height = tmpHeight;
             yield return null;
             }
            slideTimer = 0.0f;
            while (tmpHeight < (startHeight ))
             {

                pos = transform.position;
                tmpCHeight = Mathf.Lerp((startCHeight / 2), startCHeight,  slideTimer);
                tmpHeight = Mathf.Lerp( (startHeight / 2), startHeight, slideTimer);
                slideTimer += 5*Time.deltaTime;
                transform.position = new Vector3(transform.position.x, tmpCHeight, transform.position.z);
                m_CharacterController.height = tmpHeight;
                yield return null;
               }
            isSliding = false;
        }

        IEnumerator SmoothH(float variable)
        {
            Vector3 pos = transform.position;
            float t = 0.0f;
            if (!isRotttated)
            {
                float xend = pos.x + variable;
                while (pos.x != xend)
                {
                    pos = transform.position;
                    pos.x = Mathf.Lerp(pos.x, xend, t);
                    t += 0.07f;
                    transform.position = pos;
                    yield return null;
                }
            }
            if (isRotttated)
            {
                float xend = pos.z + variable;
                while (pos.z != xend)
                {
                    pos = transform.position;
                    pos.z = Mathf.Lerp(pos.z, xend, t);
                    t += 0.07f;
                    transform.position = pos;
                    yield return null;
                }

            }
        }


        IEnumerator TurnSmooth(float variable)
        { /*
            var pos = transform.rotation;
            float t = 0.0f;
            float xend = pos.y + variable;
            while (pos.y != xend)
            {
                pos = transform.rotation;
                pos.y = Mathf.Lerp(pos.y, xend, t);
                t += 0.07f;
                transform.rotation = pos;
                yield return null;

            }*/
            var pos = transform.rotation;
            pos.y += variable;
            transform.rotation = pos;
            return null;  
        }

        private void FixedUpdate()
        {
            var h = height;
            float speed;
            GetInput(out speed);
            // always move along the camera forward as it is the direction that it being aimed at
            Vector3 desiredMove = transform.forward*m_Input.y + transform.right*m_Input.x;

            // get a normal for the surface that is being touched to move along it
            RaycastHit hitInfo;
            Physics.SphereCast(transform.position, m_CharacterController.radius, Vector3.down, out hitInfo,
                               m_CharacterController.height/2f);
            desiredMove = Vector3.ProjectOnPlane(desiredMove, hitInfo.normal).normalized;

            m_MoveDir.x = 2*desiredMove.x*speed;
            m_MoveDir.z = 2*desiredMove.z*speed;  //bieg do przodi

            if (m_CharacterController.isGrounded)
            {
                m_MoveDir.y = -m_StickToGroundForce;

                if (m_Jump)
                {
                    m_MoveDir.y = m_JumpSpeed;
                    PlayJumpSound();
                    m_Jump = false;
                    m_Jumping = true;
                }
            }

            if (Input.GetButtonDown("Invert Gravity"))  //<< -----Odwracanie gravitacji
            {
                if (inverted == false)
                {
                    inverted = true;
                    m_CharacterController.transform.Rotate(180, 180, 0);
                    m_CharacterController.transform.Translate(0, -3, 0);
                    Physics.gravity = new Vector3(0, -9.81f, 0);
                }
                else
                {
                    inverted = false;
                    m_CharacterController.transform.Rotate(180, 180, 0);
                    m_CharacterController.transform.Translate(0, -3, 0);
                    Physics.gravity = new Vector3(0, -9.81f, 0);
                }
            }
            if (inverted == false)
            {
                m_MoveDir -= Physics.gravity * m_GravityMultiplier * Time.deltaTime;
            }

            else
            {
                m_MoveDir += Physics.gravity * m_GravityMultiplier * Time.deltaTime;
            }

            m_CollisionFlags = m_CharacterController.Move(m_MoveDir * Time.fixedDeltaTime);

            //ProgressStepCycle(speed);
            UpdateCameraPosition(speed);
        }



        void PushOB(float offset)
        {
            Vector3 pos = transform.position;
            pos.z += offset;
            transform.position = pos;
        }
        void switchLane(float offset)
        {
            Vector3 pos = transform.position;
            pos.x += offset;
            transform.position = pos;
        }

        //Umiejentnosci
        /*if (Input.GetButtonDown("Invert Gravity"))  <<----- Odwracanie gravitacji
            {
                if (inverted == false)
                {
                    inverted = true;
                    m_CharacterController.transform.Rotate(180, 180, 0);
                    m_CharacterController.transform.Translate(0, -3, 0);
                    Physics.gravity = new Vector3(0, -9.81f, 0);
                }
                else
                {
                    inverted = false;
                    m_CharacterController.transform.Rotate(180, 180, 0);
                    m_CharacterController.transform.Translate(0, -3, 0);
                    Physics.gravity = new Vector3(0,-9.81f,0);
                }
            }
            if (inverted == false)
            {
                m_MoveDir -= Physics.gravity * m_GravityMultiplier * Time.deltaTime;
            }
            */

        
    
        



        //Movement

        /*private void ProgressStepCycle(float speed)
        {
            if (m_CharacterController.velocity.sqrMagnitude > 0 && (m_Input.x != 0 || m_Input.y != 0))
            {
                m_StepCycle += (m_CharacterController.velocity.magnitude + (speed*(m_IsWalking ? 1f : m_RunstepLenghten)))*
                             Time.fixedDeltaTime;
            }

            if (!(m_StepCycle > m_NextStep))
            {
                return;
            }

            m_NextStep = m_StepCycle + m_StepInterval;

            PlayFootStepAudio();
        }*/

        private void GetInput(out float speed)
        {

            bool waswalking = m_IsWalking;

#if !MOBILE_INPUT
            // On standalone builds, walk/run speed is modified by a key press.
            // keep track of whether or not the character is walking or running
            // m_IsWalking = !Input.GetKey(KeyCode.LeftShift);  -- blokada shifta
#endif
            // set the desired speed to be walking or running
            speed = /*m_IsWalking ? m_WalkSpeed :*/ m_RunSpeed; //-- ustawienie szybkoœci chodu
            m_Input = new Vector2(horizontal, vertical);

            // normalize input if it exceeds 1 in combined length:
            if (m_Input.sqrMagnitude > 1)
            {
                m_Input.Normalize();
            }

            // handle speed change to give an fov kick
            // only if the player is going to a run, is running and the fovkick is to be used
            if (m_IsWalking != waswalking && m_UseFovKick && m_CharacterController.velocity.sqrMagnitude > 0)
            {
                StopAllCoroutines();
                StartCoroutine(!m_IsWalking ? m_FovKick.FOVKickUp() : m_FovKick.FOVKickDown());
            }
        }
        //Camera
        private void RotateView() //SterowanieMysz¹ - Depr
        {
            m_MouseLook.LookRotation (transform, m_Camera.transform);
        }

        private void UpdateCameraPosition(float speed)//Head Bob
        {
            Vector3 newCameraPosition;
            if (!m_UseHeadBob)
            {
                return;
            }
            if (m_CharacterController.velocity.magnitude > 0 && m_CharacterController.isGrounded)
            {
                m_Camera.transform.localPosition =
                    m_HeadBob.DoHeadBob(m_CharacterController.velocity.magnitude +
                                      (speed * (m_IsWalking ? 1f : m_RunstepLenghten)));
                newCameraPosition = m_Camera.transform.localPosition;
                newCameraPosition.y = m_Camera.transform.localPosition.y - m_JumpBob.Offset();
            }
            else
            {
                newCameraPosition = m_Camera.transform.localPosition;
                newCameraPosition.y = m_OriginalCameraPosition.y - m_JumpBob.Offset();
            }
            m_Camera.transform.localPosition = newCameraPosition;
        }

        //Audio
        private void PlayFootStepAudio()
        {
            if (!m_CharacterController.isGrounded)
            {
                return;
            }
            // pick & play a random footstep sound from the array,
            // excluding sound at index 0
            int n = Random.Range(1, m_FootstepSounds.Length);
            m_AudioSource.clip = m_FootstepSounds[n];
            m_AudioSource.PlayOneShot(m_AudioSource.clip);
            // move picked sound to index 0 so it's not picked next time
            m_FootstepSounds[n] = m_FootstepSounds[0];
            m_FootstepSounds[0] = m_AudioSource.clip;
        }
        private void PlayJumpSound()
        {
            m_AudioSource.clip = m_JumpSound;
            m_AudioSource.Play();
        }

        private void PlayLandingSound()
        {
            m_AudioSource.clip = m_LandSound;
            m_AudioSource.Play();
            m_NextStep = m_StepCycle + .5f;
        }

        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            Rigidbody body = hit.collider.attachedRigidbody;
            //dont move the rigidbody if the character is on top of it
            if (m_CollisionFlags == CollisionFlags.Below)
            {
                return;
            }

            if (body == null || body.isKinematic)
            {
                if (hit.gameObject.tag == "Destr")
                {
                    if (isCharging == true)
                    {
                        Destroy(hit.gameObject);
                    }
                }
            }

            body.AddForceAtPosition(m_CharacterController.velocity*0.1f, hit.point, ForceMode.Impulse);
        }
    }
}
