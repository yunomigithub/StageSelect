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

        /// <summary> 難易度をあらわす星を表示する </summary>
        public void CreateStarParts(int stageLevel, GameObject parentObject)
        {
            for (var i = 0; i < StageSelectConst.MaxStageLevel; i++) {
                GameObject startPartsObject = Instantiate(this.gameObject, parentObject.transform, false);
                var startPartsView = startPartsObject.GetComponent<StarPartsView>();

                if (i < stageLevel) {
                    startPartsView.ChangeStarImageToOn();
                }
            }
        }
    }
}