using System.Linq;
using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Parser;
using BSplash.Settings;
using BSplash.UI.FlowCoordinators;
using HMUI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using BSplash.UI.Controllers;
using IPA.Config;
using IPA.Utilities;
using IPA.Loader;

namespace BSplash.UI.Controllers
{
    internal class OverlayMenuViewController : BSplashViewController

    {
        public override string ResourceName    => "BSplash.UI.Views.OverlayMenuView.bsml";
        public override string ContentFilePath => "C:/Users/Owens/Documents/GitHub/BSplash/UI/Views/OverlayMenuView.bsml";

        internal static Ref<PluginConfig> config;
        internal static IConfigProvider configProvider;

        

        public static OverlayMenuViewController instance;

        #region Properties
        [UIParams] private BSMLParserParams parserParams;

        private bool                       _shouldOpenPage = true;
        private BSplashFlowCoordinator _flowCoordinatorOwner;

        [UIComponent("switch-BSplash-btn")]
        private Button _openBSplashsettingsButton;






        private bool _bsDisableContainerState = false;
        [UIValue("bs-disable-container-state")]
        public bool bsDisableContainerState
        {
            get { return _bsDisableContainerState; }
            set
            {
                _bsDisableContainerState = value;
                NotifyPropertyChanged();
            }
        }

        private string _buttonStatus = "Open Splash Settings";
        [UIValue("Bsplash-btn-status")]
        public string buttonStatus
        {
            get { return _buttonStatus; }
            private set
            {
                _buttonStatus = value;
                NotifyPropertyChanged();
            }
        }






        #endregion



        protected override void DidActivate(bool firstActivation, ActivationType type)
        {
            base.DidActivate(firstActivation, type);

           
        }



        [UIAction("switch-BSplash-act")]
        public void ShowModPageClick()
        {
            if (_shouldOpenPage)
            {
                var currentFlow = Resources.FindObjectsOfTypeAll<FlowCoordinator>().FirstOrDefault(f => f.isActivated);
                _flowCoordinatorOwner = BeatSaberUI.CreateFlowCoordinator<BSplashFlowCoordinator>();
                _flowCoordinatorOwner.oldCoordinator = currentFlow;
                currentFlow.PresentFlowCoordinator(_flowCoordinatorOwner);
            }
            else
                _flowCoordinatorOwner.oldCoordinator.DismissFlowCoordinator(_flowCoordinatorOwner);
            _shouldOpenPage = !_shouldOpenPage;
            buttonStatus = _shouldOpenPage ? "Open Splash settings" : "Close Splash settings";
        }
    }
}