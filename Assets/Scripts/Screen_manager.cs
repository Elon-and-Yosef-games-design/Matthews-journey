using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Screen_manager : MonoBehaviour
{
    [SerializeField]
    string main_screen;
    [SerializeField]
    string lose_screen;
    [SerializeField]
    string win_screen;

    [SerializeField]
    string[] levels;

    [SerializeField]
    static int last_level = 0;


    public static Screen_manager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void move_to_main()
    {
        DontDestroyOnLoad(this);
        last_level = 0;
        SceneManager.LoadScene(main_screen);
    }
    public void load_current_level()
    {
        DontDestroyOnLoad(this);
        SceneManager.LoadScene(levels[last_level]);
    }
    public void load_lose_screen()
    {
        DontDestroyOnLoad(this);
        SceneManager.LoadScene(lose_screen);
    }
    public void load_win_screen()
    {
        DontDestroyOnLoad(this);
        SceneManager.LoadScene(win_screen);
    }
    public void next_level()
    {
        last_level++;
        if (last_level < levels.Length)
        {
            //DontDestroyOnLoad(this);
            SceneManager.LoadScene(levels[last_level]);
        }
        else
        {
            move_to_main();
        }
    }
    public void previous_level()
    {
        last_level--;
        if (last_level >= 0)
        {
            //DontDestroyOnLoad(this);
            SceneManager.LoadScene(levels[last_level]);
        }
        else
        {
            move_to_main();
        }
    }
}
