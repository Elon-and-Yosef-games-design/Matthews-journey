using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_damage_system : MonoBehaviour
{
    [SerializeField] int points_on_fall = 5;
    [SerializeField] float minImpulseForfallDamage = 1.0f;
    [SerializeField] float reduced_speed = 3.0f;
    [SerializeField] float duration_fall_damage = 1.0f;
    
    void onFall()
    {
        transform.GetComponent<life_system>().Reduce_life_points(points_on_fall);
        StartCoroutine(onFall_ie());
    }
    IEnumerator onFall_ie()
    {

        float original_speed = this.GetComponent<Controller>().get_speed();

        transform.GetComponent<Controller>().set_speed(reduced_speed);
        yield return new WaitForSeconds(duration_fall_damage);
        transform.GetComponent<Controller>().set_speed(original_speed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Impulse = F * DeltaT = m * a * DeltaT = m * DeltaV
        float impulse = collision.relativeVelocity.magnitude * rb.mass;
        if (impulse > minImpulseForfallDamage)
        {
            onFall();
        }
    }

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
