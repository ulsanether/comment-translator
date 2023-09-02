using System.ComponentModel;
using Framework;
using Microsoft.VisualStudio.Shell;

namespace CommentTranslator.Presentation
{
    /// <summary>
    /// 工具选项窗体
    /// </summary>
    public class OptionPageGrid : DialogPage
    {
        [Category("Server")]
        [DisplayName("번역 서버")]
        [Description("번역 서버")]
        public TranslateServerEnum TranslateServer { get; set; } = TranslateServerEnum.Google;

        /// <summary>
        /// Gets or sets a value indicating whether 待翻译语言
        /// </summary>
        [Category("Translate")]
        [DisplayName("번역할 언어")]
        [Description("번역할 언어 유형")]
        public LanguageEnum TranslateFrom { get; set; } = LanguageEnum.Auto;

        /// <summary>
        /// Gets or sets a value indicating whether 目标语言
        /// </summary>
        [Category("Translate")]
        [DisplayName("언어로 번역")]
        [Description("대상 언어 유형으로 번역")]
        public LanguageEnum TranslatetTo { get; set; } = GetCurrentCulture();

        ///// <summary>
        ///// Gets or sets a value indicating whether 自动检测语言
        ///// </summary>
        //[Category("Translate")]
        //[DisplayName("自动检测类型")]
        //[Description("自动检测待翻译语言类型")]
        //public bool AutoDetect { get; set; } = false;

        [Category("Translate")]
        [DisplayName("자동 번역을 위해 파일 열기")]
        [Description("파일을 열 때 댓글을 자동으로 번역합니다.")]
        public bool AutoTranslateComment { get; set; } = false;

        [Category("Translate")]
        [DisplayName("수동 번역 및 자동 복사")]
        [Description("수동 번역은 자동으로 콘텐츠를 클립보드에 복사합니다.")]
        public bool AutoTextCopy { get; set; } = false;

        protected override void OnApply(PageApplyEventArgs e)
        {
            base.OnApply(e);

            if (e.ApplyBehavior == ApplyKind.Apply)
            {
                this.SaveToSetting();
            }
        }


        /// <summary>
        /// 保存设置
        /// </summary>
        public void SaveToSetting()
        {
            // C#中MessageBox用法大全（附效果图）
            // https://www.cnblogs.com/rooly/articles/1910063.html
            //if (string.IsNullOrWhiteSpace(TKK))
            //{
            //    MessageBox.Show("请先设置TKK值！", "系统提示");

            //    // return;
            //}

            // 刷新值
            CommentTranslatorPackage.Settings.ReloadSetting(this);
        }

        // 【小试插件开发】给Visual Studio装上自己定制的功能来提高代码调试效率
        // https://www.cnblogs.com/hohoa/p/6617619.html?utm_source=gold_browser_extension

        private static LanguageEnum GetCurrentCulture()
        {
            string currentCulture = System.Globalization.CultureInfo.CurrentCulture.Name;
            switch (currentCulture)
            {
                case "ja-JP":
                    return LanguageEnum.日本語;
                case "zh-CN":
                    return LanguageEnum.简体中文;
                case "zh-TW":
                    return LanguageEnum.繁體中文;
                case "en-US":
                    return LanguageEnum.English;
                case "ko-KR":
                    return LanguageEnum.한국어;
                default:
                    return LanguageEnum.한국어;
            }
        }
    }
}