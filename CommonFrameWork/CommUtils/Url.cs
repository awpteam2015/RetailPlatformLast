using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CommonFrameWork.CommUtils.Extensions;

namespace CommonFrameWork.CommUtils
{
    /// <summary>
    /// Represents a URL that can be built fluently
    /// </summary>
    public class Url
    {
        /// <summary>
        /// The full absolute path part of the URL (everthing except the query string).
        /// </summary>
        public string Path { get; private set; }

        /// <summary>
        /// Collection of all query string parameters.
        /// </summary>
        public IDictionary<string, object> QueryParams { get; private set; }

        /// <summary>
        /// Constructs a Url object from a string.
        /// </summary>
        /// <param name="baseUrl">The URL to use as a starting point (required)</param>
        public Url(string baseUrl)
        {
            if (baseUrl == null)
                throw new ArgumentNullException("baseUrl");

            var parts = baseUrl.Split('?');
            Path = parts[0];
            QueryParams = QueryParamCollection.Parse(parts.Length > 1 ? parts[1] : "");
        }

        /// <summary>
        /// Basically a Path.Combine for URLs. Ensures exactly one '/' character is used to seperate each segment.
        /// URL-encodes illegal characters but not reserved characters.
        /// </summary>
        /// <param name="url">The URL to use as a starting point (required).</param>
        /// <param name="segments">Paths to combine.</param>
        /// <returns></returns>
        public static string Combine(string url, params string[] segments)
        {
            if (url == null)
                throw new ArgumentNullException("url");

            return new Url(url).AppendPathSegments(segments).ToString();
        }

        /// <summary>
        /// Returns the root URL of the given full URL, including the scheme, any user info, host, and port (if specified).
        /// </summary>
        public static string GetRoot(string url)
        {
            // http://stackoverflow.com/a/27473521/62600
            var uri = new Uri(url);
            return uri.GetComponents(UriComponents.SchemeAndServer | UriComponents.UserInfo, UriFormat.Unescaped);
        }

        /// <summary>
        /// Encodes characters that are illegal in a URL path, including '?'. Does not encode reserved characters, i.e. '/', '+', etc.
        /// </summary>
        /// <param name="segment"></param>
        /// <returns></returns>
        private static string CleanSegment(string segment)
        {
            // http://stackoverflow.com/questions/4669692/valid-characters-for-directory-part-of-a-url-for-short-links
            var unescaped = Uri.UnescapeDataString(segment);
            return Uri.EscapeUriString(unescaped).Replace("?", "%3F");
        }

        /// <summary>
        /// Appends a segment to the URL path, ensuring there is one and only one '/' character as a seperator.
        /// </summary>
        /// <param name="segment">The segment to append</param>
        /// <param name="encode">If true, URL-encode the segment where necessary</param>
        /// <returns>the Url object with the segment appended</returns>
        public Url AppendPathSegment(string segment)
        {
            if (segment == null)
                throw new ArgumentNullException("segment");

            if (!Path.EndsWith("/")) Path += "/";
            Path += CleanSegment(segment.TrimStart('/').TrimEnd('/'));
            return this;
        }

        /// <summary>
        /// Appends multiple segments to the URL path, ensuring there is one and only one '/' character as a seperator.
        /// </summary>
        /// <param name="segments">The segments to append</param>
        /// <returns>the Url object with the segments appended</returns>
        public Url AppendPathSegments(params string[] segments)
        {
            foreach (var segment in segments)
                AppendPathSegment(segment);

            return this;
        }

        /// <summary>
        /// Appends multiple segments to the URL path, ensuring there is one and only one '/' character as a seperator.
        /// </summary>
        /// <param name="segments">The segments to append</param>
        /// <returns>the Url object with the segments appended</returns>
        public Url AppendPathSegments(IEnumerable<string> segments)
        {
            foreach (var s in segments)
                AppendPathSegment(s);

            return this;
        }

        /// <summary>
        /// Adds a parameter to the query string, overwriting the value if name exists.
        /// </summary>
        /// <param name="name">name of query string parameter</param>
        /// <param name="value">value of query string parameter</param>
        /// <returns>The Url obect with the query string parameter added</returns>
        public Url SetQueryParam(string name, object value)
        {
            if (name == null)
                throw new ArgumentNullException("name", "Query parameter name cannot be null.");

            QueryParams[name] = value;
            return this;
        }

        /// <summary>
        /// Parses values (usually an anonymous object or dictionary) into name/value pairs and adds them to the query string, overwriting any that already exist.
        /// </summary>
        /// <param name="values">Typically an anonymous object, ie: new { x = 1, y = 2 }</param>
        /// <returns>The Url object with the query string parameters added</returns>
        public Url SetQueryParams(object values)
        {
            if (values == null)
                return this;

            foreach (var kv in values.ToKeyValuePairs())
                SetQueryParam(kv.Key, kv.Value);

            return this;
        }

        /// <summary>
        /// Removes a name/value pair from the query string by name.
        /// </summary>
        /// <param name="name">Query string parameter name to remove</param>
        /// <returns>The Url object with the query string parameter removed</returns>
        public Url RemoveQueryParam(string name)
        {
            QueryParams.Remove(name);
            return this;
        }

        /// <summary>
        /// Removes multiple name/value pairs from the query string by name.
        /// </summary>
        /// <param name="names">Query string parameter names to remove</param>
        /// <returns>The Url object with the query string parameters removed</returns>
        public Url RemoveQueryParams(params string[] names)
        {
            foreach (var name in names)
                QueryParams.Remove(name);

            return this;
        }

        /// <summary>
        /// Removes multiple name/value pairs from the query string by name.
        /// </summary>
        /// <param name="names">Query string parameter names to remove</param>
        /// <returns>The Url object with the query string parameters removed</returns>
        public Url RemoveQueryParams(IEnumerable<string> names)
        {
            foreach (var name in names)
                QueryParams.Remove(name);

            return this;
        }

        /// <summary>
        /// Resets the URL to its root, including the scheme, any user info, host, and port (if specified).
        /// </summary>
        /// <returns>The Url object trimmed to its root.</returns>
        public Url ResetToRoot()
        {
            Path = GetRoot(Path);
            QueryParams.Clear();
            return this;
        }

        /// <summary>
        /// Converts this Url object to its string representation.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var url = Path;
            var query = QueryParams.ToString();
            if (query.Length > 0)
                url += "?" + query;

            return url;
        }

        /// <summary>
        /// Implicit conversion from Url to String.
        /// </summary>
        /// <param name="url">the Url object</param>
        /// <returns>The string</returns>
        public static implicit operator string(Url url)
        {
            return url.ToString();
        }

        /// <summary>
        /// Implicit conversion from String to Url.
        /// </summary>
        /// <param name="url">the String representation of the URL</param>
        /// <returns>The string</returns>
        public static implicit operator Url(string url)
        {
            return new Url(url);
        }
    }


    public class QueryParamCollection : IDictionary<string, object>
    {
        private readonly Dictionary<string, object> _dict = new Dictionary<string, object>();
        private readonly List<string> _orderedKeys = new List<string>();

        /// <summary>
        /// Parses a query string from a URL to a QueryParamCollection dictionary.
        /// </summary>
        /// <param name="queryString">The query string to parse.</param>
        /// <returns></returns>
        public static QueryParamCollection Parse(string queryString)
        {
            var result = new QueryParamCollection();

            if (string.IsNullOrEmpty(queryString))
                return result;

            queryString = queryString.TrimStart('?').Split('?')[0];

            var pairs = (
                from kv in queryString.Split('&')
                let pair = kv.Split('=')
                let key = pair[0]
                let value = Uri.UnescapeDataString(pair.Length >= 2 ? pair[1] : "")
                group value by key into g
                select new { Key = g.Key, Values = g.ToArray() });

            foreach (var g in pairs)
            {
                if (g.Values.Length == 1)
                    result.Add(g.Key, g.Values[0]);
                else
                    result.Add(g.Key, g.Values);
            }

            return result;
        }

        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            return _orderedKeys.Select(k => new KeyValuePair<string, object>(k, _dict[k])).GetEnumerator();
        }

        /// <summary>
        /// Returns serialized, encoded query string. Insertion order is preserved.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Join("&", GetPairs());
        }

        private IEnumerable<string> GetPairs()
        {
            foreach (var key in _orderedKeys)
            {
                var val = this[key];
                if (val == null)
                    continue;

                if (val is string || !(val is IEnumerable))
                {
                    yield return key + "=" + Uri.EscapeDataString(val.ToInvariantString());
                }
                else
                {
                    // if value is IEnumerable (other than string), break it into multiple
                    // values with same param name, i.e. x=1&x2&x=3
                    // https://github.com/tmenier/LwwFrameWork.Utilities/issues/15
                    foreach (var subval in val as IEnumerable)
                    {
                        if (subval == null)
                            continue;

                        yield return key + "=" + Uri.EscapeDataString(subval.ToInvariantString());
                    }
                }
            }
        }

        #region IDictionary<string, object> members
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(KeyValuePair<string, object> item)
        {
            Add(item.Key, item.Value);
        }

        public void Clear()
        {
            _dict.Clear();
            _orderedKeys.Clear();
        }

        public bool Contains(KeyValuePair<string, object> item)
        {
            return _dict.Contains(item);
        }

        public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
        {
            ((ICollection)_dict).CopyTo(array, arrayIndex);
        }

        public bool Remove(KeyValuePair<string, object> item)
        {
            return Remove(item.Key);
        }

        public int Count
        {
            get { return _dict.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public void Add(string key, object value)
        {
            _dict.Add(key, value);
            _orderedKeys.Add(key);
        }

        public bool ContainsKey(string key)
        {
            return _dict.ContainsKey(key);
        }

        public bool Remove(string key)
        {
            _orderedKeys.Remove(key);
            return _dict.Remove(key);
        }

        public bool TryGetValue(string key, out object value)
        {
            return _dict.TryGetValue(key, out value);
        }

        public object this[string key]
        {
            get
            {
                return _dict[key];
            }
            set
            {
                _dict[key] = value;
                if (!_orderedKeys.Contains(key))
                    _orderedKeys.Add(key);
            }
        }

        public ICollection<string> Keys
        {
            get { return _orderedKeys; }
        }

        public ICollection<object> Values
        {
            get { return _orderedKeys.Select(k => _dict[k]).ToArray(); }
        }
        #endregion
    }


    public static class StringExtensions
    {
        /// <summary>
        /// Checks if a string is a well-formed URL.
        /// </summary>
        /// <param name="s">The string to check</param>
        /// <returns>true if s is a well-formed URL</returns>
        public static bool IsUrl(this string s)
        {
            return s != null && Uri.IsWellFormedUriString(s, UriKind.Absolute);
        }

        /// <summary>
        /// Converts string to a Url object and appends a segment to the URL path, 
        /// ensuring there is one and only one '/' character as a seperator.
        /// </summary>
        /// <param name="segment">The segment to append</param>
        /// <returns>the resulting Url object</returns>
        public static Url AppendPathSegment(this string url, string segment)
        {
            return new Url(url).AppendPathSegment(segment);
        }

        /// <summary>
        /// Appends multiple segments to the URL path, ensuring there is one and only one '/' character as a seperator.
        /// </summary>
        /// <param name="segments">The segments to append</param>
        /// <returns>the Url object with the segments appended</returns>
        public static Url AppendPathSegments(this string url, params string[] segments)
        {
            return new Url(url).AppendPathSegments(segments);
        }

        /// <summary>
        /// Appends multiple segments to the URL path, ensuring there is one and only one '/' character as a seperator.
        /// </summary>
        /// <param name="segments">The segments to append</param>
        /// <returns>the Url object with the segments appended</returns>
        public static Url AppendPathSegments(this string url, IEnumerable<string> segments)
        {
            return new Url(url).AppendPathSegments(segments);
        }

        /// <summary>
        /// Converts string to a Url object and adds a parameter to the query string, overwriting the value if name exists.
        /// </summary>
        /// <param name="name">name of query string parameter</param>
        /// <param name="value">value of query string parameter</param>
        /// <returns>The Url obect with the query string parameter added</returns>
        public static Url SetQueryParam(this string url, string name, object value)
        {
            return new Url(url).SetQueryParam(name, value);
        }

        /// <summary>
        /// Converts string to a Url object, parses values object into name/value pairs, and adds them to the query string,
        /// overwriting any that already exist.
        /// </summary>
        /// <param name="values">Typically an anonymous object, ie: new { x = 1, y = 2 }</param>
        /// <returns>The Url object with the query string parameters added</returns>
        public static Url SetQueryParams(this string url, object values)
        {
            return new Url(url).SetQueryParams(values);
        }

        /// <summary>
        /// Converts string to a Url object and removes a name/value pair from the query string by name.
        /// </summary>
        /// <param name="name">Query string parameter name to remove</param>
        /// <returns>The Url object with the query string parameter removed</returns>
        public static Url RemoveQueryParam(this string url, string name)
        {
            return new Url(url).RemoveQueryParam(name);
        }

        /// <summary>
        /// Converts string to a Url object and removes multiple name/value pairs from the query string by name.
        /// </summary>
        /// <param name="names">Query string parameter names to remove</param>
        /// <returns>The Url object with the query string parameters removed</returns>
        public static Url RemoveQueryParams(this string url, params string[] names)
        {
            return new Url(url).RemoveQueryParams(names);
        }

        /// <summary>
        /// Converts string to a Url object and removes multiple name/value pairs from the query string by name.
        /// </summary>
        /// <param name="names">Query string parameter names to remove</param>
        /// <returns>The Url object with the query string parameters removed</returns>
        public static Url RemoveQueryParams(this string url, IEnumerable<string> names)
        {
            return new Url(url).RemoveQueryParams(names);
        }

        /// <summary>
        /// Trims the URL to its root, including the scheme, any user info, host, and port (if specified).
        /// </summary>
        /// <returns>A Url object.</returns>
        public static Url ResetToRoot(this string url)
        {
            return new Url(url).ResetToRoot();
        }

    }
}
