using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseManager : Singleton<MouseManager>
{
    [SerializeField] Texture2D texture2D;

    // Start is called before the first frame update
    void Start()
    {
        texture2D = ResourcesManager.Instance.Load<Texture2D>("default_cursor");
        Cursor.SetCursor(texture2D, Vector2.zero, CursorMode.Auto);
    }

    public void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void State(int state)
    {
        switch (state)
        {
            case 0 :
                texture2D = ResourcesManager.Instance.Load<Texture2D>("default_cursor");
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.SetCursor(texture2D, Vector2.zero, CursorMode.Auto);
                break;

            case 1 :
                texture2D = ResourcesManager.Instance.Load<Texture2D>("default_cursor");
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.SetCursor(texture2D, Vector2.zero, CursorMode.Auto);
                break;
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        State(scene.buildIndex);
    }
}
