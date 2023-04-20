using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] float speed = 10.0f;
    private CharacterController controller;
    private Vector3 velocity;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        velocity = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!controller.enabled) return;
        velocity.x = speed * Input.GetAxis("Horizontal");
        controller.Move(velocity * Time.deltaTime);
    }
}
