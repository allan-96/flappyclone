using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace _flappyclone.input
{
    [CreateAssetMenu(fileName = "InputReader", menuName = "Game/Input")]
    public class InputReader : ScriptableObject, GameInput.IGameplayActions
    {
        //Gameplay events
        public event UnityAction JumpPressedEvent =  delegate { };
        public event UnityAction MenuPressedEvent = delegate {  };

        private GameInput _gameInput;

        private void OnEnable()
        { 
            if(_gameInput == null)
            {
                _gameInput = new GameInput();
                _gameInput.Gameplay.SetCallbacks(this);
            }

            EnableGameplayInput();
        }
        
        private void OnDisable()
        {
            DisableAllInput();
        }
    
        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Started)
            {
                JumpPressedEvent.Invoke();
            }
        }

        public void OnOpenMenu(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Started)
            {
                MenuPressedEvent.Invoke();
            }
        }

        private void EnableGameplayInput()
        {
            _gameInput.Gameplay.Enable();
        }

        private void DisableAllInput()
        {
            _gameInput.Gameplay.Disable();
        }
    }
}

