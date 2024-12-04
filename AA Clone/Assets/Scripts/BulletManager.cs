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
            Debug.Log("Mermi kalmadý. Seviye tamamlandý mý kontrol ediliyor...");
            if (LevelManager.Instance.IsLevelCompleted())
            {
                Debug.Log("Seviye tamamlandý! OnFinishLevel çaðrýlýyor.");
                LevelManager.Instance.OnFinishLevel();
            }
            else
            {
                Debug.Log("Seviye tamamlanmadý.");
            }
            return;
        }

        // Mermi oluþturuluyor
        var bullet = Instantiate(bulletPrefab, home.position, Quaternion.identity);

        // Bullet Center objesini bul ve bullet'ýn parent'ý yap
        var bulletCenter = GameObject.Find("Center");
        if (bulletCenter != null)
        {
            bullet.transform.SetParent(bulletCenter.transform);
        }

        // Bullet özelliklerini baþlat ve hareket ettir
        bullet.MyStart(bulletRemain);
        bullet.Move(target.position, moveTime);
        bulletRemain--;

        Debug.Log($"Mermi oluþturuldu ve hareket ettirildi. Kalan mermi: {bulletRemain}");
    }
}
