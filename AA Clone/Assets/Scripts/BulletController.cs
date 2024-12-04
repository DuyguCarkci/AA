using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 10f;

    // Merminin hareketini ba�latacak fonksiyon
    public void MoveBullet()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.up * speed;
        }
    }

    // Bu fonksiyon, merminin tamamland��� veya ba�ar�yla tamamland��� durumlarda �a�r�labilir
    public void OnCompleted()
    {
        // Merminin tamamlanma durumu
        Debug.Log("Mermi tamamland�.");
        Destroy(gameObject);  // Mermiyi yok et (�rne�in, hedefe �arpt�ysa)
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnCompleted();  // �arp��ma durumunda tamamlanmay� tetikle
    }
}
