// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="AreaSelectEvent.cs">
//      Copyright ©Yunomi. All rights reserved.
//  </copyright>
//  <author>Yunomi</author>
//  <email>yunomi@childhooddream.sakura.ne.jp</email>
//  <created date>12/03/2017</date>
//  <update date>12/03/2017</date>
// --------------------------------------------------------------------------------------------------------------------
namespace StageSelect.Event
{
    #region

    using System;
    using DG.Tweening;
    using StageSelect;
    using StageSelect.View;
    using UniRx;
    using UniRx.Triggers;
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;

    #endregion

    /// <summary> アコーディオンの開閉（エリアメニューを押した時）を受け付ける </summary>
    public class AreaSelectEvent : MonoBehaviour
    {
        private void Awake()
        {
            // UniRxで連打防止。アコーディオンの開ききるまでこのイベントを停止
            this.gameObject.GetComponent<Button>().OnPointerClickAsObservable().ThrottleFirst(TimeSpan.FromSeconds(StageSelectConst.AccordionSpeed)).Subscribe(_ => {
                int menuId = this.gameObject.transform.parent.GetComponent<AreaMenuButtonView>().AreaMenuButtonNo;
                ExecuteEvents.Execute<IStageSelectInterface>(StageSelectPresenter.Instance.gameObject, null, (target, funcEventData) => target.ClickAreaMenuButton(menuId));
            }).AddTo(this);
        }
    }
}