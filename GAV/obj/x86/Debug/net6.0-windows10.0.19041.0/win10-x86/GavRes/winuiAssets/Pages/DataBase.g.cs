﻿#pragma checksum "C:\Users\Otlar\source\repos\GAV\GavRes\winuiAssets\Pages\DataBase.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "248039BD44285AF0B341B62802E4B86D2905F76E874C8D167DE29E3FB8CDA747"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GAV.GavRes.winuiAssets.Pages
{
    partial class DataBase : 
        global::Microsoft.UI.Xaml.Controls.Page, 
        global::Microsoft.UI.Xaml.Markup.IComponentConnector
    {

        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 1.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1: // GavRes\winuiAssets\Pages\DataBase.xaml line 1
                {
                    this.DataBasePage = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Page>(target);
                }
                break;
            case 2: // GavRes\winuiAssets\Pages\DataBase.xaml line 25
                {
                    this.topDataGrid = global::WinRT.CastExtensions.As<global::CommunityToolkit.WinUI.UI.Controls.DataGrid>(target);
                    ((global::CommunityToolkit.WinUI.UI.Controls.DataGrid)this.topDataGrid).CurrentCellChanged += this.topDataGrid_CurrentCellChanged;
                    ((global::CommunityToolkit.WinUI.UI.Controls.DataGrid)this.topDataGrid).SelectionChanged += this.topDataGrid_SelectionChanged;
                    ((global::CommunityToolkit.WinUI.UI.Controls.DataGrid)this.topDataGrid).CellEditEnded += this.topDataGrid_CellEditEnded;
                    ((global::CommunityToolkit.WinUI.UI.Controls.DataGrid)this.topDataGrid).RightTapped += this.topDataGrid_RightTapped;
                    ((global::CommunityToolkit.WinUI.UI.Controls.DataGrid)this.topDataGrid).RowEditEnded += this.topDataGrid_RowEditEnded;
                }
                break;
            case 3: // GavRes\winuiAssets\Pages\DataBase.xaml line 33
                {
                    this.filterComboBox = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.ComboBox>(target);
                }
                break;
            case 4: // GavRes\winuiAssets\Pages\DataBase.xaml line 34
                {
                    this.SearcBox = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBox>(target);
                }
                break;
            case 5: // GavRes\winuiAssets\Pages\DataBase.xaml line 36
                {
                    global::Microsoft.UI.Xaml.Controls.Button element5 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Button>(target);
                    ((global::Microsoft.UI.Xaml.Controls.Button)element5).Click += this.SearchButton_Click;
                }
                break;
            case 6: // GavRes\winuiAssets\Pages\DataBase.xaml line 37
                {
                    global::Microsoft.UI.Xaml.Controls.Button element6 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Button>(target);
                    ((global::Microsoft.UI.Xaml.Controls.Button)element6).Click += this.AddRecordButton_Click;
                }
                break;
            case 7: // GavRes\winuiAssets\Pages\DataBase.xaml line 38
                {
                    global::Microsoft.UI.Xaml.Controls.Button element7 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Button>(target);
                    ((global::Microsoft.UI.Xaml.Controls.Button)element7).Click += this.RemoveRecordButton_Click;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 1.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Microsoft.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Microsoft.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

