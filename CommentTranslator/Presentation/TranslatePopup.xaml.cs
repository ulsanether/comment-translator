﻿using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Microsoft.VisualStudio.Text;

namespace CommentTranslator.Presentation
{

    public partial class TranslatePopup : UserControl
    {
        #region Fields

        private bool _isClose = false;

       
        #endregion

        #region Contructors

        public TranslatePopup(SnapshotSpan span, string text, Size viewportSize)
        {
            Span = span.Snapshot.CreateTrackingSpan(span, SpanTrackingMode.EdgeExclusive);
            Text = text;
            InitializeComponent();

            SetMaxSize(viewportSize);
        }

        #endregion

        #region Properties

        public ITrackingSpan Span { get; set; }

        public string Text { get; set; }

        #endregion

        #region Fuctions

        private void SetMaxSize(Size viewportSize)
        {
            var maxHeight = viewportSize.Height / 2.0d;
            if (maxHeight > 600)
                maxHeight = 600;
            if (maxHeight < 150)
                maxHeight = 150;
            bdTranslatedText.MaxHeight = maxHeight;
            bdError.MaxHeight = maxHeight;
        }

        /// <summary>
        /// 手动选择或光标所在行，显示翻译内容
        /// </summary>
        /// <param name="text">鼠标选中文本或光标所在行的文本</param>
        private void Translate(string text)
        {
            bdError.Visibility = Visibility.Collapsed;
            bdTranslatedText.Visibility = Visibility.Collapsed;
            tblDirection.Text = "번역중...";

            Task.Run(() => CommentTranslatorPackage.TranslateClient.TranslateAsync(text))
                .ContinueWith((data) =>
                {
                    if (!_isClose)
                    {
                        if (!data.IsFaulted)
                        {
                            if (data.Result.Code == 200)
                            {
                             
                                tblDirection.Text = $"{data.Result.FromLanguage.ToLower()} -> {data.Result.ToLanguage.ToString().ToLower()}";
                                tblTranslatedText.Text = data.Result.Data;
                                bdTranslatedText.Visibility = Visibility.Visible;

                                if (CommentTranslatorPackage.Settings.AutoTextCopy) 
                                {
                                    Clipboard.SetText(data.Result.Data);
                                }
                            }
                            else
                            {
                                tblDirection.Text = "Translate Error";
                                tblError.Text = data.Result.Message;
                                bdError.Visibility = Visibility.Visible;
                            }
                        }
                        else
                        {
                            tblDirection.Text = "Translate Error";
                            tblError.Text = data.Exception.Message;
                            bdError.Visibility = Visibility.Visible;
                        }
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        #endregion

        #region Methods

        public void Translate()
        {
            Translate(Text);
        }

        public void Close()
        {
            _isClose = true;
            OnClosed?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #region Events

        public event EventHandler OnClosed;

        #endregion

        #region EventHandlers

        private void UserControl_Initialized(object sender, EventArgs e)
        {
            Translate(Text);
        }

        private void UserControl_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            e.Handled = true;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnCopy_Click(object sender, RoutedEventArgs e)
        {
            if (tblTranslatedText.Visibility == Visibility.Visible)
            {
                Clipboard.SetText(tblTranslatedText.Text);
            }
            else
            {
                Clipboard.SetText(tblError.Text);
            }
        }

        private void TranslatedText_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            btnCopy_Click(sender, e);
            Close();
        }

        #endregion
    }
}
