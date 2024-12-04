using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public static BulletManager Instance;

    public int bulletRemain = 5;  // Baþlangýçta 5 mermi olacak
    public GameObject bulletPrefab;  // Mermi prefab'ý
    public Transform spawnPoint;     // Merminin nereden çýkacaðýný belirleyen nokta

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;  // Bu objenin singleton olarak tek bir instance olmasýný saðlýyoruz
        }
        else
        {
            Destroy(gameObject);  // Ayný objenin kopyasý varsa yok et
        }
    }

    // Mermiyi spawn et ve hareket ettir
    public void SpawnAndMove()
    {
        if (bulletRemain > 0)
        {
            bulletRemain--;  // Mermi fýrlatýldýkça kalan mermi sayýsýný bir azalt
            Debug.Log("Bullet spawned! Remaining bullets: " + bulletRemain);

            // Mermiyi sahneye instantiate et
            GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);

            // Merminin hareket etmesini saðla
            BulletController bulletController = bullet.GetComponent<BulletController>();
            if (bulletController != null)
            {
                bulletController.MoveBullet();  // Merminin hareket etmesini saðla
            }
        }
        else
        {
            Debug.LogWarning("No bullets to shoot!");
        }
    }

    // Bu fonksiyon mermiyi sýfýrlamak için kullanýlabilir
    public void ResetBullets()
    {
        bulletRemain = 5;  // Örneðin mermi sayýsýný 5'e sýfýrlýyoruz
        Debug.Log("Bullets reset to " + bulletRemain);
    }
}
