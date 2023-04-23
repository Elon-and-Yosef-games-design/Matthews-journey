using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class life_system : MonoBehaviour
{
    [SerializeField] int life_points = 100;
    [SerializeField] GameObject screen_manager;

    Vector3 startingPosition;

    public int Get_life_points()
    {
        return life_points;
    }
    
    public void Reduce_life_points(int points)
    {
        life_points -= points;
        transform.GetComponent<update_life_display>().life_to_text(life_points);
    }
    public void Increase_life_points(int points)
    {
        life_points += points;
        transform.GetComponent<update_life_display>().life_to_text(life_points);

    }
    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<update_life_display>().life_to_text(life_points);
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(life_points <= 0)
        {
            transform.position = startingPosition;
            Debug.Log("die");
        }
        
    }
}
