using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    void Update()
    {
        if (transform.position.y <= GameObject.Find("Lava").transform.position.y + 20)
        {
            GameManager.floors.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}
