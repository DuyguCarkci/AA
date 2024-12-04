using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    [SerializeField] private List<LevelController> levelPrefabs;

    private int _index;
    private LevelController _current;

    private void Awake()
    {
        // Singleton kontrol�
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void OnStartLevel()
    {
        if (levelPrefabs == null || levelPrefabs.Count == 0)
        {
            Debug.LogError("Level prefabs listesi bo� veya null!");
            return;
        }

        if (_index < 0 || _index >= levelPrefabs.Count)
        {
            Debug.LogError($"Ge�ersiz seviye indeksi: {_index}");
            return;
        }

        Debug.Log($"Level ba�lat�l�yor. Index: {_index}");
        var prefab = levelPrefabs[_index];
        if (prefab == null)
        {
            Debug.LogError($"Level prefab null! Index: {_index}");
            return;
        }

        _current = Instantiate(prefab);
        _current.MyStart(_index);
    }

    public void OnFinishLevel()
    {
        if (_current == null)
        {
            return;
        }

        _index++;
        Debug.Log($"Seviye tamamland�. Yeni index: {_index}");
        Destroy(_current.gameObject);

        if (GameManager.Instance != null)
        {
            Debug.Log("GameManager mevcut. OnSuccess �a�r�l�yor.");
            GameManager.Instance.OnSuccess();
        }
        else
        {
            Debug.LogError("GameManager.Instance NULL!");
        }
    }

    public bool IsLevelCompleted()
    {
        if (BulletManager.Instance == null)
        {
            Debug.LogError("BulletManager.Instance NULL!");
            return false;
        }

        // Mermiler bitti mi?
        bool isCompleted = BulletManager.Instance.bulletRemain == 0;

        Debug.Log($"Seviye tamamland� kontrol� yap�l�yor. Durum: {isCompleted}");
        return isCompleted;
    }

    public void ResetLevels()
    {
        Debug.Log("Seviyeler s�f�rlan�yor ve ilk seviye ba�lat�l�yor.");
        _index = 0;

        if (_current != null)
        {
            Destroy(_current.gameObject);
        }

        OnStartLevel();
    }
}
