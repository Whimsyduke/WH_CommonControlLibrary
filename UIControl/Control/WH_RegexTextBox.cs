﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WH_CommonControlLibrary.UIControl.Control
{
    /// <summary>
    /// 正则表达式文本框
    /// </summary>
    public class WH_RegexTextBox : TextBox
    {

        #region 属性字段
        /// <summary>
        /// 正则表达式依赖项
        /// </summary>
        public static readonly DependencyProperty RegexExpressionProperty = DependencyProperty.Register("RegexExpression", typeof(string), typeof(WH_RegexTextBox), new PropertyMetadata(""));

        /// <summary>
        /// 正则表达式属性
        /// </summary>
        public string RegexExpression { set => SetValue(RegexExpressionProperty, value); get => (string)GetValue(RegexExpressionProperty); }

        /// <summary>
        /// 正则表达式效验结果依赖项
        /// </summary>
        public static readonly DependencyProperty IsPassRegexCheckProperty = DependencyProperty.Register("IsPassRegexCheck", typeof(bool), typeof(WH_RegexTextBox), new PropertyMetadata(true));

        /// <summary>
        /// 正则表达式效验结果属性
        /// </summary>
        public bool IsPassRegexCheck { private set => SetValue(IsPassRegexCheckProperty, value); get => (bool)GetValue(IsPassRegexCheckProperty); }

        /// <summary>
        /// 正则表达式效验失败颜色依赖项
        /// </summary>
        public static readonly DependencyProperty RegexCheckFailureColorProperty = DependencyProperty.Register("RegexCheckFailureColor", typeof(Brush), typeof(WH_RegexTextBox), new PropertyMetadata(Brushes.Red));

        /// <summary>
        /// 正则表达式效验失败颜色属性
        /// </summary>
        public Brush RegexCheckFailureColor { set => SetValue(RegexCheckFailureColorProperty, value); get => (Brush)GetValue(RegexCheckFailureColorProperty); }

        /// <summary>
        /// 正则表达式效验通过颜色依赖项
        /// </summary>
        public static readonly DependencyProperty RegexCheckPassColorProperty = DependencyProperty.Register("RegexCheckPassColor", typeof(Brush), typeof(WH_RegexTextBox), new PropertyMetadata(Brushes.Black));

        /// <summary>
        /// 正则表达式效验通过颜色属性
        /// </summary>
        public Brush RegexCheckPassColor { set => SetValue(RegexCheckPassColorProperty, value); get => (Brush)GetValue(RegexCheckPassColorProperty); }

        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public WH_RegexTextBox()
        {
            this.LostFocus += WH_RegexTextBox_LostFocus;
            this.GotFocus += WH_RegexTextBox_GotFocus;
        }

        /// <summary>
        /// 静态构造函数
        /// </summary>
        static WH_RegexTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WH_RegexTextBox), new FrameworkPropertyMetadata(typeof(WH_RegexTextBox)));
        }

        #endregion

        #region 方法

        /// <summary>
        /// 验证文本符合正则表达式
        /// </summary>
        private void CheckTextWithRegex()
        {
            if (string.IsNullOrEmpty(RegexExpression) || string.IsNullOrEmpty(Text))
            {
                IsPassRegexCheck = true;
            }
            else
            {
                IsPassRegexCheck = Regex.Match(Text, RegexExpression).Value == Text;
            }
        }

        #endregion

        #region 事件响应

        /// <summary>
        /// 失去焦点事件响应
        /// </summary>
        /// <param name="sender">响应控件</param>
        /// <param name="e">响应参数</param>
        private void WH_RegexTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            CheckTextWithRegex();
            if (!IsPassRegexCheck)
            {
                Foreground = RegexCheckFailureColor;
                
            }
            else
            {
                Foreground = RegexCheckPassColor;
            }
        }

        /// <summary>
        /// 获得点事件响应
        /// </summary>
        /// <param name="sender">响应控件</param>
        /// <param name="e">响应参数</param>
        private void WH_RegexTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            Foreground = RegexCheckPassColor;
        }
        #endregion
    }
}
