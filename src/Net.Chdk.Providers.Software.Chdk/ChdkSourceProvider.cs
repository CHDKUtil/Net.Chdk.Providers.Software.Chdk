using System;
using System.Globalization;
using Net.Chdk.Model.Software;
using Net.Chdk.Providers.Software.Product;

namespace Net.Chdk.Providers.Software.Chdk
{
    sealed class ChdkSourceProvider : ProductSourceProvider
    {
        private const string Release = "release";
        private const string Trunk = "trunk";
        private const string DeSourceName = "CHDK_DE";

        protected override string ProductName => "CHDK";

        protected override string GetChannelName(SoftwareProductInfo product)
        {
            var version = product?.Version;
            if (version == null)
                return null;
            if ((version.Major > 1 || (version.Major == 1 && version.Minor >= 4)) && version.Build == 0)
                return Trunk;
            return Release;
        }

        protected override CultureInfo GetLanguage(SoftwareSourceInfo source)
        {
            if (source.Name.Equals(DeSourceName, StringComparison.InvariantCulture))
                return CultureInfo.GetCultureInfo("de");
            return null;
        }
    }
}
