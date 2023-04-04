using LTA.Condition;

namespace LTA.Base.Item
{
    public interface IOnBeUseItem
    {
        bool IsAllowBeUseItem { get; }
        void OnBeUseItem(object info);
    }
}
