using UnityEngine;

public class ColorManager : MonoBehaviour
{
    [SerializeField] private Color normalColor = Color.white;
    [SerializeField] private Color failColor = Color.red;
    [SerializeField] private Color successColor = Color.green;

    [SerializeField] private Camera _camera;

    public static ColorManager Instance { get; internal set; }

   
    public void SetNormal()
    {
        if (_camera != null)
        {
            _camera.backgroundColor = normalColor; // Normal renge ayarlýyoruz
        }
    }

    public void OnFail()
    {
        if (_camera != null)
        {
            _camera.backgroundColor = failColor; // Fail durumuna renk deðiþtiriyoruz
        }
    }

    public void OnSuccess()
    {
        if (_camera != null)
        {
            _camera.backgroundColor = successColor; // Baþarý durumuna renk deðiþtiriyoruz
        }
    }
}
