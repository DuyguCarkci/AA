using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    private bool isLevelCompleted = false;

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

    // Seviye tamamlandýysa çalýþacak metot
    public void OnFinishLevel()
    {
        isLevelCompleted = true;
        Debug.Log("Level Finished!");
    }

    // SetNormal metodunu buraya ekleyin
    public void SetNormal()
    {
        // Normal bir seviye baþlatmak için gerekli iþlemleri yapýn
        Debug.Log("Set Normal");
    }

    // Seviye tamamlandýðýný kontrol etme
    public bool IsLevelCompleted()
    {
        return isLevelCompleted;
    }

    // Yeni bir seviyeyi baþlatma
    public void OnStartLevel()
    {
        isLevelCompleted = false;
        Debug.Log("Level Started!");
    }

    // Seviyeyi sýfýrlama iþlemleri
    public void ResetLevels()
    {
        isLevelCompleted = false;
        Debug.Log("Levels reset.");
    }
}
