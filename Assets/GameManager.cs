using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Kill Tracking")]
    public int totalLionfish = 0;
    private int killedLionfish = 0;

    [Header("UI Elements")]
    public TextMeshProUGUI counterText;
    public GameObject congratsPanel;

    private void Awake()
    {
        // Singleton setup
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        // Hide congratulations UI at start
        if (congratsPanel != null)
        {
            congratsPanel.SetActive(false);
        }
    }

    private void Start()
    {
        // Auto-count lionfish if not manually set
        if (totalLionfish == 0)
        {
            GameObject[] lionfishObjects = GameObject.FindGameObjectsWithTag("Lionfish");
            totalLionfish = lionfishObjects.Length;
        }

        UpdateCounterUI();
    }

    public void RegisterKill()
    {
        killedLionfish++;
        UpdateCounterUI();

        if (killedLionfish >= totalLionfish)
        {
            ShowWinPopup();
        }
    }

    private void UpdateCounterUI()
    {
        if (counterText != null)
        {
            counterText.text = $"{killedLionfish} / {totalLionfish}";
        }
    }

    private void ShowWinPopup()
    {
        if (congratsPanel != null)
        {
            congratsPanel.SetActive(true);
        }
    }
}
