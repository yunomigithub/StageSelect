// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="StarPartsView.cs">
//      Copyright ©Yunomi. All rights reserved.
//  </copyright>
//  <author>Yunomi</author>
//  <email>yunomi@childhooddream.sakura.ne.jp</email>
// --------------------------------------------------------------------------------------------------------------------
namespace StageSelect.View
{
    #region

    using StageSelect;
    using UnityEngine;
    using UnityEngine.UI;

    #endregion

    /// <summary> 難易度をあらわす星に関する制御 </summary>
    public class StarPartsView : MonoBehaviour
    {
        [SerializeField]
        private Image starImage;

        /// <summary> 難易度をあらわす星を表示状態にする </summary>
        public void ChangeStarImageToOn()
        {
            this.starImage.enabled = true;
        }

        /// <summary> 難易度をあらわす星を生成する </summary>
        public GameObject CreateStarParts(GameObject parentObject)
        {
            return Instantiate(this.gameObject, parentObject.transform, false);
        }
    }
}