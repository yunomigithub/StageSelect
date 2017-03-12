// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="IStageSelectInterface.cs">
//      Copyright ©Yunomi. All rights reserved.
//  </copyright>
//  <author>Yunomi</author>
//  <email>yunomi@childhooddream.sakura.ne.jp</email>
//  <created date>11/03/2017</date>
//  <update date>12/03/2017</date>
// --------------------------------------------------------------------------------------------------------------------
namespace StageSelect.Event
{
    #region

    using UnityEngine.EventSystems;

    #endregion

    public interface IStageSelectInterface : IEventSystemHandler
    {
        void ClickMainMenuButton(int menuId);
        void ClickMainMenuButton(int menuId, int subMenuId);
    }
}