using System.Diagnostics;
using System.IO;
using System.Media;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using ModernWpf.Controls;

namespace MakuOSLauncher;

public partial class actInProg : ContentDialog, IComponentConnector
{
	public actInProg()
	{
		InitializeComponent();
		HWIDAct();
	}

	private async void HWIDAct()
	{
		string text = await ExecuteCommandAsync(await GetEmbeddedCmdContentAsync("MakuOSLauncher.HWID.cmd"));
		if (text.Contains("Not Connected"))
		{
			MessageBox.Show("Вы не подключены к интернету. Подключитесь к интернету и повторите попытку.", "MakuOS Launcher", MessageBoxButton.OK, MessageBoxImage.Hand);
			Hide();
		}
		else if (text.Contains("permanently activated"))
		{
			SystemSounds.Asterisk.Play();
			textBlock.Text = "Windows была успешно активирована!";
			ILOVEMAKUOS.Visibility = Visibility.Collapsed;
			textBlock.Height = 30.0;
			stp.Height = 30.0;
			base.CloseButtonText = "Закрыть";
		}
		else
		{
			Hide();
		}
	}

	private async Task<string> GetEmbeddedCmdContentAsync(string resourceName)
	{
		using Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName);
		using StreamReader reader = new StreamReader(stream, Encoding.UTF8);
		return await reader.ReadToEndAsync();
	}

	private async Task<string> ExecuteCommandAsync(string cmdContent)
	{
		string text = Path.Combine(Path.GetTempPath(), "hwid.cmd");
		File.WriteAllText(text, cmdContent);
		ProcessStartInfo startInfo = new ProcessStartInfo
		{
			FileName = "cmd.exe",
			Arguments = "/C \"" + text + "\"",
			RedirectStandardOutput = true,
			RedirectStandardError = true,
			UseShellExecute = false,
			CreateNoWindow = true,
			WindowStyle = ProcessWindowStyle.Hidden
		};
		using Process process = new Process();
		process.StartInfo = startInfo;
		process.Start();
		string output = await process.StandardOutput.ReadToEndAsync();
		string text2 = await process.StandardError.ReadToEndAsync();
		if (!string.IsNullOrEmpty(text2))
		{
			return "Error: " + text2;
		}
		process.WaitForExit();
		return output;
	}
}
