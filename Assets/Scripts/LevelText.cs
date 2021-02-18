using UnityEngine;
using TMPro;

public class LevelText : MonoBehaviour
{
    private TextMeshProUGUI text;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        GameManager.Instance.LevelUp.AddListener(OnLevelUp);
    }

    private void OnLevelUp()
    {
        text.text = "LEVEL " + GameManager.Instance.Level;
    }
}
