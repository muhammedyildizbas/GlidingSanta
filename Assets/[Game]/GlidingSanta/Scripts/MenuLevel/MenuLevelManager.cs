using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuLevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public GameObject binaImage,noelBabaImage;

    [SerializeField]
    public GameObject playButon;

    void Start()
    {
            StartCoroutine(noelBaba());
    }
    public void playGame(int sceneid)
    {
        SceneManager.LoadScene(sceneid);
    }

    IEnumerator noelBaba()
    {
        binaImage.transform.GetComponent<RectTransform>().DOMoveY(950f, 0.5f).SetEase(Ease.InBack);
        noelBabaImage.GetComponent<RectTransform>().DOScale(0, 0.3f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(0.6f);
        noelBabaImage.GetComponent<RectTransform>().DOScale(0.9f, 0.5f).SetEase(Ease.OutBack);
      
        playButon.GetComponent<RectTransform>().DOScale(0, 0.2f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(0.2f);
       playButon.GetComponent<RectTransform>().DOScale(0.9f, 0.2f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(0.2f);

    }
}
