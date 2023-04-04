using UnityEngine;
namespace LTA.Base.Item
{
    public interface IOnEndUseItem
    {
        void OnEndUseItem(Transform[] targets, PackItem packItem);
    }
}
