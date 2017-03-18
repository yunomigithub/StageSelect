// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="StageSelectEvent.cs">
//      Copyright ©Yunomi. All rights reserved.
//  </copyright>
//  <author>Yunomi</author>
//  <email>yunomi@childhooddream.sakura.ne.jp</email>
//  <created date>12/03/2017</date>
//  <update date>16/03/2017</date>
// --------------------------------------------------------------------------------------------------------------------
namespace StageSelect.Event
{
    #region

    using System;
    using Common.Event;
    using StageSelect;
    using StageSelect.View;
    using UniRx;
    using UniRx.Triggers;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;

    #endregion

    /// <summary> ステージの選択ボタンを受け付ける </summary>
    public class StageSelectEvent : BaseTapEvent
    {
        private void Awake()
        {
            this.InitializeNormalTapEvent();

            // UniRxで連打防止
            this.gameObject.GetComponent<Button>().OnPointerClickAsObservable().ThrottleFirst(TimeSpan.FromSeconds(0.1f)).Subscribe(_ =>
            {
                int areaId = this.gameObject.GetComponent<StageMenuButtonView>().AreaId;
                int stageId = this.gameObject.GetComponent<StageMenuButtonView>().StageId;
                ExecuteEvents.Execute<IStageSelectInterface>(StageSelectPresenter.Instance.gameObject, null, (target, funcEventData) => target.ClickStageMenuButton(areaId, stageId));
            }).AddTo(this);
        }
    }
}