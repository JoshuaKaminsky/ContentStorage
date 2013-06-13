using System;
using System.Diagnostics;
using ContentStorage.IO;
using Microsoft.Win32;

namespace ContentStorage.Extension
{
    internal static class FileExtensionExtension
    {
        private const string ContentTypeKey = "Content Type";
        private const string DefaultContentType = "application/octet-stream";

        public static string GetContentType(this FileExtension extension)
        {
            try
            {
                var key = Registry.ClassesRoot.OpenSubKey(extension.Value);

                return key == null ? DefaultContentType : key.GetValue(ContentTypeKey, DefaultContentType).ToString();
            }
            catch (Exception)
            {
                Trace.TraceError("Could not access Registry for extension {0}", extension.Value);
            }

            return DefaultContentType;
        }
    }
}
