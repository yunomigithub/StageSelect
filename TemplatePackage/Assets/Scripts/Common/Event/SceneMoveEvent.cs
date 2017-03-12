// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="SceneMoveEvent.cs">
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

    using UniRx;
    using UniRx.Triggers;
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;

    #endregion

    /// <summary> 共通として使えるシーン移動を受け付ける </summary>
    public class SceneMoveEvent : MonoBehaviour
    {
        [SerializeField]
        private string sceneName;

        private void Awake()
        {
            this.gameObject.GetComponent<Button>().OnPointerClickAsObservable().Subscribe(_ => {
                ExecuteEvents.Execute<ICommonInterface>(BasePresenter.Instance.gameObject, null, (target, funcEventData) => target.MoveScene(this.sceneName));
            }).AddTo(this);
        }
    }
}