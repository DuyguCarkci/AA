using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 10f;

    // Merminin hareketini başlatacak fonksiyon
    public void MoveBullet()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.up * speed;
        }
    }

    // Bu fonksiyon, merminin tamamlandığı veya başarıyla tamamlandığı durumlarda çağrılabilir
    public void OnCompleted()
    {
        // Merminin tamamlanma durumu
        Debug.Log("Mermi tamamlandı.");
        Destroy(gameObject);  // Mermiyi yok et (örneğin, hedefe çarptıysa)
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnCompleted();  // Çarpışma durumunda tamamlanmayı tetikle
    }
}
