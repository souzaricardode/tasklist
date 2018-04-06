using System;
using System.Collections.Specialized;
using System.Resources;
using MvcSiteMapProvider.Globalization;

namespace TaskList.Web
{
    public class LocalizadorStrings : IStringLocalizer
    {
        protected readonly ResourceManager _resourceManager;
        public LocalizadorStrings(ResourceManager resourceManager)
        {
            if (resourceManager == null)
            {
                throw new ArgumentNullException("resourceManager");
            }
            else
            {
                _resourceManager = resourceManager;
            }
        }

        public string GetResourceString(string attributeName, string value, bool enableLocalization, 
            string classKey, string implicitResourceKey, NameValueCollection explicitResourceKeys)
        {
            if (attributeName == null)
            {
                throw new ArgumentNullException("attributeName");
            }

            if (enableLocalization)
            {
                string result = string.Empty;
                if (explicitResourceKeys != null)
                {
                    string[] values = explicitResourceKeys.GetValues(attributeName);
                    if ((values == null) || (values.Length <= 1))
                    {
                        result = value;
                    }
                    else if (_resourceManager.BaseName.Equals(values[0]))
                    {
                        try
                        {
                            result = _resourceManager.GetString(values[1]);
                        }
                        catch (MissingManifestResourceException)
                        {
                            if (!string.IsNullOrEmpty(value))
                            {
                                result = value;
                            }
                        }
                    }
                }
                if (!string.IsNullOrEmpty(result))
                {
                    return result;
                }
            }
            if (!string.IsNullOrEmpty(value))
            {
                return value;
            }

            return string.Empty;
        }
    }
}