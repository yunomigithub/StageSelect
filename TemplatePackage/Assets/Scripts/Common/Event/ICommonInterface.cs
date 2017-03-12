// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ICommonInterface.cs">
//      Copyright ©Yunomi. All rights reserved.
//  </copyright>
//  <author>Yunomi</author>
//  <email>yunomi@childhooddream.sakura.ne.jp</email>
//  <created date>12/03/2017</date>
//  <update date>12/03/2017</date>
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