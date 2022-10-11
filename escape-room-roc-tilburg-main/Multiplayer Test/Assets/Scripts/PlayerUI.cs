using UnityEngine;
using UnityEngine.UI;
using System.Collections;


namespace Com.MyCompany.MyGame
{
    public class PlayerUI : MonoBehaviour
    {
        // Private Fields

        [Tooltip("UI Text to display Player's Name")]
        [SerializeField]
        private Text playerNameText;

        [Tooltip("UI Slider to display Player's Health")]
        [SerializeField]
        private Slider playerHealthSlider;

        private PlayerManager _Target;

        private float _CharacterControllerHeight = 0f;
        private Transform _TargetTransform;
        private Renderer _TargetRenderer;
        private CanvasGroup _CanvasGroup;
        private Vector3 _TargetPosition;

        // Public Fields
        [Tooltip("Pixel offset from the player target")]
        [SerializeField]
        private Vector3 _ScreenOffset = new Vector3(0f, 30f, 0f);


        // MonoBehaviour Callbacks
        void Update()
        {
            // Reflect the Player Health
            if (playerHealthSlider != null)
            {
                playerHealthSlider.value = _Target.Health;
            }

            // Destroy itself if the target is null, It's a fail safe when Photon is destroying Instances of a Player over the network
            if (_Target == null)
            {
                Destroy(this.gameObject);
                return;
            }
        }

        void Awake()
        {
            _CanvasGroup = this.GetComponent<CanvasGroup>();
            this.transform.SetParent(GameObject.Find("Canvas").GetComponent<Transform>(), false);
        }

        void LateUpdate()
        {
            // Do not show the UI if we are not visible to the camera, thus avoid potential bugs with seeing the UI, but not the player itself.
            if (_TargetRenderer != null)
            {
                this._CanvasGroup.alpha = _TargetRenderer.isVisible ? 1f : 0f;
            }


            // #Critical
            // Follow the Target GameObject on screen.
            if (_TargetTransform != null)
            {
                _TargetPosition = _TargetTransform.position;
                _TargetPosition.y += _CharacterControllerHeight;
                this.transform.position = Camera.main.WorldToScreenPoint(_TargetPosition) + _ScreenOffset;
            }
        }

        // Public Methods
        public void SetTarget(PlayerManager target)
        {
            if (target == null)
            {
                Debug.LogError("<Color=Red><a>Missing</a></Color> PlayMakerManager target for PlayerUI.SetTarget.", this);
                return;
            }
            // Cache references for efficiency
            _Target = target;

            _TargetTransform = this._Target.GetComponent<Transform>();
            _TargetRenderer = this._Target.GetComponent<Renderer>();
            CharacterController characterController = _Target.GetComponent<CharacterController>();
            // Get data from the Player that won't change during the lifetime of this Component
            if (characterController != null)
            {
                _CharacterControllerHeight = characterController.height;
            }

            if (playerNameText != null)
            {
                playerNameText.text = _Target.photonView.Owner.NickName;
            }
        }
    }
}