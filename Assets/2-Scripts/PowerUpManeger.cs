using System;
using System.Timers;
using _2_Scripts;
using UnityEngine;

public class PowerUpManeger : MonoBehaviour
{
    [SerializeField] PowerUpSO powerUp;
    PlayerController player;
    SpriteRenderer spriteRenderer;
    float timeLeft;

    void Start()
    {
        player = FindFirstObjectByType<PlayerController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Timer();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        int layerIndex = LayerMask.NameToLayer("Player");
        if (other.gameObject.layer == layerIndex && spriteRenderer.enabled)
        {
            timeLeft = powerUp.GetPowerUpDuration();
            player.ActivatePowerUp(powerUp);
            spriteRenderer.enabled = false;
        }
    }

    

    void Timer()
    {
        if (!spriteRenderer.enabled)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                
                if (timeLeft <= 0)
                {
                    player.DeactivatePowerUp(powerUp);
                }
            }

            
        }
    }
}