using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// 可搜索ListView
    /// </summary>
    public class WH_SearchableListView : ListView
    {
        #region 属性字段

        /// <summary>
        /// 搜索标签内容依赖项
        /// </summary>
        public static readonly DependencyProperty SearchLabelProperty = DependencyProperty.Register(nameof(SearchLabel), typeof(object), typeof(WH_SearchableListView), new PropertyMetadata(null));

        /// <summary>
        /// 搜索标签内容属性
        /// </summary>
        public object SearchLabel { set => SetValue(SearchLabelProperty, value); get => (string)GetValue(SearchLabelProperty); }

        #endregion 属性字段

        #region 构造函数

        /// <summary>
        /// 静态构造函数
        /// </summary>
        static WH_SearchableListView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WH_SearchableListView), new FrameworkPropertyMetadata(typeof(WH_SearchableListView)));
        }

        #endregion 构造函数
    }
}
