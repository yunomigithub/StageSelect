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

    /// <summary> ステージ選択で使用するタッチ関連のイベントリスト </summary>
    public interface IStageSelectInterface : IEventSystemHandler
    {
        void ClickAreaMenuButton(int areaId);
        void ClickStageMenuButton(int areaId, int stageId);
    }
}