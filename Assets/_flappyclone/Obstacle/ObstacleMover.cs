using System;
using _flappyclone.Game_Manager;
using UnityEngine;
using UnityEngine.Serialization;

namespace _flappyclone.Obstacle
{
    public class ObstacleMover : MonoBehaviour
    {

        [SerializeField] private float speed;

        private void Update()
        {
            if (!GameManager.Instance.IsPaused())
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
        }
    }
}
