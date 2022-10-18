using System;
using System.Collections;
using _flappyclone.Menu;
using _flappyclone.Obstacle;
using _flappyclone.player;
using UnityEngine;

namespace _flappyclone.Game_Manager
{
    public class GameManager :  MonoBehaviour
    {
        [SerializeField] private int score;
        
        private bool _isPaused = true;

        private UiManager _uiManager;
        private ObstacleSpawner _obstacleSpawner;
        private PlayerController _playerController;
        public static GameManager Instance { get; private set; }
        private void Awake() 
        {
            if (Instance != null && Instance != this) 
            { 
                Destroy(this); 
            } 
            else 
            { 
                Instance = this; 
            }

            _isPaused = true;
            _playerController = FindObjectOfType<PlayerController>();
            _obstacleSpawner = FindObjectOfType<ObstacleSpawner>();
            _uiManager = FindObjectOfType<UiManager>();
        }

        public void IncreaseScore()
        {
            score++;
        }

        public int GetScore()
        {
            return score;
        }
        public void Pause()
        {
            _isPaused = true;
            _uiManager.TogglePauseMenu(true);
        }
        
        public void UnPause()
        {
            _isPaused = false;
            _uiManager.TogglePauseMenu(false);
        }

        public void Die()
        {
            _uiManager.ToggleDeathText(true);
            _isPaused = true;
            StartCoroutine(GoToMain());
        }

        private IEnumerator GoToMain()
        {
            yield return new WaitForSeconds(1);
            _uiManager.ToggleNewGameMenu(true);
        }
        public bool IsPaused()
        {
            return _isPaused;
        }

        public void StartGame()
        {
            score = 0;
            _obstacleSpawner.DeleteAll();
            _playerController.Restart();
            _isPaused = false;
        }
    }
}