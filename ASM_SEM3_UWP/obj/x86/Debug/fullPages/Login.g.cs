﻿#pragma checksum "D:\FPTSEM3\ASM_SEM3_UWP\ASM_SEM3_UWP\fullPages\Login.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "2A4B0A7D27D7290EBB06867D9A435771"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASM_SEM3_UWP.fullPages
{
    partial class Login : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // fullPages\Login.xaml line 12
                {
                    this.main = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 3: // fullPages\Login.xaml line 70
                {
                    this.vld_email = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 4: // fullPages\Login.xaml line 93
                {
                    this.vld_pass = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 5: // fullPages\Login.xaml line 100
                {
                    this.remember = (global::Windows.UI.Xaml.Controls.CheckBox)(target);
                }
                break;
            case 6: // fullPages\Login.xaml line 110
                {
                    global::Windows.UI.Xaml.Controls.Button element6 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element6).Click += this.btn_Submit;
                }
                break;
            case 7: // fullPages\Login.xaml line 119
                {
                    global::Windows.UI.Xaml.Controls.Button element7 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element7).Click += this.btn_register;
                }
                break;
            case 8: // fullPages\Login.xaml line 82
                {
                    this.pass = (global::Windows.UI.Xaml.Controls.PasswordBox)(target);
                }
                break;
            case 9: // fullPages\Login.xaml line 60
                {
                    this.email = (global::Windows.UI.Xaml.Controls.TextBox)(target);
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
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

