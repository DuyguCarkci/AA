using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    [SerializeField] private TextMeshPro TextLevel;  // UI Text öðesi

    public void MyStart(int level)
    {
        if (TextLevel == null)
        {
            Debug.LogError("TextLevel is not assigned in the Inspector!");
        }
        else
        {
            TextLevel.text = "Level: " + level.ToString();
        }
    }

}
