using UnityEngine;

public class CenterCollider : MonoBehaviour
{
    // BulletController component'ine eriþim saðlamak için
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Eðer çarpan obje BulletController içeriyorsa
        BulletController bulletController = other.GetComponent<BulletController>();
        if (bulletController != null)
        {
            bulletController.OnCompleted();  // OnCompleted fonksiyonunu çaðýr
        }
    }
}
