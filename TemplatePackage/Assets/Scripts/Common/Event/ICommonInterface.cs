// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ICommonInterface.cs">
//      Copyright ©Yunomi. All rights reserved.
//  </copyright>
//  <author>Yunomi</author>
//  <email>yunomi@childhooddream.sakura.ne.jp</email>
// --------------------------------------------------------------------------------------------------------------------
namespace Common.Event
{
    #region

    using UnityEngine.EventSystems;

    #endregion

    public interface ICommonInterface : IEventSystemHandler
    {
        void MoveScene(string sceneName);
    }
}