using UnityEngine;
using UnityEngine.EventSystems;

public class OpenExternalLinks : MonoBehaviour
{

    public void OpenGitHub()
    {
        Application.OpenURL("https://github.com/wesleysotnas64");
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void OpenLinkedIn()
    {
        Application.OpenURL("https://www.linkedin.com/in/wesley-santos-08b83b229/");
        EventSystem.current.SetSelectedGameObject(null);
    }

}
