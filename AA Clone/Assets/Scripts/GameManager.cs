using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private LevelManager _levelManager;  // LevelManager referans�

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
        _levelManager.OnStartLevel();  // Seviye ba�latma i�lemi
    }

    public void OnGameOver()
    {
        Debug.Log("Game Over! Seviyeler s�f�rlanacak.");
        _levelManager.ResetLevels();  // Seviye s�f�rlama i�lemi
    }

    public void OnSuccess()
    {
        Debug.Log("Seviye ba�ar�yla tamamland�, sonraki seviyeye ge�iliyor...");
        _levelManager.OnFinishLevel();  // Seviye bitirme i�lemi
    }
}
