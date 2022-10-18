using System;
using _flappyclone.Game_Manager;
using UnityEngine;
using _flappyclone.input;

namespace _flappyclone.player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private int jumpForce;

        [SerializeField] private InputReader inputReader;

        [SerializeField] private GameObject deathParticles;
        
        private Rigidbody2D _rigidbody2D;
        private SpriteRenderer _spriteRenderer;

        public Transform spawnPoint;
        
        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            inputReader.JumpPressedEvent += Jump;
        }

        private void Update()
        {
            if (GameManager.Instance.IsPaused())
            {
                _rigidbody2D.isKinematic = true;
                _rigidbody2D.velocity = Vector2.zero;
            }
            else
            {
                _rigidbody2D.isKinematic = false;
            }
        }

        private void Jump()
        {
            if (!GameManager.Instance.IsPaused())
            {
                _rigidbody2D.velocity = Vector2.up * jumpForce;
            }
        }

        public void Die()
        {
            _spriteRenderer.enabled = false;
            GameObject particles = Instantiate(deathParticles);
            Destroy(particles, 1f);
            particles.transform.position = transform.position;
            GameManager.Instance.Die();
        }

        public void Restart()
        {
            _rigidbody2D.velocity = Vector2.zero;
            transform.position = spawnPoint.position;
            _spriteRenderer.enabled = true;
        }
    }
}
