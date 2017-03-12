// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="MstDataLoad.cs">
//      Copyright ©Yunomi. All rights reserved.
//  </copyright>
//  <author>Yunomi</author>
//  <email>yunomi@childhooddream.sakura.ne.jp</email>
//  <created date>10/03/2017</date>
//  <update date>11/03/2017</date>
// --------------------------------------------------------------------------------------------------------------------
namespace StageSelect
{
    #region

    using System.Collections.Generic;
    using StageSelect.Model;

    #endregion

    /// <summary> マスタデータの読み込みを行う </summary>
    public class MstDataLoad
    {
        /// <summary> エリア情報を読み込む </summary>
        public List<AreaMstModel> InitializeAreaMstModel()
        {
            var areaMstModelList = new List<AreaMstModel>();

            // データの読み込み部分。サンプルなので適当に値を仮で代入
            var areaMstModel1 = new AreaMstModel { BattleAreaName = "hoge1" };
            var areaMstModel2 = new AreaMstModel { BattleAreaName = "hoge2" };
            var areaMstModel3 = new AreaMstModel { BattleAreaName = "hoge3" };
            var areaMstModel4 = new AreaMstModel { BattleAreaName = "hoge4" };
            var areaMstModel5 = new AreaMstModel { BattleAreaName = "hoge5" };
            var areaMstModel6 = new AreaMstModel { BattleAreaName = "hoge6" };
            var areaMstModel7 = new AreaMstModel { BattleAreaName = "hoge7" };
            var areaMstModel8 = new AreaMstModel { BattleAreaName = "hoge8" };

            areaMstModelList.Add(areaMstModel1);
            areaMstModelList.Add(areaMstModel2);
            areaMstModelList.Add(areaMstModel3);
            areaMstModelList.Add(areaMstModel4);
            areaMstModelList.Add(areaMstModel5);
            areaMstModelList.Add(areaMstModel6);
            areaMstModelList.Add(areaMstModel7);
            areaMstModelList.Add(areaMstModel8);

            return areaMstModelList;
        }

        /// <summary> ステージ情報を読み込む </summary>
        public List<StageMstModel> InitializeStageMstModel()
        {
            var stageMstModelList = new List<StageMstModel>();

            // データの読み込み部分。サンプルなので適当に値を仮で代入
            var stageMstModel1 = new StageMstModel { AreaMstId = 1, StageLevel = 1, StageNameText = "hoge1", StaminaNumberText = "5" };
            var stageMstModel2 = new StageMstModel { AreaMstId = 2, StageLevel = 2, StageNameText = "hoge2", StaminaNumberText = "10" };
            var stageMstModel3 = new StageMstModel { AreaMstId = 3, StageLevel = 3, StageNameText = "hoge3", StaminaNumberText = "15" };
            var stageMstModel4 = new StageMstModel { AreaMstId = 4, StageLevel = 4, StageNameText = "hoge4", StaminaNumberText = "20" };
            var stageMstModel5 = new StageMstModel { AreaMstId = 5, StageLevel = 5, StageNameText = "hoge5", StaminaNumberText = "25" };
            var stageMstModel6 = new StageMstModel { AreaMstId = 6, StageLevel = 2, StageNameText = "hoge6", StaminaNumberText = "25" };
            var stageMstModel7 = new StageMstModel { AreaMstId = 7, StageLevel = 3, StageNameText = "hoge7", StaminaNumberText = "25" };
            var stageMstModel8 = new StageMstModel { AreaMstId = 8, StageLevel = 5, StageNameText = "hoge8", StaminaNumberText = "25" };
            var stageMstModel9 = new StageMstModel { AreaMstId = 8, StageLevel = 5, StageNameText = "hoge9", StaminaNumberText = "25" };
            var stageMstModel10 = new StageMstModel { AreaMstId = 8, StageLevel = 5, StageNameText = "hoge10", StaminaNumberText = "25" };

            stageMstModelList.Add(stageMstModel1);
            stageMstModelList.Add(stageMstModel2);
            stageMstModelList.Add(stageMstModel3);
            stageMstModelList.Add(stageMstModel4);
            stageMstModelList.Add(stageMstModel5);
            stageMstModelList.Add(stageMstModel6);
            stageMstModelList.Add(stageMstModel7);
            stageMstModelList.Add(stageMstModel8);
            stageMstModelList.Add(stageMstModel9);
            stageMstModelList.Add(stageMstModel10);

            return stageMstModelList;
        }
    }
}