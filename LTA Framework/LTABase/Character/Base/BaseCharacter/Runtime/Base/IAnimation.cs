using System;
namespace LTA.Base.Character
{
    public interface IAnimation
    {
        bool CheckAnim(string animName);

        void Play(string animName, bool loop = true);

        void SetEvent(string eventName, Action eventHandle);

        void SetStartEvent(Action eventHandle);

        void SetEndEvent(Action eventHandle);

        int LayerOrder { get; set; }

        void SetPreAnim(string preAnim);

        float Height { get; }
    }
}
