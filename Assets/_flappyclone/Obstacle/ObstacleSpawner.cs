using System;
using System.Collections.Generic;
using System.Linq;
using _flappyclone.Game_Manager;
using _flappyclone.Obstacles;
using UnityEngine;

namespace _flappyclone.Obstacle
{
    public class ObstacleSpawner : MonoBehaviour
    {
        [SerializeField] private float timeBetweenSpawn;
        [SerializeField] private GameObject prefab;

        private List<GameObject> currentObstacles = new List<GameObject>();

        private float _timer;

        public void RemoveFromList(GameObject me)
        {
            currentObstacles.Remove(me);
        }

        public void DeleteAll()
        {
            foreach (GameObject obj in currentObstacles)
            {
                Destroy(obj);
            }
        }
        private void Update()
        {
            if (GameManager.Instance.IsPaused() == false) 
            {
                _timer += Time.deltaTime;

                if (_timer >= timeBetweenSpawn)
                {
                    GameObject spawned = Instantiate(prefab);
                    List<Collide> colliders = new List<Collide>();

                    colliders = spawned.GetComponentsInChildren<Collide>().ToList();

                    foreach (Collide col in colliders)
                    {
                        col.Init(this);
                    }
                    
                    currentObstacles.Add(spawned);
                    float yMod = UnityEngine.Random.Range(-3, 3);
                    spawned.transform.position = new Vector2(transform.position.x, transform.position.y + yMod);
                    _timer = 0;
                }
            }
        }
    }
}
