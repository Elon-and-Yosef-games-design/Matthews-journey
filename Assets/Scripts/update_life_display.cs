using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class update_life_display : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI life_points_text;


    void Start()
    {

    }

    public void life_to_text(int life)
    {
        life_points_text.text = life.ToString();
    }
}
