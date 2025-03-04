using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace UWPTest
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            ShowALLToast();
        }
        public static void SendToastNotification(string message)
        {
            ToastContent content = new ToastContentBuilder()
                .AddText("Toast Message")
                .AddText(message)
                .GetToastContent();

            ToastNotificationManager.CreateToastNotifier().Show(new ToastNotification(content.GetXml()));
        }
        /// <summary>
        /// 显示高级PUSH弹窗
        /// </summary>
        public static void ShowALLToast()
        {
            //相关技术文档，以微软官方为准，网络上的资料大部分已经淘汰并且都很久：https://learn.microsoft.com/en-us/windows/apps/design/shell/tiles-and-notifications/toast-schema#adaptivetext
            var builder = new ToastContentBuilder()
           .AddArgument("conversationId", 9813)
           .SetToastScenario(ToastScenario.Reminder)


           .AddHeroImage(new Uri("ms-appx:///Assets/Toast/HeroImage.png"))

           .AddText("买几根淀粉肠?", AdaptiveTextStyle.Header)
           .AddText("只买两根淀粉肠,因为我三根会吃不完，而一根的话就吃不爽，you konw i konw？")

           .AddCustomTimeStamp(new DateTime(2000, 01, 31, 00, 12, 34, DateTimeKind.Utc))

           .AddAppLogoOverride(new Uri("ms-appx:///Assets/Toast/HeadImage.png"), ToastGenericAppLogoCrop.Circle)

           .AddInlineImage(new Uri("ms-appx:///Assets/Toast/InlineImage.png"))

           .AddAudio(new Uri("ms-appx:///Assets/Toast/hnh.mp3"), true)
           //.AddAudio(new Uri("ms-appx:///Assets/Toast/lings.mp3"),true)

           .AddInputTextBox("tbReply", "Type a reply")
           .AddButton(new ToastButton()
           .SetContent("Reply")
           .SetTextBoxId("tbReply")
           //.SetImageUri(new Uri("ms-appx:///Assets/Toast/InputImage.png"))
           .AddArgument("action", "reply"))


          .AddButton(new ToastButton()
          .SetContent("Open web page")
          //.AddArgument("action", "openpage")       
          //.SetImageUri(new Uri("ms-appx:///Assets/Toast/BTN3.png"))
          .SetProtocolActivation(new Uri("https://www.pdfreaderpro.com"))
        )


           .AddButton(new ToastButton()
           .SetContent("Snooze")
           .AddArgument("action", "snooze")
           //.SetImageUri(new Uri("ms-appx:///Assets/Toast/BTN3.png"))
           .SetBackgroundActivation()
           )


           .AddButton(new ToastButton()
           .SetContent("Dismiss")
           .AddArgument("action", "dismiss")
           .SetImageUri(new Uri("ms-appx:///Assets/Toast/BTN3.png")));

            DateTimeOffset expirationTime = DateTimeOffset.Now.AddSeconds(600);
            var toast = new ToastNotification(builder.GetXml());
            toast.ExpirationTime = expirationTime;
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }
        #region 简单的toast样式
        //    private XmlDocument CreateToastXml()
        //    {
        //        // 创建 ToastNotification 的 XML 文档对象
        //        XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastImageAndText02);

        //        // 获取 ToastXML 的根元素节点
        //        XmlNodeList toastElements = toastXml.GetElementsByTagName("toast");

        //        // 创建 Toast 标题
        //        XmlNodeList textElements = toastXml.GetElementsByTagName("text");
        //        textElements[0].InnerText = "每天我只买两个淀粉肠";

        //        // 创建 Toast 内容
        //        textElements[1].InnerText = "因为三个吃不完";

        //        // 创建 Toast 图片节点
        //        XmlNodeList imageElements = toastXml.GetElementsByTagName("image");
        //        ((XmlElement)imageElements[0]).SetAttribute("src", "ms-appx:///Assets/Advertising/Mask group.png"); // 图片路径

        //        return toastXml;
        //    } 
        #endregion
    }
}
