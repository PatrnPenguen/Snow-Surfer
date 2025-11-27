using System;
using _2_Scripts;
using UnityEngine;

public class SnowTrail : MonoBehaviour
{
    [SerializeField] ParticleSystem snowTrail;
    private int floorLayer;
    PlayerController playerController;
    bool crashed = false;

    void Start()
    {
       playerController = FindFirstObjectByType<PlayerController>(); 
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        floorLayer = LayerMask.NameToLayer("Floor");
        if (other.gameObject.layer == floorLayer && !crashed)
        {
            snowTrail.Play();
        }
        
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.layer == floorLayer)
        {
            snowTrail.Stop();
        }
    }

    public void StopSnowTrail()
    {
        crashed = true;
    }
}
