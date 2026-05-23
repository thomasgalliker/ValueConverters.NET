global using System.Globalization;
global using System.Windows;
global using System.Windows.Data;
global using AwesomeAssertions;
global using ValueConverters.Services;
global using Xunit;
global using Moq;
global using ValueConverters.Tests.Testdata;

#if NETFRAMEWORK
global using static ValueConverters.Tests.EnumCompat;
#else
global using static System.Enum;
#endif
