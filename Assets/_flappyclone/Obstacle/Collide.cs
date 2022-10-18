using System;
using _flappyclone.Game_Manager;
using _flappyclone.Obstacle;
using _flappyclone.player;
using UnityEngine;

namespace _flappyclone.Obstacles
{
    public class Collide : MonoBehaviour
    {

        public bool isObstacle;
        private float _timer;
        private float _timeToDestroy = 5f;

        private ObstacleSpawner _obstacleSpawner;

        public void Init(ObstacleSpawner os)
        {
            _obstacleSpawner = os;
        }
        
        private void Update()
        {
            if (!GameManager.Instance.IsPaused() )
            {
                _timer += Time.deltaTime;
            }
            
            if (_timer >= _timeToDestroy)
            {
                if (isObstacle)
                {
                    _obstacleSpawner.RemoveFromList(gameObject);
                    Destroy(gameObject);
                }
                   
            }
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.transform.CompareTag("Player"))
            {
                col.gameObject.GetComponent<PlayerController>().Die();
            }
        }
    }
}
