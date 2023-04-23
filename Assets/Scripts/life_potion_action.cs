using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class life_potion_action : MonoBehaviour
{
    [SerializeField] int life_points_to_add = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("touched player");
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("touched player");
            collision.transform.GetComponent<life_system>().Increase_life_points(life_points_to_add);
            Destroy(gameObject);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
