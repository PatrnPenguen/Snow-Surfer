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
        
        [SerializeField] float torqueAmount = 7f;
        [SerializeField] float baseSpeed = 10f;
        [SerializeField] float boostSpeed = 15f;
        
        bool canMove = true;
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
    }
}
