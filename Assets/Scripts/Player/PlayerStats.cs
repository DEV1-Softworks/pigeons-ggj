using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Player Stats")]
public class PlayerStats : ScriptableObject
{
    [Header("Health")]
    public float Health;
    public float MaxHealth;

    [Header("Energy")]
    public float Energy;
    public float MaxEnergy;

    [Header("Cottons")]
    public float Cottons;
    public float MaxCottons;

    public void ResetPlayer()
    {
        Health = MaxHealth;
        Cottons = MaxCottons;
        Energy = MaxEnergy;
    }
}
