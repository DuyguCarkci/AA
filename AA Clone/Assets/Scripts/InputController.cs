using UnityEngine;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        // BulletManager'dan gelen mermi sayýsýný kontrol et
        if (BulletManager.Instance.bulletRemain > 0)
        {
            BulletManager.Instance.SpawnAndMove();  // Mermi varsa, fýrlat
        }
        else
        {
            Debug.LogWarning("No bullets to shoot!");  // Mermi yoksa uyarý ver
        }
    }
}
