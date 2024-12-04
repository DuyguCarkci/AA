using System;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public static BulletManager Instance { get; private set; }

    [SerializeField] private Transform target;
    [SerializeField] private Transform home;

    [SerializeField] private BulletController bulletPrefab;
    [Range(0, 1)][SerializeField] private float moveTime;

    public int bulletRemain;

    private void Awake()
    {
        Instance = this;
    }

    public void SpawnAndMove()
    {
        if (bulletRemain == 0)
        {
            Debug.Log("Mermi kalmad�. Seviye tamamland� m� kontrol ediliyor...");
            if (LevelManager.Instance.IsLevelCompleted())
            {
                Debug.Log("Seviye tamamland�! OnFinishLevel �a�r�l�yor.");
                LevelManager.Instance.OnFinishLevel();
            }
            else
            {
                Debug.Log("Seviye tamamlanmad�.");
            }
            return;
        }

        // Mermi olu�turuluyor
        var bullet = Instantiate(bulletPrefab, home.position, Quaternion.identity);

        // Bullet Center objesini bul ve bullet'�n parent'� yap
        var bulletCenter = GameObject.Find("Center");
        if (bulletCenter != null)
        {
            bullet.transform.SetParent(bulletCenter.transform);
        }

        // Bullet �zelliklerini ba�lat ve hareket ettir
        bullet.MyStart(bulletRemain);
        bullet.Move(target.position, moveTime);
        bulletRemain--;

        Debug.Log($"Mermi olu�turuldu ve hareket ettirildi. Kalan mermi: {bulletRemain}");
    }
}
