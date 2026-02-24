using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Net.Sockets;


namespace WinFormsApp1.Hardware;

internal class RigolScopeHardware: IStatusProvider
{
    private const string DefaultIpAddress = "192.168.50.164";
    private string ipAddress = DefaultIpAddress;
    public event EventHandler<StatusChangedEventArgs> StatusChanged = (sender, e) => { };
    public RigolScopeHardware()
    { 
        ipAddress = SettingsManager.Settings.RigolScopeIp ?? DefaultIpAddress;
    }
    private void ReportStatus(string message, bool isError)
    {
        string status = $"Rigol Scope ({ipAddress}) {message}";
        status = status.ReplaceLineEndings(string.Empty);
        StatusChanged?.Invoke(this, new StatusChangedEventArgs(message, isError));
    }
    public string Query(string message, int timeoutMs, int maxCharacterCount)
    {
        if (message is null) throw new ArgumentNullException("Message must be not null.");
        if (message.Length == 0) throw new ArgumentException("Message must be not empty.");
        if (timeoutMs < 1 || timeoutMs > 60000) throw new ArgumentOutOfRangeException(nameof(timeoutMs), "Timeout must be between 1 and 60000 milliseconds.");
        ReportStatus($"Query \"{message}\".", true);
        try
        {
            using (TcpClient client = new TcpClient())
            {
                client.ReceiveTimeout = timeoutMs;
                client.SendTimeout = timeoutMs;
                client.Connect(ipAddress, 5025);
                using (NetworkStream stream = client.GetStream())
                {
                    byte[] dataToSend = Encoding.ASCII.GetBytes(message + "\n");
                    stream.Write(dataToSend, 0, dataToSend.Length);
                    byte[] buffer = new byte[maxCharacterCount];
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    string response = Encoding.ASCII.GetString(buffer, 0, bytesRead).Trim();
                    response = response.TrimEnd('\r', '\n');
                    ReportStatus($"Response: \"{response}\".", false);
                    return response;
                }
            }
        }
        catch (Exception ex)
        {
            ReportStatus($"Error: {ex.Message}", true);
            return string.Empty;
        }
    }

}
