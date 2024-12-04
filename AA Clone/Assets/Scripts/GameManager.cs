using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private LevelManager _levelManager;  // LevelManager referansý

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        OnStart();
    }

    public void OnStart()
    {
        _levelManager.OnStartLevel();  // Seviye baþlatma iþlemi
    }

    public void OnGameOver()
    {
        Debug.Log("Game Over! Seviyeler sýfýrlanacak.");
        _levelManager.ResetLevels();  // Seviye sýfýrlama iþlemi
    }

    public void OnSuccess()
    {
        Debug.Log("Seviye baþarýyla tamamlandý, sonraki seviyeye geçiliyor...");
        _levelManager.OnFinishLevel();  // Seviye bitirme iþlemi
    }
}
