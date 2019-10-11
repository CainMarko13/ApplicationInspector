﻿// Copyright (C) Microsoft. All rights reserved.
// Licensed under the MIT License. See LICENSE.txt in the project root for license information.

using System;

namespace Microsoft.AppInspector.CLI.Writers
{
    public class WriterFactory
    {
        public static Writer GetWriter(string writerName, string defaultWritter, string format = null)
        {
            if (string.IsNullOrEmpty(writerName))
                writerName = defaultWritter;
            
            if (string.IsNullOrEmpty(writerName))
                writerName = "text";

            switch (writerName.ToLowerInvariant())
            {  
                case "_dummy":
                    return new DummyWriter();
                case "json":
                    return new JsonWriter();                    
                case "text":
                    return new SimpleTextWriter(format);
                case "html":
                    return new LiquidWriter();
                //case "sarif":
                //    return new SarifWriter();
                default:
                    throw new Exception("wrong output");
            }
        }
    }
}