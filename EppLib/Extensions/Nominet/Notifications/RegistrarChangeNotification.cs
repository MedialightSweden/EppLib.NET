﻿using System.Collections.Generic;
using System.Xml;
using EppLib.Entities;

namespace EppLib.Extensions.Nominet.Notifications
{
	public class RegistrarChangeNotification : PollResponse
	{
		public string Originator { get; set; }
		public string RegistrarTag { get; set; }
		public string CaseId { get; set; }                  // Added by Brian Wojtczak, Fasthosts
		public List<Domain> DomainList { get; set; }
		public Contact Contact { get; set; }

		public RegistrarChangeNotification(string xml) : base(xml) { }
		public RegistrarChangeNotification(byte[] bytes) : base(bytes) { }

		protected override void ProcessDataNode(XmlDocument doc, XmlNamespaceManager namespaces)
		{
			base.ProcessDataNode(doc, namespaces);

			namespaces.AddNamespace("n", "http://www.nominet.org.uk/epp/xml/std-notifications-1.2");
			XmlNode registrarChangeNode = doc.SelectSingleNode("/ns:epp/ns:response/ns:resData/n:rcData", namespaces);

			if (registrarChangeNode != null)
			{
				XmlNode originatorNode = registrarChangeNode.SelectSingleNode("n:orig", namespaces);
				if (originatorNode != null)
				{
					Originator = originatorNode.InnerText;
				}

				XmlNode registrarNode = registrarChangeNode.SelectSingleNode("n:registrarTag", namespaces);
				if (registrarNode != null)
				{
					RegistrarTag = registrarNode.InnerText;
				}

				// Added by Brian Wojtczak, Fasthosts
				XmlNode caseNode = registrarChangeNode.SelectSingleNode("n:caseId", namespaces);
				if (caseNode != null)
				{
					CaseId = caseNode.InnerText;
				}

				XmlNode domainListNode = registrarChangeNode.SelectSingleNode("n:domainListData", namespaces);
				if (domainListNode != null)
				{
					namespaces.AddNamespace("domain", "urn:ietf:params:xml:ns:domain-1.0");
					XmlNodeList domainNodes = domainListNode.SelectNodes("domain:infData", namespaces);

					if (domainNodes != null)
					{
						DomainList = new List<Domain>();
						foreach (XmlNode node in domainNodes)
						{
							DomainInfoResponse domainRes = new DomainInfoResponse(node.OuterXml);
							DomainList.Add(domainRes.Domain);
						}
					}
				}

				namespaces.AddNamespace("contact", "urn:ietf:params:xml:ns:contact-1.0");
				XmlNode contactNode = registrarChangeNode.SelectSingleNode("contact:infData", namespaces);
				if (contactNode != null)
				{
					ContactInfoResponse contactRes = new ContactInfoResponse(contactNode.OuterXml);
					Contact = contactRes.Contact;
				}
			}
		}
	}
}
