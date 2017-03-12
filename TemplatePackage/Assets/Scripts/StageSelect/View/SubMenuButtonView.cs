// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="SubMenuButtonView.cs">
//      Copyright ©Yunomi. All rights reserved.
//  </copyright>
//  <author>Yunomi</author>
//  <email>yunomi@childhooddream.sakura.ne.jp</email>
//  <created date>10/03/2017</date>
//  <update date>11/03/2017</date>
// --------------------------------------------------------------------------------------------------------------------
namespace StageSelect.View
{
    #region

    using StageSelect.Model;
    using UnityEngine;
    using UnityEngine.UI;

    #endregion

    /// <summary> サブメニューボタンに関する制御 </summary>
    public class SubMenuButtonView : MonoBehaviour
    {
        [SerializeField]
        private Text stageNameText;

        [SerializeField]
        private Text staminaNumberText;

        [SerializeField]
        private GameObject startListObject;

        [SerializeField]
        private StarPartsView startPartsPrefabView;

        public int AreaMstId { get; private set; }

        public int StageMstId { get; private set; }

        /// <summary> ステージ名の変更 </summary>
        public void ChangeStageNameText(string text)
        {
            this.stageNameText.text = text;
        }

        /// <summary> スタミナ数の変更 </summary>
        public void ChangeStaminaNumberText(string text)
        {
            this.staminaNumberText.text = text;
        }

        /// <summary> 難易度の星を表示する </summary>
        public void CreateStartParts(int stageLevel)
        {
            this.startPartsPrefabView.CreateStarParts(stageLevel, this.startListObject);
        }

        /// <summary> サブメニューボタンを生成する </summary>
        public void CreateSubMenuButton(int areaMstId, int stageMstId, StageMstModel stageMstModel, GameObject parentObject)
        {
            GameObject subMenuButtonViewObject = Instantiate(this.gameObject, parentObject.transform, false);
            var subMenuButtonView = subMenuButtonViewObject.GetComponent<SubMenuButtonView>();

            subMenuButtonView.ChangeStaminaNumberText(stageMstModel.StaminaNumberText);
            subMenuButtonView.ChangeStageNameText(stageMstModel.StageNameText);
            subMenuButtonView.CreateStartParts(stageMstModel.StageLevel);
            subMenuButtonView.AreaMstId = areaMstId;
            subMenuButtonView.StageMstId = stageMstId;
        }
    }
}