using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Scripts.PlayerScripts
{

    [RequireComponent(typeof(PlayerLocomotion), typeof(CharacterController), typeof(PlayerCameraController))]
    [RequireComponent(typeof(WeaponScript))]
    public class PlayerController : MonoBehaviour
    {        
        private SimpleControls playerInput;
        private SimpleControls.GameplayActions gameplayActions;
        private PlayerLocomotion playerMovement;
        private PlayerCameraController camController;
        private WeaponScript weaponScript;
        private void Awake()
        {
            playerInput = new SimpleControls();
            //camera 
            camController = GetComponent<PlayerCameraController>();
            gameplayActions = playerInput.gameplay;
            playerMovement = GetComponent<PlayerLocomotion>();
            weaponScript = GetComponent<WeaponScript>();

            //ctx is callback context
            gameplayActions.fire.performed += ctx => playerMovement.FireWeapon(ctx);
            gameplayActions.jump.performed += ctx => playerMovement.Jump();
            //sprinting
            gameplayActions.sprint.canceled += ctx => playerMovement.Sprint(false);
            gameplayActions.sprint.performed += ctx => playerMovement.Sprint(true);

            //fourth part: changing weapons use numbers or d pad
            gameplayActions.SwitchWeaponPistol.performed += ctx => weaponScript.SelectWeapon(0);
            gameplayActions.SwitchWeaponRifle.performed += ctx => weaponScript.SelectWeapon(1);

            //changing camera 
            gameplayActions.switchCamera.performed += ctx => camController.SwitchCamera();

        }

        private void Update()
        {
            playerMovement.Move(gameplayActions.move.ReadValue<Vector2>());
        }


        private void OnEnable()
        {
            gameplayActions.Enable();
        }
        private void OnDisable()
        {
            gameplayActions.Disable();
        }
        //late update is called after the update position has ended
        private void LateUpdate()
        {
            camController.ProcessLook(gameplayActions.look.ReadValue<Vector2>());
        }   

        /// <summary>
        /// OnCollisionEnter is called when this collider/rigidbody has begun
        /// touching another rigidbody/collider.
        /// </summary>
        /// <param name="other">The Collision data associated with this collision.</param>
        void OnCollisionEnter(Collision other)
        {
            if(other.gameObject.tag == "bullet")
            {
                ///health --
                //call healthscript component
                //other getcomponent<BulletScript> get Bullet Value
                //healthscript damage taken (bullet Value)
            }
            if(other.gameObject.tag == "Medkit")
            {
                //health ++
                //call healthScript component
                //other GetComponent<Medkit> get value
                //healthScript RegenHealth (value)
            }
        }

    }

}
