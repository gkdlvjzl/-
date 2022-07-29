using UnityEngine;
using UnityEngine.SceneManagement;

public class VR_Teleport : MonoBehaviour
{
    public Transform Player;
    public int Load_Scene_Num;

    [SerializeField] GameObject canvas;

    Player_Posion instance;

    public float dir;   

    private void Update()
    {
        dir = Vector3.Distance(transform.position, Player.position);

        if (dir < 6f)
        {
            canvas.SetActive(true);
        }
        else
        {
            canvas.SetActive(false);
        }
    }

    public void Load_Sences()
    {
        SceneManager.LoadScene(Load_Scene_Num);
        
    }
}
