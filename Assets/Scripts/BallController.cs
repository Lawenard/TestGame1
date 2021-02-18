using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public BallState ballState { get; private set; }
    private Camera cam;
    private Vector3 shotPoint, startingPoint;
    private Rigidbody body;
    [SerializeField] private LayerMask planeLayer, shotFieldLayer;
    [SerializeField] private float powerMultiplier = 400;

    [SerializeField] private SpriteRenderer arrowSprite;
    [SerializeField] private Transform arrow;

    private void Start()
    {
        startingPoint = transform.position;
        cam = Camera.main;
        body = GetComponent<Rigidbody>();
        ballState = BallState.ready;
    }

    private void Update()
    {
        if (Input.touches.Length < 1)
            return;

        // launch, controls
        if (ballState == BallState.ready && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            RaycastHit hit = TouchToPlane(true);
            if (hit.collider)
            {
                ballState = BallState.aim;
                transform.position = hit.point;
                arrowSprite.gameObject.SetActive(true);
            }
        }
        else if (ballState == BallState.aim && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            shotPoint = transform.position;
            RaycastHit hit = TouchToPlane(false);
            if (hit.collider)
            {
                ballState = BallState.moving;
                shotPoint = hit.point;
                Vector3 force = Vector3.Scale(transform.position - shotPoint, powerMultiplier * new Vector3(1, 0, 1));
                body.AddForce(force);
            }
            else
            {
                ballState = BallState.ready;
            }
            arrowSprite.gameObject.SetActive(false);
        }

        // visuals (arrow)
        if (ballState == BallState.aim)
        {
            RaycastHit hit = TouchToPlane(false);
            if (hit.collider)
            {
                arrow.position = Vector3.Lerp(hit.point, transform.position, .5f) + Vector3.up;
                arrow.LookAt(transform.position);
                arrowSprite.size = new Vector2(
                    Vector3.Distance(hit.point, transform.position)/2 + 1,
                    arrowSprite.size.y);
            }
        }
    }

    private RaycastHit TouchToPlane(bool restrict)
    {
        var ray = cam.ScreenPointToRay(Input.GetTouch(0).position);
        RaycastHit hit;
        Physics.Raycast(ray, out hit, 1000, restrict? shotFieldLayer : planeLayer);

        return hit;
    }

    public void BallReset()
    {
        ballState = BallState.ready;
        body.velocity = Vector3.zero;
        transform.position = startingPoint;
    }
}

public enum BallState { ready, aim, moving };
