

//içindeki parametreler henüz tanımlanmadığı için hata veriyor. parametreler tanımlanınca kullanıma hazır olacak

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class CollectableManager : MonoBehaviour
//{

//    private void OnEnable()
//    {
//        if (Managers.Instance == null)
//            return;

//    }

//    private void OnDisable()
//    {
//        if (Managers.Instance == null)
//            return;

//    }

//    private void CreateStars()
//    {
//        int targetStarCount = Random.Range(5, 10);/*oluşturulacak yıldız sayısı*/

//        StartCoroutine(CreateStarsCo(lane/*lane'in transform'u*/, targetStarCount));
//    }

//    private IEnumerator CreateStarsCo(Vector3 lane, int targetStarCount)
//    {
//        yield return new WaitForSeconds(Random.Range(0.5f, 1.5f));
//        for (int i = 0; i < targetStarCount; i++)
//        {
//            /*GameObject star = ...    starı burada çekeceğiz*/
//            Instantiate(star/*çekilecek yıldız*/, lane + Vector3.up, Quaternion.identity, /*starın parent objesi*/);

//            yield return new WaitForSeconds(0.2f);
//        }
//    }
//}