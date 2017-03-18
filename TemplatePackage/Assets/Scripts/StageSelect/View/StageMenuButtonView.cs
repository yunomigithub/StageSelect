// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="StageMenuButtonView.cs">
//      Copyright ©Yunomi. All rights reserved.
//  </copyright>
//  <author>Yunomi</author>
//  <email>yunomi@childhooddream.sakura.ne.jp</email>
// --------------------------------------------------------------------------------------------------------------------
namespace StageSelect.View
{
    #region

    using StageSelect.Model;
    using UnityEngine;
    using UnityEngine.UI;

    #endregion

    /// <summary> サブメニューボタンに関する制御 </summary>
    public class StageMenuButtonView : MonoBehaviour
    {
        [SerializeField]
        private Text stageNameText;

        [SerializeField]
        private Text staminaNumberText;

        [SerializeField]
        private GameObject startListObject;

        [SerializeField]
        private StarPartsView startPartsPrefabView;

        public int AreaId { get; private set; }

        public int StageId { get; private set; }

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

        /// <summary> ステージ選択メニューボタンを生成する </summary>
        public void CreateStageMenuButton(int areaId, int stageId, StageMstModel stageMstModel, GameObject parentObject)
        {
            GameObject stageMenuButtonViewObject = Instantiate(this.gameObject, parentObject.transform, false);
            var stageMenuButtonView = stageMenuButtonViewObject.GetComponent<StageMenuButtonView>();

            stageMenuButtonView.ChangeStaminaNumberText(stageMstModel.StaminaNumberText);
            stageMenuButtonView.ChangeStageNameText(stageMstModel.StageNameText);
            stageMenuButtonView.CreateStartParts(stageMstModel.StageLevel);
            stageMenuButtonView.AreaId = areaId;
            stageMenuButtonView.StageId = stageId;
        }
    }
}