// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="StageSelectPresenter.cs">
//      Copyright ©Yunomi. All rights reserved.
//  </copyright>
//  <author>Yunomi</author>
//  <email>yunomi@childhooddream.sakura.ne.jp</email>
//  <created date>12/03/2017</date>
//  <update date>12/03/2017</date>
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
        private MainMenuButtonView mainMenuButtonPrefabView;

        [SerializeField]
        private Image tapLockImage;

        private List<AreaMstModel> areaMstModel;

        private List<StageMstModel> stageMstModel;

        private MstDataLoad mstDataLoad = new MstDataLoad();

        private List<MainMenuButtonView> mainMenuButtonViewList = new List<MainMenuButtonView>();

        private bool isOpenAccordion;

        /// <summary>
        /// メインのメニューボタンをタップした時の処理
        /// </summary>
        /// <param name="menuId">何番目のボタンを押したのか</param>
        public void ClickMainMenuButton(int menuId)
        {
            if (!this.isOpenAccordion) {
                this.mainMenuButtonViewList[menuId].OpenMenuButton(StageSelectConst.AccordionSpeed, menuId);
                this.scrollRect.vertical = false;
                this.isOpenAccordion = true;
                this.tapLockImage.enabled = true;
            }
            else {
                this.mainMenuButtonViewList[menuId].CloseMenuButton(StageSelectConst.AccordionSpeed, menuId);
                this.isOpenAccordion = false;
                this.scrollRect.vertical = true;
                this.tapLockImage.enabled = false;
            }
        }

        /// <summary> サブメニューを押した時（ステージを選択した時）の処理 </summary>
        public void ClickMainMenuButton(int menuId, int subMenuId)
        {
            // 適切なデータをバトルシーンへ渡す。当サンプルでは次のシーンがないため省略。
            Debug.Log(menuId + "/" + subMenuId);
        }

        private void Start()
        {
            this.stageMstModel = this.mstDataLoad.InitializeStageMstModel();
            this.areaMstModel = this.mstDataLoad.InitializeAreaMstModel();

            for (var i = 0; i < this.areaMstModel.Count; i++) {
                this.mainMenuButtonViewList.Add(this.mainMenuButtonPrefabView.CreateMainMenuButton(i, this.areaMstModel[i], this.stageMstModel, this.scrollContentParent));
            }
        }
    }
}