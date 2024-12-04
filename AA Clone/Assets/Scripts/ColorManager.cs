using UnityEngine;

public class ColorManager : MonoBehaviour
{
    [SerializeField] private Color normalColor = Color.white;
    [SerializeField] private Color failColor = Color.red;
    [SerializeField] private Color successColor = Color.green;

    private Camera _camera;

    public static object Instance { get; internal set; }

    private void Start()
    {
        _camera = Camera.main; // Camera'ya referans al�yoruz
    }

    public void SetNormal()
    {
        if (_camera != null)
        {
            _camera.backgroundColor = normalColor; // Normal renge ayarl�yoruz
        }
    }

    public void OnFail()
    {
        if (_camera != null)
        {
            _camera.backgroundColor = failColor; // Fail durumuna renk de�i�tiriyoruz
        }
    }

    public void OnSuccess()
    {
        if (_camera != null)
        {
            _camera.backgroundColor = successColor; // Ba�ar� durumuna renk de�i�tiriyoruz
        }
    }
}
