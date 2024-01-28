

using TMPro;
using UnityEngine;
using UnityEngine.UI;

class UIManager : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private PlayerStats stats;

    [Header("Bars")]
    [SerializeField] private Image healthBar;

    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI flowersTMP;
    [SerializeField] private TextMeshProUGUI healthTMP;

    void Update()
    {
        UpdatePlayerUI();
    }

    private void UpdatePlayerUI()
    {
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, stats.Health / stats.MaxHealth, 10f * Time.deltaTime);

        flowersTMP.text = $"{stats.Cottons} / {stats.MaxCottons}";
        healthTMP.text = $"{stats.Health} / {stats.MaxHealth}";
    }
}