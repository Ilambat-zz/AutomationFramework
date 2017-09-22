using System;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using TechTalk.SpecFlow;

namespace ILFramework.Framework
{
    public class BrowserStackService
    {

        private static readonly NameValueCollection Settings = ConfigurationManager.GetSection($"browserstack/settings") as NameValueCollection;
        private static readonly NameValueCollection Environments = ConfigurationManager.GetSection($"browserstack/environments/{Settings?["env"]}") as NameValueCollection;
        private static readonly NameValueCollection Capabilities = ConfigurationManager.GetSection($"browserstack/capabilities/single") as NameValueCollection;

        public static RemoteWebDriver Init()
        {
            var capability = new DesiredCapabilities();

            foreach (var key in Settings.AllKeys)
                capability.SetCapability(key, Settings[key]);

            foreach (var key in Environments.AllKeys)
                capability.SetCapability(key, Environments[key]);

            foreach (var key in Capabilities.AllKeys)
                capability.SetCapability(key, Capabilities[key]);

            capability.SetCapability("browserstack.user", Settings["username"]);
            capability.SetCapability("browserstack.key", Settings["key"]);

            capability.SetCapability("name", ScenarioContext.Current.ScenarioInfo.Title);

            return new RemoteWebDriver(new Uri($"http://{Settings["server"]}/wd/hub"), capability);

        }

        public static void CheckTestFailing(RemoteWebDriver driver)
        {

            var error = ScenarioContext.Current.TestError;

            if (error == null)
                return;

            var sessionId = driver.SessionId;

            var request = WebRequest.CreateHttp($"https://www.browserstack.com/automate/sessions/{sessionId}.json");
            request.ContentType = "application/json";
            request.Method = "PUT";
            request.Credentials = new NetworkCredential(Settings["username"], Settings["key"]);

            using (var stream = new StreamWriter(request.GetRequestStream()))
            {
                var content = new JavaScriptSerializer() .Serialize(new
                {
                    status = "failed",
                    reason = error.Message
                });
                stream.Write(content);
            }
            request.GetResponse();
        }

    }
}
