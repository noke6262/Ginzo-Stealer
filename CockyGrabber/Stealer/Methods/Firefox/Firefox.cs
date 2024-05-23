﻿namespace Ginzo
{
    public static class Firefox
    {
        public class Cookie
        {
            public int Id { get; set; }
            public string OriginAttributes { get; set; }
            public string Name { get; set; }
            public string Value { get; set; }
            public string Host { get; set; }
            public string Path { get; set; }
            public long Expiry { get; set; }
            public long LastAccessed { get; set; }
            public long CreationTime { get; set; }
            public bool IsSecure { get; set; }
            public bool IsHttpOnly { get; set; }
            public bool InBrowserElement { get; set; }
            public short SameSite { get; set; }
            public short RawSameSite { get; set; }
            public short SchemeMap { get; set; }
        }
        public class Login
        {
            public int Id { get; set; }
            public string Hostname { get; set; }
            public string HttpRealm { get; set; }
            public string FormSubmitURL { get; set; }
            public string UsernameField { get; set; }
            public string PasswordField { get; set; }
            public string EncryptedUsername { get; set; }
            public string EncryptedPassword { get; set; }
            public string Guid { get; set; }
            public short EncType { get; set; }
            public long TimeCreated { get; set; }
            public long TimeLastUsed { get; set; }
            public long TimePasswordChanged { get; set; }
            public int TimesUsed { get; set; }
        }
        public enum CookieHeader
        {
            id,
            originAttributes,
            name,
            value,
            host,
            path,
            expiry,
            lastAccessed,
            creationTime,
            isSecure,
            isHttpOnly,
            inBrowserElement,
            sameSite,
            rawSameSite,
            schemeMap,
        }
        public enum LoginHeader
        {
            id,
            hostname,
            httpRealm,
            formSubmitURL,
            usernameField,
            passwordField,
            encryptedUsername,
            encryptedPassword,
            guid,
            encType,
            timeCreated,
            timeLastUsed,
            timePasswordChanged,
            timesUsed,
        }
    }
}