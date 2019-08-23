namespace SampleCode.RegexSample
{
    using System.Text.RegularExpressions;
    public class RegexSampleMatch
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="connectionString"></param>
        public static ServerConfig GetServerConfig(string connectionString)
        {
            //host=172.16.0.175:5672;username=guest;password=guest;
            if (string.IsNullOrEmpty(connectionString)) return null;
            ServerConfig server = new ServerConfig();
            var hostNamePattern = @"host=([^;]+)";
            var hostMatch = Regex.Match(connectionString, hostNamePattern);
            if (hostMatch.Success)
            {
                var hostConfig = hostMatch.Groups[1].Value.Split(':');
                server.HostName = hostConfig[0];
                server.Port = int.Parse(hostConfig[1]);
            }

            var usernamePattern = @"username=([^;]+)";
            var usernameMatch = Regex.Match(connectionString, usernamePattern);
            if (usernameMatch.Success)
            {
                server.UserName = usernameMatch.Groups[1].Value;
            }

            var passwordPattern = @"password=([^;]+)";
            var passwordMatch = Regex.Match(connectionString, passwordPattern);
            if (passwordMatch.Success)
            {
                server.Password = passwordMatch.Groups[1].Value;
            }

            return server;
        }

    }

    public class ServerConfig
    {

        /// <summary>
        /// Server地址
        /// </summary>
        public string HostName { get; set; }

        /// <summary>
        /// Server端口
        /// </summary>
        public int Port { get; set; } = 5672;

        /// <summary>
        /// Server用户名
        /// </summary>
        public string UserName { get; set; } = "guest";

        /// <summary>
        /// Server密码
        /// </summary>
        public string Password { get; set; } = "guest";
    }
}
