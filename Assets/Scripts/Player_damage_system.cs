using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_damage_system : MonoBehaviour
{
    [SerializeField] int points_on_fall = 5;
    [SerializeField] float minImpulseForfallDamage = 1.0f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Impulse = F * DeltaT = m * a * DeltaT = m * DeltaV
        float impulse = collision.relativeVelocity.magnitude * rb.mass;
        if (impulse > minImpulseForfallDamage)
        {
            transform.GetComponent<life_system>().Reduce_life_points(points_on_fall);
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
