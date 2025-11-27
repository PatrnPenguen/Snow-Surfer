using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FinishLine : MonoBehaviour
{
    [SerializeField] ParticleSystem finishParticle;
    private void OnTriggerEnter2D(Collider2D other)
    {
        int layerIndex = LayerMask.NameToLayer("Player");
        if (other.gameObject.layer == layerIndex)
        {
            finishParticle.Play();
            Invoke("LoadScene", 1f);
        }
    }
    void LoadScene()
    {
        SceneManager.LoadScene(0);
    }
}
