using UnityEngine;
using System.Collections;
using Photon.Pun;


namespace Com.MyCompany.MyGame
{
    public class PlayerAnimatorManager : MonoBehaviourPun
    {
        // MonoBehaviour Callbacks

        // Private serializable variables
        [SerializeField]
        private float directionDampTime = 0.25f;

        // Private Variables
        private Animator _Animator;

        // Use this for initialization
        void Start()
        {
            _Animator = GetComponent<Animator>();
            if (!_Animator)
            {
                Debug.LogError("PlayerAnimatorManager is Missing Animator Component", this);
            }
        }

        // Update is called once per frame
        void Update()
        {
            // Checking whose prefab is it
            if (photonView.IsMine == false && PhotonNetwork.IsConnected == true)
            {
                return;
            }

            // Reads user input and control the speed
            if (!_Animator)
            {
                return;
            }

            // deal with Jumping
            AnimatorStateInfo stateInfo = _Animator.GetCurrentAnimatorStateInfo(0);
            // only allow jumping if we are running.
            if (stateInfo.IsName("Base Layer.Run"))
            {
                // When using trigger parameter
                if (Input.GetButtonDown("Fire2"))
                {
                    _Animator.SetTrigger("Jump");
                }
            }

            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            if (v < 0)
            {
                v = 0;
            }
            _Animator.SetFloat("Speed", h * h + v * v);

            _Animator.SetFloat("Direction", h, directionDampTime, Time.deltaTime);
        }

    }
}
