using System;
using _2_Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] ParticleSystem craschParticle;
    PlayerController playerController;
    SnowTrail snowTrail;
    void Start()
    {
        playerController = FindFirstObjectByType<PlayerController>();
        snowTrail = FindFirstObjectByType<SnowTrail>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        int floorLayer = LayerMask.NameToLayer("Floor");
        if (other.gameObject.layer == floorLayer)
        {
            playerController.Crashed();
            snowTrail.StopSnowTrail();
            craschParticle.Play();
            Invoke("LoadScene", 1f);
        }
    }
    void LoadScene()
    {
        SceneManager.LoadScene(0);
    }
}
