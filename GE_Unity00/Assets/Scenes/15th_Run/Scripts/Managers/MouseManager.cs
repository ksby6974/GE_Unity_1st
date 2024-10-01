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

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

    }
}
