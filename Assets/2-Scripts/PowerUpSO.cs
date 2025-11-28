using UnityEngine;

[CreateAssetMenu(fileName = "PowerUpSO", menuName = "Scriptable Objects/PowerUpSO")]
public class PowerUpSO : ScriptableObject
{
    [SerializeField] string powerUpType;
    [SerializeField] float powerUpSpeed;
    [SerializeField] float powerUpDuration;

    public string GetPowerUpType()
    {
        return powerUpType;
    }

    public float GetPowerUpSpeed()
    {
        return powerUpSpeed;
    }

    public float GetPowerUpDuration()
    {
        return powerUpDuration;
    }
}
