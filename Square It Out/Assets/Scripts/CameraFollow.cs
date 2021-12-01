using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float redLineY;
    public float firstCameraY;
    private GameObject target;

    private Vector3 targetPosition;

    public float smoothing;

    private void Update()
    {
        if (GameManager.canMove)
        {
            target = GameManager.playerSquares[0];

            if (target.transform.position.y > redLineY)
            {
                targetPosition = new Vector3(transform.position.x, target.transform.position.y, transform.position.z);
            }

            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
        }
    }
}
