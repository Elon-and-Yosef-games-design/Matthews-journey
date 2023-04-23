using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class super_potion_action : MonoBehaviour
{
    [SerializeField] float duration = 2f;
    [SerializeField] float multiplier = 2f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("touched player");
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("touched player");
            collision.transform.GetComponent<Player_damage_system>().shilded(duration);
            float og_impulse = collision.transform.GetComponent<Controller>().get_impulse();
            StartCoroutine(enumerator(og_impulse, collision.transform));

        }
    }

    IEnumerator enumerator(float og_impulse, Transform t)
    {
        t.GetComponent<Controller>().set_impulse(og_impulse * multiplier);
        gameObject.GetComponent<Renderer>().enabled = false;
        yield return new WaitForSeconds(duration);
        t.GetComponent<Controller>().set_impulse(og_impulse);
        Destroy(gameObject);
    }
}
