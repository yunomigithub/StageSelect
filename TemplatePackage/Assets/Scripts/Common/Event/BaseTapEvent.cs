// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="BaseTapEvent.cs">
//      Copyright ©Yunomi. All rights reserved.
//  </copyright>
//  <author>Yunomi</author>
//  <email>yunomi@childhooddream.sakura.ne.jp</email>
// --------------------------------------------------------------------------------------------------------------------
namespace Common.Event
{
    using UniRx;
    using UniRx.Triggers;
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary> 通常ボタンのタッチアクション </summary>
    public class BaseTapEvent : MonoBehaviour
    {
        /// <summary> 通常のタップアクション </summary>
        protected void InitializeNormalTapEvent()
        {
            this.gameObject.GetComponent<Button>().OnPointerUpAsObservable().Subscribe(_ => {
                this.gameObject.GetComponent<RectTransform>().localScale = Vector3.one;
            }).AddTo(this);

            this.gameObject.GetComponent<Button>().OnPointerDownAsObservable().Subscribe(_ =>
            {
                this.gameObject.GetComponent<RectTransform>().localScale = new Vector3(1.05f, 1.05f, 1.05f);
            }).AddTo(this);


        }
    }
}