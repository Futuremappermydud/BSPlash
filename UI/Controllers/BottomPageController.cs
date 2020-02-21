using System.Collections.Generic;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.MenuButtons;
using BeatSaberMarkupLanguage.Parser;
using BSplash.UI.FlowCoordinators;
using UnityEngine.UI;

namespace BSplash.UI.Controllers.Bottom
{
    internal class BottomPageController : BSplashViewController
    {
        public override string ResourceName    => "BSplash.UI.Views.BottomPageView.bsml";
        public override string ContentFilePath => "C:/Users/Owens/Documents/GitHub/BSplash/UI/Views/BottomPageView.bsml";

        [UIParams] private BSMLParserParams parserParams;

        [UIAction("settings-page-act")]
        private void SettingsPageClicked()
        {
            flowCoordinatorOwner.ActivatePage(BSplashFlowCoordinator.PageStatus.Settings);
        }

    }
}