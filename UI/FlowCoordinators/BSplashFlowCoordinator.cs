using System;
using System.Collections.Generic;
using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.ViewControllers;
using BSplash.UI.Controllers;
using BSplash.UI.Controllers.Bottom;
using HMUI;



namespace BSplash.UI.FlowCoordinators
{
    internal class BSplashFlowCoordinator : FlowCoordinator
    {
        public enum PageStatus
        {
            Settings

        }





        public FlowCoordinator      oldCoordinator;
        public BottomPageController bottomController;


        public PageStatus CurrentPageStatus { get; private set; }

        protected override void DidActivate(bool firstActivation, ActivationType activationType)
        {
            if (activationType != ActivationType.AddedToHierarchy)
                return;
            CurrentPageStatus = PageStatus.Settings;
            var homeController = BeatSaberUI.CreateViewController<SettingsPageController>();
            bottomController = BeatSaberUI.CreateViewController<BottomPageController>();
            bottomController.flowCoordinatorOwner = homeController.flowCoordinatorOwner = this;
            ProvideInitialViewControllers(homeController, null, null, bottomController);
        }

        public void ActivatePage(PageStatus status)
        {
            if (status == CurrentPageStatus) return;
            BSplashViewController controller;
            switch (status)
            {

                case PageStatus.Settings:
                    controller = BeatSaberUI.CreateViewController<SettingsPageController>();
                    ReplaceTopViewController(controller, null, false, ViewController.SlideAnimationDirection.Left);
                    SetLeftScreenViewController(null);
                    SetRightScreenViewController(null);
                    ProvideInitialViewControllers(controller, null, null, bottomController);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(status), status, null);
            }
            controller.flowCoordinatorOwner = this;
            CurrentPageStatus = status;
        }
    }
}