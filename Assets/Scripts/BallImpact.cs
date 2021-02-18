using UnityEngine;

public class BallImpact : MonoBehaviour
{
    [SerializeField] private LayerMask enemyLayer, targetLayer;
    private BallController ballController;
    [SerializeField] private GameObject explosion;

    private void Start()
    {
        ballController = GetComponent<BallController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == Mathf.Log(enemyLayer.value, 2))
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            ballController.BallReset();
        }
        else if (collision.gameObject.layer == Mathf.Log(targetLayer.value, 2))
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            collision.gameObject.GetComponent<Target>().Kill();
            ballController.BallReset();
        }
    }
}
