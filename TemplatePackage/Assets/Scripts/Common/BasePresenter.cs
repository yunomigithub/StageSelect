// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="BasePresenter.cs">
//      Copyright ©Yunomi. All rights reserved.
//  </copyright>
//  <author>Yunomi</author>
//  <email>yunomi@childhooddream.sakura.ne.jp</email>
// --------------------------------------------------------------------------------------------------------------------
namespace Common
{
    using Common.Event;
    using UnityEngine.SceneManagement;

    /// <summary> すべてのベースとなる共通用の処理を管理するプレゼンター </summary>
    public class BasePresenter : SingletonMonoBehaviourFast<BasePresenter>, ICommonInterface
    {
        /// <summary> シーンを移動する </summary>
        public void MoveScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}