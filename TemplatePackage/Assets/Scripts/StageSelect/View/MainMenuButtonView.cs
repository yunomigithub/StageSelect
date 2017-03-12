// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="MainMenuButtonView.cs">
//      Copyright ©Yunomi. All rights reserved.
//  </copyright>
//  <author>Yunomi</author>
//  <email>yunomi@childhooddream.sakura.ne.jp</email>
//  <created date>12/03/2017</date>
//  <update date>12/03/2017</date>
// --------------------------------------------------------------------------------------------------------------------
namespace StageSelect.View
{
    #region

    using System.Collections.Generic;
    using System.Linq;
    using DG.Tweening;
    using StageSelect.Model;
    using UnityEngine;
    using UnityEngine.UI;

    #endregion

    /// <summary> メインメニューに関する制御 </summary>
    public class MainMenuButtonView : MonoBehaviour
    {
        [SerializeField]
        private Text mainMenuButtonText;

        [SerializeField]
        private GameObject subMenuParentObject;

        [SerializeField]
        private SubMenuButtonView subMenuButtonPrefabView;

        [SerializeField]
        private float beforeScrollPosY;

        /// <summary> 何番目のメニューボタン(エリア)なのか </summary>
        public int MainMenuButtonNo { get; private set; }

        /// <summary> メインメニューボタンのテキストを変更する </summary>
        public void ChangeMainMenuButtonText(string text)
        {
            this.mainMenuButtonText.text = text;
        }

        /// <summary> メニューボタンを生成する </summary>
        public MainMenuButtonView CreateMainMenuButton(int areaMstId, AreaMstModel areaMstModel, List<StageMstModel> stageMstModelList, GameObject parentObject)
        {
            GameObject mainMenuButtonViewObject = Instantiate(this.gameObject, parentObject.transform, false);
            var mainMenuButtonView = mainMenuButtonViewObject.GetComponent<MainMenuButtonView>();
            mainMenuButtonView.ChangeMainMenuButtonText(areaMstModel.BattleAreaName);
            mainMenuButtonView.CreateSubMenuButton(areaMstId, stageMstModelList);
            mainMenuButtonView.MainMenuButtonNo = areaMstId;

            return mainMenuButtonView;
        }

        /// <summary> メニューを開く </summary>
        public void OpenMenuButton(float accordionSpeed, int menuId)
        {
            this.subMenuParentObject.GetComponent<RectTransform>().DOScaleY(1, accordionSpeed);

            var layoutElement = this.gameObject.GetComponent<LayoutElement>();
            DOTween.To(() => layoutElement.minHeight, minHeight => layoutElement.minHeight = minHeight, StageSelectConst.AfterAccordionSize, StageSelectConst.AccordionSpeed);

            var contentRootScrollTransform = this.gameObject.transform.parent.GetComponent<RectTransform>();
            this.beforeScrollPosY = contentRootScrollTransform.anchoredPosition.y;
            contentRootScrollTransform.DOAnchorPosY(StageSelectConst.OneSetImageSize * menuId, StageSelectConst.AccordionSpeed);
        }

        /// <summary> メニューを閉じる </summary>
        public void CloseMenuButton(float accordionSpeed, int menuId)
        {
            this.subMenuParentObject.GetComponent<RectTransform>().DOScaleY(0, accordionSpeed);

            var layoutElement = this.gameObject.GetComponent<LayoutElement>();
            DOTween.To(() => layoutElement.minHeight, minHeight => layoutElement.minHeight = minHeight, StageSelectConst.MainMenuButtonSize, StageSelectConst.AccordionSpeed);

            var contentRootScrollTransform = this.gameObject.transform.parent.GetComponent<RectTransform>();
            contentRootScrollTransform.DOAnchorPosY(this.beforeScrollPosY, StageSelectConst.AccordionSpeed);
        }

        /// <summary> サブメニューボタンを生成する </summary>
        private void CreateSubMenuButton(int areaMstId, List<StageMstModel> stageMstModelList)
        {
            int stageId = 0;

            // UI上では配列の兼ね合いでIDは0番から。ModelのIDはデータベース(マスタ)の兼ね合いで1番からになっているので調整
            // マスタ上でエリアIDが同じ数だけステージがあるというテーブル設計を想定しているのでその数だけステージボタンを生成する
            foreach (var stageModel in stageMstModelList.Where(model => model.AreaMstId == areaMstId + 1).ToList()) {
                this.subMenuButtonPrefabView.CreateSubMenuButton(areaMstId, stageId, stageModel, this.subMenuParentObject);
                stageId++;
            }
        }
    }
}