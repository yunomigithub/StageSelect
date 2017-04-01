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

        /// <summary> ステージ選択メニューボタンを生成する </summary>
        public GameObject CreateStageMenuButton(GameObject parentObject)
        {
            return Instantiate(this.gameObject, parentObject.transform, false);
        }

        /// <summary> 難易度の星を生成する </summary>
        public void CreateStartParts(int stageLevel)
        {
            for (var i = 0; i < StageSelectConst.MaxStageLevel; i++) {
                GameObject starPartsObject = this.startPartsPrefabView.CreateStarParts(this.startListObject);
                if (i < stageLevel) {
                    starPartsObject.GetComponent<StarPartsView>().ChangeStarImageToOn();
                }
            }
        }

        /// <summary> 初期化 </summary>
        public void InitializeStageMenuButton(int areaId, int stageId, StageMstModel stageMstModel)
        {
            this.ChangeStaminaNumberText(stageMstModel.StaminaNumberText);
            this.ChangeStageNameText(stageMstModel.StageNameText);
            this.CreateStartParts(stageMstModel.StageLevel);
            this.AreaId = areaId;
            this.StageId = stageId;
        }
    }
}