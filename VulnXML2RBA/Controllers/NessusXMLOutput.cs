using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using VulnXML2Nessus.Controllers;

namespace VulnXML2Nessus.Controllers
{
    public class NessusXMLOutput
    {
        public XmlDocument GenerateNessusXML (ParseResults parsedResults, string filename)
        {
            XmlDocument doc = new XmlDocument();
        
            XmlNode nessus = doc.CreateNode(XmlNodeType.Element, "NessusClientData_v2", null);
            XmlNode report = doc.CreateNode(XmlNodeType.Element, "Report", null);

            XmlNode reportName = doc.CreateAttribute("name");
            reportName.Value = "NCC Group Import";
            report.Attributes.SetNamedItem(reportName);

            doc.AppendChild(nessus);
            nessus.AppendChild(report);

            // for each host
            foreach (var host in parsedResults.Hosts)
            {
                XmlNode reportHost = doc.CreateNode(XmlNodeType.Element, "ReportHost", null);
                XmlNode hostProps = doc.CreateNode(XmlNodeType.Element, "HostProperties", null);
                XmlNode tag1 = doc.CreateNode(XmlNodeType.Element, "tag", null);
                XmlNode tag2 = doc.CreateNode(XmlNodeType.Element, "tag", null);

                XmlNode nameHost = doc.CreateAttribute("name");
                XmlNode nameRDNS = doc.CreateAttribute("host-rdns");
                XmlNode nameIP = doc.CreateAttribute("host-ip");

                nameHost.Value = host.Name;
                
                reportHost.Attributes.SetNamedItem(nameHost);
                tag1.Attributes.SetNamedItem(nameRDNS);
                tag2.Attributes.SetNamedItem(nameIP);

                tag1.InnerText = host.Name;
                tag2.InnerText = host.Properties.IPv4;

                report.AppendChild(reportHost);
                reportHost.AppendChild(hostProps);
                hostProps.AppendChild(tag1);
                hostProps.AppendChild(tag2);

                foreach (var vuln in host.Items)
                {
                    XmlNode reportItem = doc.CreateNode(XmlNodeType.Element, "ReportItem", null);
                    XmlNode port = doc.CreateAttribute("port");
                    XmlNode protocol = doc.CreateAttribute("protocol");
                    XmlNode severity = doc.CreateAttribute("severity");
                    XmlNode pluginID = doc.CreateAttribute("pluginID");
                    XmlNode pluginName = doc.CreateAttribute("pluginName");

                        port.Value = vuln.Port;
                        protocol.Value = vuln.Protocol;
                        severity.Value = GetNessusSeverityValue(vuln.RiskRating);
                        pluginID.Value = vuln.Ref;
                        pluginName.Value = vuln.Title;

                        reportItem.Attributes.SetNamedItem(port);
                        reportItem.Attributes.SetNamedItem(protocol);
                        reportItem.Attributes.SetNamedItem(severity);
                        reportItem.Attributes.SetNamedItem(pluginID);
                        reportItem.Attributes.SetNamedItem(pluginName);

                            XmlNode description = doc.CreateNode(XmlNodeType.Element, "description", null);
                            XmlNode plugin_name = doc.CreateNode(XmlNodeType.Element, "plugin_name", null);
                            XmlNode risk_factor = doc.CreateNode(XmlNodeType.Element, "risk_factor", null);
                            XmlNode solution = doc.CreateNode(XmlNodeType.Element, "solution", null);

                            description.InnerText = vuln.Description;
                            plugin_name.InnerText = vuln.Title;
                            risk_factor.InnerText = vuln.RiskRating;
                            solution.InnerText = vuln.Recommendation;

                    reportItem.AppendChild(description);
                    reportItem.AppendChild(plugin_name);
                    reportItem.AppendChild(risk_factor);
                    reportItem.AppendChild(solution);
                    reportHost.AppendChild(reportItem);
                }
            }
            return doc;
        }

        public string GetNessusSeverityValue(string riskfactor)
        {
            string severity = "0";

            switch (riskfactor)
            {
                case "Critical":
                    severity = "4";
                    break;
                case "High":
                    severity = "3";
                    break;
                case "Medium":
                    severity = "2";
                    break;
                case "Low":
                    severity = "1";
                    break;
                case "Info":
                    severity = "0";
                    break;           
            }

            return severity;
        }
    }
}
