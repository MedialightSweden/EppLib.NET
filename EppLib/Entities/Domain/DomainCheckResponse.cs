﻿// Copyright 2012 Code Maker Inc. (http://codemaker.net)
//  
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//  
//      http://www.apache.org/licenses/LICENSE-2.0
//  
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
using System.Collections.Generic;
using System.Xml;

namespace EppLib.Entities
{
	public class DomainCheckResponse : EppResponse
	{
		private readonly List<DomainCheckResult> results =  new List<DomainCheckResult>();

		public DomainCheckResponse(byte[] bytes)
			: base(bytes)
		{


		}

		public IList<DomainCheckResult> Results
		{
			get { return results; }
		}

		protected override void ProcessDataNode(XmlDocument doc, XmlNamespaceManager namespaces)
		{
			namespaces.AddNamespace("domain", "urn:ietf:params:xml:ns:domain-1.0");

			XmlNodeList children = doc.SelectNodes("/ns:epp/ns:response/ns:resData/domain:chkData/domain:cd", namespaces);

			if (children != null)
			{
				foreach (XmlNode child in children)
				{
					results.Add(new DomainCheckResult(child,namespaces));
				}
			}
		}
		//Modified by Luke Dobson Fasthosts
		//handle the Reserved flags (nom-direct-rights) in the Extension nodes
		protected override void ProcessExtensionNode(XmlDocument doc, XmlNamespaceManager namespaces)
		{
			namespaces.AddNamespace("nom-direct-rights", "urn:ietf:params:xml:ns:domain-1.0");

			XmlNode child1 = doc.SelectSingleNode("/ns:epp/ns:response/ns:extension", namespaces);

			if (child1 != null && !string.IsNullOrEmpty(child1.InnerText))
			{
				results[0].Reserved = child1.InnerText;
			}
		}
	}
}
