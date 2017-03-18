// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="StageMstModel.cs">
//      Copyright ©Yunomi. All rights reserved.
//  </copyright>
//  <author>Yunomi</author>
//  <email>yunomi@childhooddream.sakura.ne.jp</email>
//  <created date>12/03/2017</date>
//  <update date>12/03/2017</date>
// --------------------------------------------------------------------------------------------------------------------
namespace StageSelect.Model
{
    public class StageMstModel
    {
        /// <summary> エリアID </summary>
        public int AreaMstId { get; set; }

        /// <summary> ステージレベル </summary>
        public int StageLevel { get; set; }

        /// <summary> ステージ名 </summary>
        public string StageNameText { get; set; }

        /// <summary> 消費スタミナ </summary>
        public string StaminaNumberText { get; set; }
    }
}