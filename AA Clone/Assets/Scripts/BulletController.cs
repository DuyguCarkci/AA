using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 10f;

    // Merminin hareketini baþlatacak fonksiyon
    public void MoveBullet()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.up * speed;
        }
    }

    // Bu fonksiyon, merminin tamamlandýðý veya baþarýyla tamamlandýðý durumlarda çaðrýlabilir
    public void OnCompleted()
    {
        // Merminin tamamlanma durumu
        Debug.Log("Mermi tamamlandý.");
        Destroy(gameObject);  // Mermiyi yok et (örneðin, hedefe çarptýysa)
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnCompleted();  // Çarpýþma durumunda tamamlanmayý tetikle
    }
}
