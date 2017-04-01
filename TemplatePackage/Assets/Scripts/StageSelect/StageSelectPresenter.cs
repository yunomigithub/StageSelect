// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="StageSelectPresenter.cs">
//      Copyright ©Yunomi. All rights reserved.
//  </copyright>
//  <author>Yunomi</author>
//  <email>yunomi@childhooddream.sakura.ne.jp</email>
// --------------------------------------------------------------------------------------------------------------------
namespace StageSelect
{
    #region

    using System.Collections.Generic;
    using Common;
    using DG.Tweening;
    using StageSelect.Event;
    using StageSelect.Model;
    using StageSelect.View;
    using UnityEngine;
    using UnityEngine.UI;

    #endregion

    /// <summary> スクロール処理のテンプレート </summary>
    public class StageSelectPresenter : BasePresenter, IStageSelectInterface
    {
        [SerializeField]
        private GameObject scrollContentParent;

        [SerializeField]
        private ScrollRect scrollRect;

        [SerializeField]
        private AreaMenuButtonView areaMenuButtonPrefabView;

        [SerializeField]
        private Image tapLockImage;

        private List<AreaMstModel> areaMstModel;

        private List<StageMstModel> stageMstModel;

        private MstDataLoad mstDataLoad = new MstDataLoad();

        private List<AreaMenuButtonView> areaMenuButtonViewList = new List<AreaMenuButtonView>();

        private bool isOpenAccordion;

        /// <summary>
        /// エリアボタンをタップした時の処理
        /// </summary>
        /// <param name="areaId">何番目のボタンを押したのか</param>
        public void ClickAreaMenuButton(int areaId)
        {
            if (!this.isOpenAccordion) {
                this.areaMenuButtonViewList[areaId].OpenAreaMenuButton(areaId);
                this.scrollRect.enabled = false;
                this.isOpenAccordion = true;
                this.tapLockImage.enabled = true;
            }
            else {
                this.areaMenuButtonViewList[areaId].CloseAreaMenuButton(areaId);
                this.isOpenAccordion = false;
                this.scrollRect.enabled = true;
                this.tapLockImage.enabled = false;
            }
        }

        /// <summary> ステージボタンを押した時の処理 </summary>
        public void ClickStageMenuButton(int areaId, int stageId)
        {
            // 適切なデータをバトルシーンへ渡す。当サンプルでは次のシーンがないため省略。
            Debug.Log(areaId + "/" + stageId);
        }

        private void Start()
        {
            this.stageMstModel = this.mstDataLoad.LoadStageMstModel();
            this.areaMstModel = this.mstDataLoad.LoadAreaMstModel();

            for (var i = 0; i < this.areaMstModel.Count; i++) {
                GameObject areaMenuButtonObject = this.areaMenuButtonPrefabView.CreateAreaMenuButton(this.scrollContentParent);
                areaMenuButtonObject.GetComponent<AreaMenuButtonView>().InitializeAreaMenuButton(i, this.areaMstModel[i], this.stageMstModel);
                this.areaMenuButtonViewList.Add(areaMenuButtonObject.GetComponent<AreaMenuButtonView>());
            }
        }
    }
}