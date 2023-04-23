using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_follower : MonoBehaviour
{
    [SerializeField]
    public GameObject camera_to_follow;

    [SerializeField]
    float offset = 20f;

    // Update is called once per frame
    void Update()
    {
        float p_x_position = transform.position.x;
        camera_to_follow.transform.position = new Vector3(p_x_position + offset, camera_to_follow.transform.position.y, -10);// -10 is for alignment z level of tile map
    }
}
