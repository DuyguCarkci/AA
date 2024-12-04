using System;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private ColorManager _colorManager;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        OnStart();
    }

    public void OnStart()
    {
        LevelManager.Instance.OnStartLevel();
        _colorManager.SetNormal();
    }

    public void OnGameOver()
    {
        Debug.Log("Game Over! Seviyeler sýfýrlanacak.");
        Time.timeScale = 1; // Oyunun durmasý durumunda zamaný yeniden baþlat
         _colorManager.SetNormal();

        LevelManager.Instance.ResetLevels();
    }

    public void OnSuccess()
    {
        Debug.Log("Seviye baþarýyla tamamlandý, sonraki seviyeye geçiliyor...");
        _colorManager.OnSuccess();

        IEnumerator Do()
        {
            yield return new WaitForSeconds(1);
            Debug.Log("Yeni seviye baþlatýlýyor...");
            OnStart();
        }

        StartCoroutine(Do());
    }
}
