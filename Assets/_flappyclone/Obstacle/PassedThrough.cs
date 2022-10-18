using System;
using _flappyclone.Game_Manager;
using UnityEngine;

namespace _flappyclone.Obstacle
{
    public class PassedThrough : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.transform.CompareTag("Player"))
            {
                GameManager.Instance.IncreaseScore();
            }
        }
    }
}
