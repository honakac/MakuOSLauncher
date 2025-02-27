using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;
using Microsoft.Win32;

namespace MakuOSLauncher;

public partial class MainWindow : Window, IComponentConnector
{
	public MainWindow()
	{
		InitializeComponent();
		mtInfo.Text = "MakuTweker - твикер от Марка Аддерли.\nОн позволяет гибко настроить и персонализировать систему!";
	}

	private void b1_Click(object sender, RoutedEventArgs e)
	{
		Process.Start("cmd.exe", "/k compact /compactos:always");
	}

	private async void b3_Click(object sender, RoutedEventArgs e)
	{
		await new actInProg().ShowAsync();
	}

	private void b2_Click(object sender, RoutedEventArgs e)
	{
		Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Microsoft\\Windows\\CurrentVersion\\Policies\\DataCollection")?.SetValue("AllowTelemetry", 1);
		Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\DataCollection")?.SetValue("AllowTelemetry", 1);
		Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\DataCollection")?.SetValue("MaxTelemetryAllowed", 1);
		Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows NT\\CurrentVersion\\Software Protection Platform")?.SetValue("NoGenTicket", 0);
		Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\DataCollection")?.SetValue("DoNotShowFeedbackNotifications", 0);
		Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\AppCompat")?.SetValue("AITEnable", 1);
		Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\AppCompat")?.SetValue("AllowTelemetry", 1);
		Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\AppCompat")?.SetValue("DisableEngine", 0);
		Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\AppCompat")?.SetValue("DisableInventory", 0);
		Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\AppCompat")?.SetValue("DisablePCA", 0);
		Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\AppCompat")?.SetValue("DisableUAR", 0);
		Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\appDiagnostics")?.SetValue("Value", "Allow", RegistryValueKind.String);
		Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\System")?.SetValue("UploadUserActivities", 1);
		Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\System")?.SetValue("PublishUserActivities", 1);
		Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\WDI\\{9c5a40da-b965-4fc3-8781-88dd50a6299d}")?.SetValue("ScenarioExecutionEnabled", 1);
		Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\InputPersonalization")?.SetValue("RestrictImplicitTextCollection", 1);
		Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\InputPersonalization")?.SetValue("RestrictImplicitInkCollection", 1);
		Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Speech")?.SetValue("AllowSpeechModelUpdate", 1);
		i2.Text = "Телеметрия успешно возвращена!";
	}

	private void b4_Click(object sender, RoutedEventArgs e)
	{
		Process.Start("powershell.exe", "/C Add-WindowsCapability -Online -Name NetFx3~~~~\"");
	}

	private void b5_Click(object sender, RoutedEventArgs e)
	{
		Process.Start("cmd.exe", "/C powercfg /h off");
		i5.Text = "Гибернация успешно отключена!";
	}

	private void b6_Click(object sender, RoutedEventArgs e)
	{
		Process.Start("cmd.exe", "/c \"reg add HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\WindowsUpdate\\UX\\Settings /v ActiveHoursStart /t REG_DWORD /d 9 /f && reg add HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\WindowsUpdate\\UX\\Settings /v ActiveHoursEnd /t REG_DWORD /d 2 /f && reg add HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\WindowsUpdate\\UX\\Settings /v PauseFeatureUpdatesStartTime /t REG_SZ /d \"2015-01-01T00:00:00Z\" /f && reg add HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\WindowsUpdate\\UX\\Settings /v PauseQualityUpdatesStartTime /t REG_SZ /d \"2015-01-01T00:00:00Z\" /f && reg add HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\WindowsUpdate\\UX\\Settings /v PauseUpdatesExpiryTime /t REG_SZ /d \"2077-01-01T00:00:00Z\" /f && reg add HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\WindowsUpdate\\UX\\Settings /v PauseFeatureUpdatesEndTime /t REG_SZ /d \"2077-01-01T00:00:00Z\" /f && reg add HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\WindowsUpdate\\UX\\Settings /v PauseQualityUpdatesEndTime /t REG_SZ /d \"2077-01-01T00:00:00Z\" /f && reg add HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\WindowsUpdate\\UX\\Settings /v PauseUpdatesStartTime /t REG_SZ /d \"2015-01-01T00:00:00Z\" /f\"");
	}

	private void b7_Click(object sender, RoutedEventArgs e)
	{
		Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System").SetValue("EnableSmartScreen", 0);
		Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System").SetValue("EnableLUA", 0);
	}

	private void dl_Click(object sender, RoutedEventArgs e)
	{
		try
		{
			Process.Start("C:\\Users\\Default\\Desktop\\MakuTweaker Setup.exe");
		}
		catch
		{
			Process.Start(new ProcessStartInfo("https://adderly.top/mt")
			{
				UseShellExecute = true
			});
		}
	}

	private void ow_Click(object sender, RoutedEventArgs e)
	{
		Process.Start(new ProcessStartInfo("https://adderly.top")
		{
			UseShellExecute = true
		});
	}

	private void sup_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
	{
		Process.Start(new ProcessStartInfo("https://boosty.to/adderly")
		{
			UseShellExecute = true
		});
	}

	private void tg_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
	{
		Process.Start(new ProcessStartInfo("https://t.me/adderly324")
		{
			UseShellExecute = true
		});
	}

	private void yt_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
	{
		Process.Start(new ProcessStartInfo("https://youtube.com/@MakuAdarii")
		{
			UseShellExecute = true
		});
	}

	private void b8_Click(object sender, RoutedEventArgs e)
	{
		Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\WindowsUpdate").SetValue("TargetReleaseVersionInfo", "24H2");
		i8.Text = "Обновление до 24Н2 успешно разблокировано!";
	}
}
