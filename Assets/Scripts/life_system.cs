using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class life_system : MonoBehaviour
{
    [SerializeField] int life_points = 100;

    public int Get_life_points()
    {
        return life_points;
    }
    
    public void Reduce_life_points(int points)
    {
        life_points -= points;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
