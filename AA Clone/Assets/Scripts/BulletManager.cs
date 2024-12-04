using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public static BulletManager Instance;

    public int bulletRemain = 5;  // Ba�lang��ta 5 mermi olacak
    public GameObject bulletPrefab;  // Mermi prefab'�
    public Transform spawnPoint;     // Merminin nereden ��kaca��n� belirleyen nokta

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;  // Bu objenin singleton olarak tek bir instance olmas�n� sa�l�yoruz
        }
        else
        {
            Destroy(gameObject);  // Ayn� objenin kopyas� varsa yok et
        }
    }

    // Mermiyi spawn et ve hareket ettir
    public void SpawnAndMove()
    {
        if (bulletRemain > 0)
        {
            bulletRemain--;  // Mermi f�rlat�ld�k�a kalan mermi say�s�n� bir azalt
            Debug.Log("Bullet spawned! Remaining bullets: " + bulletRemain);

            // Mermiyi sahneye instantiate et
            GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);

            // Merminin hareket etmesini sa�la
            BulletController bulletController = bullet.GetComponent<BulletController>();
            if (bulletController != null)
            {
                bulletController.MoveBullet();  // Merminin hareket etmesini sa�la
            }
        }
        else
        {
            Debug.LogWarning("No bullets to shoot!");
        }
    }

    // Bu fonksiyon mermiyi s�f�rlamak i�in kullan�labilir
    public void ResetBullets()
    {
        bulletRemain = 5;  // �rne�in mermi say�s�n� 5'e s�f�rl�yoruz
        Debug.Log("Bullets reset to " + bulletRemain);
    }
}
