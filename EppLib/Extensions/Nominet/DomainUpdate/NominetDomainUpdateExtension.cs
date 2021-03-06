﻿using System.Collections.Generic;
using System.Xml;

namespace EppLib.Extensions.Nominet.DomainUpdate
{
	public class NominetDomainUpdateExtension : NominetDomainExtensionBase
    {
		public string FirstBill { get; set; }
		public string RecurBill { get; set; }
		public string AutoBill { get; set; }
		public string NextBill { get; set; }
		public string Reseller { get; set; }
		public string NextPeriod { get; set; }
		public string AutoPeriod { get; set; }
		public string RenewNotRequired { get; set; }
		public List<string> Notes { get; set; }

		public override XmlNode ToXml(XmlDocument doc)
        {
			XmlElement root = CreateElement(doc, "domain-nom-ext:create");

			if (FirstBill != null)
			{
				AddXmlElement(doc, root, "domain-nom-ext:first-bill", FirstBill);
			}

			if (RecurBill != null)
			{
				AddXmlElement(doc, root, "domain-nom-ext:recur-bill", RecurBill);
			}

			if (AutoBill != null)
			{
				AddXmlElement(doc, root, "domain-nom-ext:auto-bill", AutoBill);
			}

			if (NextBill != null)
			{
				AddXmlElement(doc, root, "domain-nom-ext:next-bill", NextBill);
			}

			if (AutoPeriod != null)
			{
				AddXmlElement(doc, root, "domain-nom-ext:auto-period", AutoPeriod);
			}

			if (NextPeriod != null)
			{
				AddXmlElement(doc, root, "domain-nom-ext:next-period", NextPeriod);
			}

			if (RenewNotRequired != null)
			{
				AddXmlElement(doc, root, "domain-nom-ext:renew-not-required", RenewNotRequired);
			}

			if (Notes != null)
			{
				foreach (string n in Notes)
				{
					AddXmlElement(doc, root, "domain-nom-ext:notes-bill", n);
				}
			}

			if (Reseller != null)
			{
				AddXmlElement(doc, root, "domain-ext:reseller", Reseller);
			}

			return root;
        }
    }
}