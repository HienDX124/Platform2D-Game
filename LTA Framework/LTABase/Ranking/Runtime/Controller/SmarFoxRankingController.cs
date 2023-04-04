using System.Collections;
using System.Collections.Generic;
using LTA.DesignPattern;
using UnityEngine;

public abstract class RankingController : MonoBehaviour
{
    [SerializeField] protected RectTransform content;
    [SerializeField] protected GameObject itemRank;

    protected virtual void Awake()
    {
        Observer.Instance.AddObserver(KeyCodeRank.RESPONSE_PVP_RANKING, OnUpdateData);
    }

    public virtual void OnUpdateData(object obj)
    {
        //List<PackItemExp> dataRanking = (List<PackItemExp>) obj;
        //if (dataRanking == null) return;
        //for (int i = 0; i < dataRanking.Count; i++)
        //{
        //    ItemRanking itemRanking = AddItemRanking(itemRank, content);
        //    //itemRanking.name = dataRanking[i].ItemName;
        //    itemRanking.OnSetup(dataRanking[i]);
        //    //itemRanking.GetComponent<NonEntityController>().SetLevel(1);
        //}
    }

    protected virtual void OnDestroy()
    {
        Observer.Instance.RemoveObserver(KeyCodeRank.RESPONSE_PVP_RANKING, OnUpdateData);
    }

    protected virtual void ClearView()
    {
    }

    #region create itemrank

    private ItemRanking AddItemRanking(GameObject obj, RectTransform parent)
    {
        GameObject item = Instantiate(obj, Vector3.zero, Quaternion.identity);
        item.transform.SetParent(parent);
        item.transform.position = Vector3.zero;
        item.transform.localScale = Vector3.one;
        Debug.Log("pos rank: " + item.transform.position);
        //item.AddComponent<ItemRanking>();
        return item.GetComponent<ItemRanking>();
    }

    #endregion
}