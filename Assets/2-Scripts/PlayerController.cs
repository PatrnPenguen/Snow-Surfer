using UnityEngine;
using UnityEngine.InputSystem;

namespace _2_Scripts
{
    public class PlayerController : MonoBehaviour
    {
        InputAction moveAction;
        Vector2 moveVector;
        Rigidbody2D rb;
        SurfaceEffector2D surfEffector;
        [SerializeField] ParticleSystem powerParticle;
        
        [SerializeField] float torqueAmount = 7f;
        [SerializeField] float baseSpeed = 10f;
        [SerializeField] float boostSpeed = 15f;
        
        bool canMove = true;
        
        float previousRotation;
        float totalRotation;
        
        [SerializeField] ScoreManager scoreManager;
        void Start()
        {
            moveAction = InputSystem.actions.FindAction("Move");
            rb = GetComponent<Rigidbody2D>();
            surfEffector = FindFirstObjectByType<SurfaceEffector2D>();
        }
        void Update()
        {
            if (canMove)
            {
               RotatePlayer();
               BoostPlayer(); 
               CalculateFlip();
            }
            
        }

        void RotatePlayer()
        {
            moveVector = moveAction.ReadValue<Vector2>();

            if (moveVector.x < 0)
            {
                rb.AddTorque(torqueAmount);
            }
            else if (moveVector.x > 0)
            { 
                rb.AddTorque(-torqueAmount);
            }
        }

        void BoostPlayer()
        {
            if (moveVector.y > 0)
            {
                surfEffector.speed = boostSpeed;
            }
            else
            {
                surfEffector.speed = baseSpeed;
            }
        }

        public void Crashed()
        {
            canMove = false;
        }

        void CalculateFlip()
        {
            float currentRotation = transform.rotation.eulerAngles.z;
            
            totalRotation += Mathf.DeltaAngle(previousRotation, currentRotation);
            
            if (totalRotation > 330f || totalRotation < -330f)
            {
                scoreManager.AddScore(100);
                totalRotation = 0f;
            }
            previousRotation = currentRotation;
        }

        public void ActivatePowerUp(PowerUpSO powerUp)
        {
            powerParticle.Play();
            if (powerUp.GetPowerUpType() == "speed")
            {
                baseSpeed += powerUp.GetPowerUpSpeed();
                boostSpeed += powerUp.GetPowerUpSpeed();
            }

            if (powerUp.GetPowerUpType() == "torque")
            {
                torqueAmount += powerUp.GetPowerUpSpeed();
            }
        }
        
        public void DeactivatePowerUp(PowerUpSO powerUp)
        {
            powerParticle.Stop();
            if (powerUp.GetPowerUpType() == "speed")
            {
                baseSpeed -= powerUp.GetPowerUpSpeed();
                boostSpeed -= powerUp.GetPowerUpSpeed();
            }

            if (powerUp.GetPowerUpType() == "torque")
            {
                torqueAmount -= powerUp.GetPowerUpSpeed();
            }
        }
    }
}
