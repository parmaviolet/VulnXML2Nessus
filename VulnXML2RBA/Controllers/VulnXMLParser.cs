using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace VulnXML2Nessus.Controllers
{
    public class ParseResults
    {
        public List<ParseResultsHost> Hosts { get; set; }
    }

    public class ParseResultsHost
    {
        public string Name { get; set; } = string.Empty;

        public List<ParseResultsVuln> Items { get; set; }
        public ParseResultsHostProperties Properties { get; set; }
    }

    public class ParseResultsHostProperties
    {
        public string DnsName { get; set; } = string.Empty;
        public string IPv4 { get; set; } = string.Empty;
    }

    public class ParseResultsVuln
    {
        public string ID { get; set; } = string.Empty;
        public string Group { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Ref { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Recommendation { get; set; } = string.Empty;
        public string Port { get; set; } = string.Empty;
        public string Protocol { get; set; } = string.Empty;
        public string References { get; set; } = string.Empty;
        public string RiskRating { get; set; } = string.Empty;
        public string ReferenceID { get; set; } = string.Empty;
    }
    
    public class VulnXMLParser
    {
        private string path;

        public VulnXMLParser(string path)
        {
            this.path = path;
        }

        public ParseResults Run()
        {
            var parseResults = new ParseResults();
            parseResults.Hosts = new List<ParseResultsHost>();

            var element = XElement.Load(path);
            var report = element.Element("Hosts");

            //
            //  Iterate through Host items in VulnXML
            //

            foreach (var host in report.Elements("Host"))
            {
                var parseHost = new ParseResultsHost();
                parseHost.Items = new List<ParseResultsVuln>();

                // This will break when dnsname is not found - so will not populate custom Affected Hosts issues

                parseHost.Name = (string)host.Attribute("dnsname");
                if (string.IsNullOrEmpty(parseHost.Name))
                {
                    continue;
                }

                // For each vuln assigned to host

                foreach (var item in host.Elements("Vuln"))
                {

                    // For each port assigned to vuln in host

                    var vulnid = (string)item.Attribute("ID");

                    var ports = item.Element("Ports");

                    foreach (var port in ports.Elements("Port"))
                    {
                        var parseResultsVuln = new ParseResultsVuln();
                        parseResultsVuln.ID = (string)item.Attribute("ID");
                        parseResultsVuln.Port = (string)port.Attribute("Protocol");
                        parseResultsVuln.Protocol = (string)port;

                        // Now need to find and complete rest of each vuln settings

                        var vulns = element.Element("Vulns");

                        foreach (var vuln in vulns.Elements("Vuln"))
                        {
                            if ((string)vuln.Attribute("ID") == vulnid)
                            {
                                parseResultsVuln.Group = (string)vuln.Attribute("Group");
                                parseResultsVuln.Title = (string)vuln.Element("Title");
                                parseResultsVuln.Ref = (string)vuln.Element("Ref");
                                parseResultsVuln.Description = (string)vuln.Element("Description");
                                parseResultsVuln.Recommendation = (string)vuln.Element("Recommendation");
                                parseResultsVuln.References = "//" + Environment.NewLine + "//";
                                parseResultsVuln.RiskRating = (string)vuln.Element("CVSS").Element("OverallScore");
                                parseResultsVuln.ReferenceID = (string)vuln.Element("Reference");
                            }
                        }
                        parseHost.Items.Add(parseResultsVuln);
                    }

                }

                var parseResultsHostProperties = new ParseResultsHostProperties();
                parseResultsHostProperties.DnsName = (string)host.Attribute("dnsname");
                parseResultsHostProperties.IPv4 = (string)host.Attribute("ipv4");
                parseHost.Properties = parseResultsHostProperties;

                if (!string.IsNullOrEmpty(parseHost.Properties.IPv4))
                {
                    parseResults.Hosts.Add(parseHost);
                }
            }
            return parseResults;
        }
    }
}
