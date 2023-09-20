using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEvents : MonoBehaviour
{
    [SerializeField] private GameObject losePanel;
   
    private void Update()
    {
        if (!CharacterInputController.alive)
        {
            Time.timeScale = 0;
            losePanel.SetActive(true);
        }
    }
    public void Restart()
    {
        CharacterInputController.alive = true;
        losePanel.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

}
