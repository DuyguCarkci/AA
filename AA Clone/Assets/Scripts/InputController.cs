using UnityEngine;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        // BulletManager'dan gelen mermi say�s�n� kontrol et
        if (BulletManager.Instance.bulletRemain > 0)
        {
            BulletManager.Instance.SpawnAndMove();  // Mermi varsa, f�rlat
        }
        else
        {
            Debug.LogWarning("No bullets to shoot!");  // Mermi yoksa uyar� ver
        }
    }
}
