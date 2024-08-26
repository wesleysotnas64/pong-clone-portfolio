using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuController : MonoBehaviour
{
    public List<Transform> menuTransform;
    public List<bool> activeMenu;
    
    public float translateTime;
    public Vector3 offset;

    private int from;
    private int to;

    void Start()
    {
        transform.position = menuTransform[1].position+offset;
        activeMenu = new List<bool>
        {
            false,
            true,
            false,
            false
        };
    }

    public void MenuToGameplay()
    {
        CallTranslateFromTo(1, 3);
        GameObject.Find("PointsControll").GetComponent<PointsControll>().ResetPoints();
        GameObject.Find("AIControll").GetComponent<AIControll>().SetAsP2();
    }

    public void GameplayToMenu()
    {
        CallTranslateFromTo(3, 1);
    }

    public void MenuToInfo()
    {
        CallTranslateFromTo(1, 0);
    }

    public void InfoToMenu()
    {
        CallTranslateFromTo(0, 1);
    }

    public void MenuToTuto()
    {
        CallTranslateFromTo(1, 2);
    }

    public void TutoToMenu()
    {
        CallTranslateFromTo(2, 1);
    }

    public void CallTranslateFromTo(int a, int b)
    {
        EventSystem.current.SetSelectedGameObject(null);
        from = a;
        to = b;
        if (activeMenu[from])
        {
            StartCoroutine(TranslateFromTo(menuTransform[from].position, menuTransform[to].position));
        }

    }

    IEnumerator TranslateFromTo(Vector3 aPosition, Vector3 bPosition)
    {
        float elapsed = 0.0f;

        while(true)
        {
            if(elapsed >= translateTime)
            {
                transform.position = bPosition + offset;
                activeMenu[from] = false;
                activeMenu[to] = true;
                break;
            }
            else
            {
                transform.position = Vector3.Lerp(aPosition, bPosition, elapsed/translateTime) + offset;
            
                yield return null;
                elapsed += Time.deltaTime;
            }
        }

    }
}
