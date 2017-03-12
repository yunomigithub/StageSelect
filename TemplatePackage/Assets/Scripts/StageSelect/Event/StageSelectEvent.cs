// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="StageSelectEvent.cs">
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

    using StageSelect;
    using StageSelect.View;
    using UniRx;
    using UniRx.Triggers;
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;

    #endregion

    /// <summary> ステージの選択（サブメニューを押した時）を受け付ける </summary>
    public class StageSelectEvent : MonoBehaviour
    {
        private void Awake()
        {
            this.gameObject.GetComponent<Button>().OnPointerClickAsObservable().Subscribe(_ => {
                int menuId = this.gameObject.transform.GetComponent<SubMenuButtonView>().AreaMstId;
                int subMenuId = this.gameObject.GetComponent<SubMenuButtonView>().StageMstId;
                ExecuteEvents.Execute<IStageSelectInterface>(StageSelectPresenter.Instance.gameObject, null, (target, funcEventData) => target.ClickMainMenuButton(menuId, subMenuId));
            }).AddTo(this);
        }
    }
}