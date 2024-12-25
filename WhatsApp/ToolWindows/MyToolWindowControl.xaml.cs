using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace WhatsApp
{
    public partial class MyToolWindowControl : UserControl
    {
        public MyToolWindowControl()
        {
            InitializeComponent();
            InitializeAsync();
        }
        private async void InitializeAsync()
        {
            Random rnd = new Random();
            string subFolder = rnd.Next().ToString();
            var env = await Microsoft.Web.WebView2.Core.CoreWebView2Environment.CreateAsync(userDataFolder: Path.Combine(Path.GetTempPath(), $"{Environment.UserName}", subFolder));
            await WhatsApp.EnsureCoreWebView2Async(env);
            var request = WhatsApp.CoreWebView2.Environment.CreateWebResourceRequest("https://web.whatsapp.com/", "GET", null, null);
            WhatsApp.CoreWebView2.NavigateWithWebResourceRequest(request);
        }
    }
}