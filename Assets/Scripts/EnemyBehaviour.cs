using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] BallController playerBall;
    [SerializeField] private float speed = 1;
    [SerializeField] private float speedIncrease = 1.5f;
    private float dir = 0;

    private void Start()
    {
        GameManager.Instance.LevelUp.AddListener(OnLevelUp);
    }

    private void OnLevelUp()
    {
        speed += speedIncrease;
    }

    void Update()
    {
        //if (playerBall.ballState == BallState.aim)
        //    return;

        dir = transform.InverseTransformPoint(playerBall.transform.position).z;

        if (dir == 0)
            return;

        dir /= Mathf.Abs(dir);
        transform.Translate(Time.deltaTime * dir * speed * Vector3.forward);
    }
    // TODO Remove entity shake and clipping through the border
}
