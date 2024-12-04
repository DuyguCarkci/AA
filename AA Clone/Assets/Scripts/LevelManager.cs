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

    // Seviye tamamland�ysa �al��acak metot
    public void OnFinishLevel()
    {
        isLevelCompleted = true;
        Debug.Log("Level Finished!");
    }

    // SetNormal metodunu buraya ekleyin
    public void SetNormal()
    {
        // Normal bir seviye ba�latmak i�in gerekli i�lemleri yap�n
        Debug.Log("Set Normal");
    }

    // Seviye tamamland���n� kontrol etme
    public bool IsLevelCompleted()
    {
        return isLevelCompleted;
    }

    // Yeni bir seviyeyi ba�latma
    public void OnStartLevel()
    {
        isLevelCompleted = false;
        Debug.Log("Level Started!");
    }

    // Seviyeyi s�f�rlama i�lemleri
    public void ResetLevels()
    {
        isLevelCompleted = false;
        Debug.Log("Levels reset.");
    }
}
