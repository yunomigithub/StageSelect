// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="AreaMenuButtonView.cs">
//      Copyright ©Yunomi. All rights reserved.
//  </copyright>
//  <author>Yunomi</author>
//  <email>yunomi@childhooddream.sakura.ne.jp</email>
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
    public class AreaMenuButtonView : MonoBehaviour
    {
        [SerializeField]
        private Text areaMenuButtonText;

        [SerializeField]
        private GameObject stageMenuParentObject;

        [SerializeField]
        private StageMenuButtonView stageMenuButtonPrefabView;

        [SerializeField]
        private float beforeScrollPosY;

        [SerializeField]
        private float areaMenuButtonSize;

        [SerializeField]
        private float oneSetImageSize;

        /// <summary> 何番目のエリアなのか </summary>
        public int AreaMenuButtonNo { get; private set; }

        private void Awake()
        {
            this.areaMenuButtonSize = this.gameObject.GetComponent<LayoutElement>().minHeight;
            this.oneSetImageSize = this.gameObject.transform.parent.gameObject.GetComponent<VerticalLayoutGroup>().spacing + this.areaMenuButtonSize;
        }

        /// <summary> ステージメニューボタンを生成する </summary>
        private void CreateStageMenuButton(int areaId, List<StageMstModel> stageMstModelList)
        {
            int stageId = 0;

            // UI上では配列の兼ね合いでIDは0番から。ModelのIDはデータベース(マスタ)の兼ね合いで1番からになっているので調整
            // マスタ上でエリアIDが同じ数だけステージがあるというテーブル設計を想定しているのでその数だけステージボタンを生成する
            foreach (var stageModel in stageMstModelList.Where(model => model.AreaMstId == areaId + 1).ToList()) {
                this.stageMenuButtonPrefabView.CreateStageMenuButton(areaId, stageId, stageModel, this.stageMenuParentObject);
                stageId++;
            }
        }

        /// <summary> エリアボタンのテキストを変更する </summary>
        public void ChangeAreaMenuButtonText(string text)
        {
            this.areaMenuButtonText.text = text;
        }

        /// <summary> エリアボタンを閉じる </summary>
        public void CloseAreaMenuButton(int areaId)
        {
            var layoutElement = this.gameObject.GetComponent<LayoutElement>();
            var contentRootScrollTransform = this.gameObject.transform.parent.GetComponent<RectTransform>();

            this.stageMenuParentObject.GetComponent<RectTransform>().DOScaleY(0, StageSelectConst.AccordionSpeed + 0.1f).OnComplete(() => {
                DOTween.To(() => layoutElement.minHeight, minHeight => layoutElement.minHeight = minHeight, this.areaMenuButtonSize, StageSelectConst.AccordionSpeed);
                contentRootScrollTransform.DOAnchorPosY(this.beforeScrollPosY, StageSelectConst.AccordionSpeed);
            });
        }

        /// <summary> エリアボタンを生成する </summary>
        public AreaMenuButtonView CreateAreaMenuButton(int areaId, AreaMstModel areaMstModel, List<StageMstModel> stageMstModelList, GameObject parentObject)
        {
            GameObject areaMenuButtonViewObject = Instantiate(this.gameObject, parentObject.transform, false);
            var areaMenuButtonView = areaMenuButtonViewObject.GetComponent<AreaMenuButtonView>();
            areaMenuButtonView.ChangeAreaMenuButtonText(areaMstModel.AreaName);
            areaMenuButtonView.CreateStageMenuButton(areaId, stageMstModelList);
            areaMenuButtonView.AreaMenuButtonNo = areaId;

            return areaMenuButtonView;
        }

        /// <summary> エリアボタンを開く </summary>
        public void OpenAreaMenuButton(int areaId)
        {
            var layoutElement = this.gameObject.GetComponent<LayoutElement>();
            var contentRootScrollTransform = this.gameObject.transform.parent.GetComponent<RectTransform>();
            this.beforeScrollPosY = contentRootScrollTransform.anchoredPosition.y;

            contentRootScrollTransform.DOAnchorPosY(this.oneSetImageSize * areaId, StageSelectConst.AccordionSpeed).OnComplete(() => {
                DOTween.To(() => layoutElement.minHeight, minHeight => layoutElement.minHeight = minHeight, StageSelectConst.AfterAccordionSize, StageSelectConst.AccordionSpeed + 0.1f);
                this.stageMenuParentObject.GetComponent<RectTransform>().DOScaleY(1, StageSelectConst.AccordionSpeed + 0.1f);
            });
        }
    }
}