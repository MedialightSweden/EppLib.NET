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
    public class ContactCheckResponse : EppResponse
    {
        private readonly List<ContactCheckResult> _results = new List<ContactCheckResult>();

        public IList<ContactCheckResult> Results
        {
            get { return _results; }
        }

        public ContactCheckResponse(byte[] bytes) : base(bytes) { }

        protected override void ProcessDataNode(XmlDocument doc, XmlNamespaceManager namespaces)
        {
            namespaces.AddNamespace("contact", "urn:ietf:params:xml:ns:contact-1.0");

            XmlNodeList children = doc.SelectNodes("/ns:epp/ns:response/ns:resData/contact:chkData/contact:cd", namespaces);
            if (children != null)
            {
                foreach (XmlNode child in children)
                {
                    _results.Add(new ContactCheckResult(child, namespaces));
                }
            }
        }
    }
}