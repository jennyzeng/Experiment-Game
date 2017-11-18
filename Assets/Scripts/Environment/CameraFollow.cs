using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Up, Down, Left, Right;
    Transform player;

    void Update()
    {
		player = GameObjectManager.Instance.playerTransform;
        if (player == null)
        {
            return;
        }
        float offsetX = 0;
        Vector3 targetPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        if (player.position.x > Right.position.x)
        {
            offsetX = player.position.x - Right.position.x;
        }
        else if (player.position.x < Left.position.x)
        {
            offsetX = player.position.x - Left.position.x;
        }
        targetPos.x += offsetX;

		float offsetY= 0;
        if (player.position.y > Up.position.y)
        {
            offsetY = player.position.y - Up.position.y;
        }
        else if (player.position.y < Down.position.y)
        {
            offsetY = player.position.y - Down.position.y;
        }
        targetPos.y += offsetY;
		transform.position = targetPos;
    }

}
