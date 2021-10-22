using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    public static  FadeInOut instance = null;
    public Image Panel;
    float time = 0f;
    float F_time = 1f;
    private void Awake() {
        if (instance == null)
        {
            instance = this;
        }
        // 인스턴스가 존재하는 경우 새로생기는 인스턴스를 삭제한다.
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    public void Fadeflow()
    {
        StartCoroutine(FadeFlow());
    }

    IEnumerator FadeFlow()
    {
        Panel.gameObject.SetActive(true);
        Color alpha = Panel.color;
        while(alpha.a < 1f)
        {
            time += Time.deltaTime /F_time;
            alpha.a = Mathf.Lerp(0,1,time);
            Panel.color = alpha;
            yield return null;
        }
        time = 0f;
        TutorialManager.instance.fadecheck = true;
        yield return new WaitForSeconds(1.0f);
        while(alpha.a > 0f)
        {
            time += Time.deltaTime /F_time;
            alpha.a = Mathf.Lerp(1,0,time);
            Panel.color = alpha;
            yield return null;
        }
        time = 0f;
        Panel.gameObject.SetActive(false);

        yield return null;
    }
}