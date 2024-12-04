using UnityEngine;

public class CenterCollider : MonoBehaviour
{
    // BulletController component'ine eri�im sa�lamak i�in
    private void OnTriggerEnter2D(Collider2D other)
    {
        // E�er �arpan obje BulletController i�eriyorsa
        BulletController bulletController = other.GetComponent<BulletController>();
        if (bulletController != null)
        {
            bulletController.OnCompleted();  // OnCompleted fonksiyonunu �a��r
        }
    }
}
