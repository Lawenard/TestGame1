using UnityEngine;

public class Target : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.LevelUp.AddListener(OnLevelUp);
    }

    private void OnLevelUp()
    {
        gameObject.SetActive(true);
    }

    public void Kill()
    {
        gameObject.SetActive(false);
        GameManager.Instance.CountKill();
    }
}
