using System;
using _flappyclone.Game_Manager;
using _flappyclone.input;
using TMPro;
using UnityEngine;

namespace _flappyclone.Menu
{
    public class UiManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private Transform newGameMenu;
        [SerializeField] private Transform pauseMenu;
        [SerializeField] private Transform deathText;
        
        [SerializeField] private InputReader inputReader;

        private void Awake()
        {
            inputReader.MenuPressedEvent += MenuButtonPressed;
            DeactivateMenus();
            ToggleNewGameMenu(true);
        }

        private void Update()
        {
            scoreText.text = "Score " + GameManager.Instance.GetScore();
        }

        private void MenuButtonPressed()
        {
            if (!GameManager.Instance.IsPaused())
                GameManager.Instance.Pause();
            else
                GameManager.Instance.UnPause();
        }

        public void StartGameBtn()
        {
            GameManager.Instance.StartGame();
            DeactivateMenus();
        }
        
        public void TogglePauseMenu(bool option)
        {
            DeactivateMenus();
            pauseMenu.gameObject.SetActive(option);
        }

        public void ToggleNewGameMenu(bool option)
        {
            DeactivateMenus();
            newGameMenu.gameObject.SetActive(option);
        }

        public void ToggleDeathText(bool option)
        {
            DeactivateMenus();
            deathText.gameObject.SetActive(option);
        }

        private void DeactivateMenus()
        {
            pauseMenu.gameObject.SetActive(false);
            newGameMenu.gameObject.SetActive(false);
            deathText.gameObject.SetActive(false);
        }
    }
}