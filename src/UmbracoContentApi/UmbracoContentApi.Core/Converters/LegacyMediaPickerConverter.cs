﻿using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using UmbracoContentApi.Core.Resolvers;

namespace UmbracoContentApi.Core.Converters
{
    public class LegacyMediaPickerConverter : IConverter
    {
        private readonly Lazy<IContentResolver> _contentResolver;

        public LegacyMediaPickerConverter(Lazy<IContentResolver> contentResolver)
        {
            _contentResolver = contentResolver;
        }

        public string EditorAlias => "Umbraco.MediaPicker";

        public object Convert(object value, Dictionary<string, object>? options = null)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value), $"A value for {EditorAlias} is required.");
            }

            if (value is IEnumerable<IPublishedContent> ar)
            {
                return ar.Select(t => _contentResolver.Value.ResolveContent(t, options)).ToList();
            }

            return _contentResolver.Value.ResolveContent((IPublishedContent)value, options);
        }
    }
}