﻿using System.Collections.Generic;

namespace UmbracoContentApi.Core.Converters
{
    public class DateTimeConverter : IConverter
    {
        public string EditorAlias => "Umbraco.DateTime";

        public object Convert(object value, Dictionary<string, object>? options = null)
        {
            return value;
        }
    }
}
