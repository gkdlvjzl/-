using UnityEngine;
using UnityEngine.SceneManagement;

public class Ui_Scene : MonoBehaviour
{
    public int sence_num;

    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One))
            Load_Scene();

        if (OVRInput.GetDown(OVRInput.Button.Two))
            End_Game();
    }

    public void Load_Scene()
    {
        SceneManager.LoadScene(sence_num);
    }
    public void End_Game()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBPLAYER
         Application.OpenURL(webplayerQuitURL);
#else
         Application.Quit();
#endif
    }
}
