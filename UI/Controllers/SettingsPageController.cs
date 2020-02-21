using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Parser;
using BeatSaberMarkupLanguage.ViewControllers;
using BSplash.UI.FlowCoordinators;

namespace BSplash.UI.Controllers
{
    internal class SettingsPageController : BSplashViewController
    {
        public override string ResourceName => "BSplash.UI.Views.SettingsPageView.bsml";
        public override string ContentFilePath => "C:/Users/Owens/Documents/GitHub/BSplash/UI/Views/SettingsPageView.bsml";

        [UIParams]
        private BSMLParserParams parserParams;

        [UIValue("#text")]
        public string text
        {
            get => Plugin.config.Value.text;
            set => Plugin.config.Value.text = value;
        }
        [UIValue("#bgyn")]
        public bool bg
        {
            get => Plugin.config.Value.overlaybackground;
            set => Plugin.config.Value.overlaybackground = value;
        }
        [UIAction("#apply")]
        public void OnApply()
        {

            Plugin.config.Value.text = text;
            Plugin.config.Value.overlaybackground = bg;

            Plugin.configProvider.Store(Plugin.config.Value);
        }

        public void Update()
        {

        }


    }
}
