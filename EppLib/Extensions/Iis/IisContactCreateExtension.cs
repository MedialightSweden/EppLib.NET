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

using System;
using System.Xml;

namespace EppLib.Extensions.Iis
{
    public class IisContactCreateExtension : IisExtensionBase
    {
        public string OrganizationNumber { get; set; }
        public string VatNumber { get; set; }

        public override XmlNode ToXml(XmlDocument doc)
        {
            XmlElement root = CreateElement(doc, "iis:create");

            if (!string.IsNullOrWhiteSpace(OrganizationNumber))
            {
                AddXmlElement(doc, root, "iis:orgno", OrganizationNumber);
            }

            if (!string.IsNullOrWhiteSpace(VatNumber))
            {
                AddXmlElement(doc, root, "iis:vatno", VatNumber);
            }

            return root;
        }
    }
}