namespace WebServer.Server.HTTP
{
    using WebServer.Server.Common;

    public class HttpHeader
    {
        public HttpHeader(string key, string value)
        {

            CommonValidator.ThrowIfNull(value, nameof(value));
            CommonValidator.ThrowIfNull(key, nameof(key));

            this.Key = key;
            this.Value = value;
        }
        public string Key { get; private set; }
        public string Value { get; private set; }
        public override string ToString()
        {
            return $"{this.Key}: {this.Value}";
        }
    }
}